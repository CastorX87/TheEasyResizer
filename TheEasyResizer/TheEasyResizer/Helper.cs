using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Windows.Media.Imaging;


namespace TheEasyResizer
{
   // --------- TYPES --------- //
   [Flags]
   public enum MediaType { None = 0, Image = 1, Video = 2, Other = 4 };

   public enum ImageProcessMode { Skip, Copy, ResizeTgtMegapixel, ResizeExactSize, ResizeLengthOfLongerSize };
   public enum VideoProcessMode { Skip, Copy, Resize };
   public enum ExistingFileHandlingMode { Overwrite, AddIndex, Skip };

   public class ExpProcessExec
   {
      public Process process = null;
      public StreamReader reader = null;

      public bool ExecuteProcessStart(string appPath, string arguments)
      {
         if (File.Exists(appPath) == false)
         {
            return false;
         }
         ProcessStartInfo start = new ProcessStartInfo();
         start.FileName = appPath;
         start.Arguments = arguments;
         start.UseShellExecute = false;
         start.RedirectStandardOutput = true;
         start.CreateNoWindow = true;
         process = Process.Start(start);
         reader = process.StandardOutput;
         return false;
      }

      public void ExecuteProcessDispose()
      {
         if (process != null)
            process.Dispose();
         if (reader != null)
            reader.Dispose();
      }

      public bool ExecuteProcess(string appPath, string arguments, out string outputString)
      {
         if(File.Exists(appPath) == false)
         {
            outputString = "";
            return false;
         }
         ProcessStartInfo start = new ProcessStartInfo();
         start.FileName = appPath;
         start.Arguments = arguments;
         start.UseShellExecute = false;
         start.RedirectStandardOutput = true;
         start.CreateNoWindow = true;
         using (Process process = Process.Start(start))
         {
            using (StreamReader reader = process.StandardOutput)
            {
               outputString = reader.ReadToEnd();
            }
         }
         return true;
      }
   }

   public class Utility
   {
      public class ExecAllowState
      {
         public bool execAllowed = true;
      }

      public delegate void ConversionFinishedDelegate();

      static string ffmpegArgs = " -i \"<INPUT_FILE_NAME>\" -b:v <VQ> -b:a 128k -s <V_W>x<V_H> -vcodec libx264 -acodec aac <OVERWRITE_MODE> \"<OUTPUT_FILE_NAME>\"";
      static string ffprobeArgs = "-v error -show_format -show_streams \"<IN_FILE_PATH>\"";

      public static bool CallFfmpeg(string ffmpegPath, string inPath, string outPath, int outputHeight, bool overwriteExisting, int outputMegabitPerSec, ExecAllowState execAllowed)
      {
         ExpProcessExec ffmpegProcExec;
         ExpProcessExec ffprobeProcExec;

         string ffprobeExePath = ffmpegPath + "\\bin\\ffprobe.exe";
         string ffmpegExePath = ffmpegPath + "\\bin\\ffmpeg.exe";
         string ffprobeArgsFinal = ffprobeArgs.Replace("<IN_FILE_PATH>", inPath);

         if(File.Exists(ffmpegExePath) == false || File.Exists(ffprobeExePath) == false)
         {
            return false;
         }

         string outputStr;
         ffprobeProcExec = new ExpProcessExec();
         ffprobeProcExec.ExecuteProcess(ffprobeExePath, ffprobeArgsFinal, out outputStr);
         bool VideoRotated = false;
         if (outputStr.Contains("TAG:rotate=90"))
         {
            VideoRotated = true;
         }

         int w = (Int32.Parse(outputStr.Split(new string[] { "\n" }, StringSplitOptions.None).Where(x => x.StartsWith("width")).First().Substring(6)));
         int h = (Int32.Parse(outputStr.Split(new string[] { "\n" }, StringSplitOptions.None).Where(x => x.StartsWith("height")).First().Substring(7)));
         double aspRatio = w / (double)h;
         if (VideoRotated)
            aspRatio = h / (double)w;

         int outHeight = NearestEvenInteger(outputHeight);
         int outWidth = NearestEvenInteger((int)(outputHeight * aspRatio));

         string ffmpegArgsFinal = ffmpegArgs.Replace("<INPUT_FILE_NAME>", inPath).Replace("<OUTPUT_FILE_NAME>", outPath).Replace("<VQ>", "" + outputMegabitPerSec + "M").Replace("<V_W>", outWidth.ToString()).Replace("<V_H>", outHeight.ToString()).Replace("<OVERWRITE_MODE>", overwriteExisting ? "-y" : "-n");

         ffmpegProcExec = new ExpProcessExec();
         ffmpegProcExec.ExecuteProcessStart(ffmpegExePath, ffmpegArgsFinal);
         while(execAllowed.execAllowed && ffmpegProcExec.process.HasExited == false)
         {
            Thread.Sleep(100);
         }
         if(ffmpegProcExec.process.HasExited)
         {
            string txt = ffmpegProcExec.reader.ReadToEnd();
         }
         if (execAllowed.execAllowed == false)
         {
            ffmpegProcExec.process.Kill();
         }
         ffmpegProcExec.ExecuteProcessDispose();

         return true;
      }

      public static MediaType MediaTypeOfFile(string inPath)
      {
         inPath = inPath.ToLower();
         if (inPath.EndsWith(".avi") || inPath.EndsWith(".mov") || inPath.EndsWith(".mp4") || inPath.EndsWith(".mkv") || inPath.EndsWith(".m2ts"))
            return MediaType.Video;
         if (inPath.EndsWith(".jpg") || inPath.EndsWith(".jpeg") || inPath.EndsWith(".bmp") || inPath.EndsWith(".png"))
            return MediaType.Image;
         return MediaType.Other;
      }

      public static string ReplaceExtenseionAccordingToMediaType(string inputPath, MediaType mediaType = MediaType.None)
      {
         if (mediaType == MediaType.None)
            mediaType = MediaTypeOfFile(inputPath);

         if (mediaType == MediaType.Other || mediaType == MediaType.None)
            return inputPath;
         if (mediaType == MediaType.Image)
            return Path.GetDirectoryName(inputPath) + "\\" + Path.GetFileNameWithoutExtension(inputPath) + ".jpeg";
         if (mediaType == MediaType.Video)
            return Path.GetDirectoryName(inputPath) + "\\" + Path.GetFileNameWithoutExtension(inputPath) + ".avi";
         return "";
      }

      public static void CalcNewSize(ImgResOptions imgResOpt, int width, int height, out int newWidth, out int newHeight)
      {
         newWidth = width;
         newHeight = height;

         float aspRatio = (float)width / height;

         if (imgResOpt.resizeMode == ImageProcessMode.ResizeTgtMegapixel)
         {
            int currPixels = width * height;
            int tgtPixels = (int)(imgResOpt.tgtMegapixel * 1000000);
            float pixelScale = (float)currPixels / tgtPixels;
            if (currPixels < tgtPixels && imgResOpt.incrSizeIfSmaller == false)
               pixelScale = 1;
            newWidth = (int)(width / Math.Sqrt(pixelScale));
            newHeight = (int)(height / Math.Sqrt(pixelScale));
         }
         if (imgResOpt.resizeMode == ImageProcessMode.ResizeLengthOfLongerSize)
         {
            int tgtW;
            int tgtH;
            if (width > height)
            {
               tgtW = imgResOpt.exactLongerSize;
               tgtH = -1;
            }
            else
            {
               tgtW = -1;
               tgtH = imgResOpt.exactLongerSize;
            }
            if (tgtW == -1)
            {
               newHeight = tgtH;
               newWidth = (int)(width / (height / (double)tgtH));
            }
            else
            if (tgtH == -1)
            {
               newWidth = tgtW;
               newHeight = (int)(height / (width / (double)tgtW));
            }
            if ((width < newWidth || height < newHeight) && imgResOpt.incrSizeIfSmaller == false)
            {
               newWidth = width;
               newHeight = height;
            }
         }
         if (imgResOpt.resizeMode == ImageProcessMode.ResizeExactSize)
         {
            int tgtW = imgResOpt.exactWidth;
            int tgtH = imgResOpt.exactHeight;
            if (tgtW == -1)
            {
               newHeight = tgtH;
               newWidth = (int)(width / (height / (double)tgtH));
            }
            else
            if (tgtH == -1)
            {
               newWidth = tgtW;
               newHeight = (int)(height / (width / (double)tgtW));
            }
            else
            if (tgtW != -1 && tgtH != -1)
            {
               newWidth = tgtW;
               newHeight = tgtH;
            }
            if ((width < newWidth || height < newHeight) && imgResOpt.incrSizeIfSmaller == false)
            {
               newWidth = width;
               newHeight = height;
            }
         }
      }

      public static Image LoadImageAndRotate(string path)
      {
         Image loadedImg = Image.FromFile(path);
         if (Array.IndexOf(loadedImg.PropertyIdList, 274) > -1)
         {
            var orientation = (int)loadedImg.GetPropertyItem(274).Value[0];
            switch (orientation)
            {
               case 1:
                  // No rotation required.
                  break;
               case 2:
                  loadedImg.RotateFlip(RotateFlipType.RotateNoneFlipX);
                  break;
               case 3:
                  loadedImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
                  break;
               case 4:
                  loadedImg.RotateFlip(RotateFlipType.Rotate180FlipX);
                  break;
               case 5:
                  loadedImg.RotateFlip(RotateFlipType.Rotate90FlipX);
                  break;
               case 6:
                  loadedImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                  break;
               case 7:
                  loadedImg.RotateFlip(RotateFlipType.Rotate270FlipX);
                  break;
               case 8:
                  loadedImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
                  break;
            }
            // This EXIF data is now invalid and should be removed.
            loadedImg.RemovePropertyItem(274);
         }
         return loadedImg;
      }

      public static Bitmap ResizeImage(Image image, int newWidth, int newHeight)
      {
         var destRect = new Rectangle(0, 0, newWidth, newHeight);
         var destImage = new Bitmap(newWidth, newHeight);

         destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

         using (var graphics = Graphics.FromImage(destImage))
         {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
               wrapMode.SetWrapMode(WrapMode.TileFlipXY);
               graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
         }

         return destImage;
      }

      public static bool SaveBitmalAsJpeg(Bitmap bitmapToSave, string fileName, int jpegQuality)
      {
         try
         {
            ImageCodecInfo myImageCodecInfo;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, jpegQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bitmapToSave.Save(fileName, myImageCodecInfo, myEncoderParameters);
            myEncoderParameter.Dispose();
            myEncoderParameters.Dispose();
         }
         catch (Exception e)
         {
            return false;
         }
         return true;
      }

      public static void GetListOfFiles(string[] inputFilePaths, ref List<string> outFinalListOfFiles, int depth = 0)
      {
         List<string> finalListOfFiles = new List<string>();

         foreach (string path in inputFilePaths)
         {
            if (outFinalListOfFiles.Count >= 10000)
               return;

            if (Directory.Exists(path))
            {
               var filesAndDirs = Directory.EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly);
               GetListOfFiles(filesAndDirs.ToArray(), ref outFinalListOfFiles, depth++);
            }
            if (File.Exists(path))
            {
               outFinalListOfFiles.Add(path);
            }
         }

         //inputFilePaths.AddRange(Directory.EnumerateFiles(tbSelectedInputDirectory.Text, "*.*", cbRecoursiveDirSearch.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
         //            .Where(s => (DecideMediaType(s) == MediaType.Image || DecideMediaType(s) == MediaType.Video)).ToList());
         //return finalListOfFiles.ToArray();
      }

      public static string GenerateOutPath(string inputPath, bool createSubdirs, bool topmostDirOnly, string rootPath, string outputDir, ExistingFileHandlingMode existFileHandlMode = ExistingFileHandlingMode.Overwrite)
      {
         string retPath = "";

         var mediaType = MediaTypeOfFile(inputPath);

         if (createSubdirs)
         {
            if (rootPath.StartsWith("Warning: "))
            {
               retPath = outputDir + "\\" + inputPath.Replace(":\\", "\\");
            }
            else
            {
               retPath = inputPath.Replace(rootPath, outputDir);
            }
            if (topmostDirOnly)
            {
               string tmpRetPath = inputPath.Replace(rootPath, "");
               string[] tmpRetPathParts = tmpRetPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
               retPath = (tmpRetPathParts.Length > 1 ? tmpRetPathParts[tmpRetPathParts.Length - 2] + "\\" : "") + tmpRetPathParts[tmpRetPathParts.Length - 1];
               retPath = outputDir + "\\" + retPath;
            }
         }
         else
         {
            retPath = outputDir + "\\" + Path.GetFileName(inputPath);
         }
         retPath = Utility.ReplaceExtenseionAccordingToMediaType(retPath, mediaType);

         if (existFileHandlMode == ExistingFileHandlingMode.Skip)
         {
            if (File.Exists(retPath))
            {
               retPath = "";
            }
         }
         if (existFileHandlMode == ExistingFileHandlingMode.AddIndex)
         {
            if (File.Exists(retPath))
            {
               for (int i = 2; i < 99; i++)
               {
                  if (i == 2)
                     retPath = retPath.Insert(retPath.LastIndexOf('.'), "_" + i.ToString().PadLeft(2, '0'));
                  else
                     retPath = retPath.Remove(retPath.LastIndexOf('.') - 3, 3).Insert(retPath.LastIndexOf('.') - 3, "_" + i.ToString().PadLeft(2, '0'));

                  if (File.Exists(retPath) == false)
                     break;

                  if (i == 98)
                  {
                     retPath = "";
                     break;
                  }
               }
            }
         }

         return retPath;
      }

      public static ImageCodecInfo GetEncoderInfo(String mimeType)
      {
         int j;
         ImageCodecInfo[] encoders;
         encoders = ImageCodecInfo.GetImageEncoders();
         for (j = 0; j < encoders.Length; ++j)
         {
            if (encoders[j].MimeType == mimeType)
               return encoders[j];
         }
         return null;
      }

      public static int NearestEvenInteger(int to)
      {
         return (to % 2 == 0) ? to : (to + 1);
      }


      public static Dictionary<string, ConvProfileOptions> LoadAllOptions()
      {
         Dictionary<string, ConvProfileOptions> optList = new Dictionary<string, ConvProfileOptions>();
         string currDir = System.IO.Directory.GetCurrentDirectory();
         var listOfFiles = System.IO.Directory.EnumerateFiles(currDir, "*.terco");
         foreach (var file in listOfFiles)
         {
            optList.Add(System.IO.Path.GetFileNameWithoutExtension(file), new ConvProfileOptions());
            optList[System.IO.Path.GetFileNameWithoutExtension(file)].LoadProfileFromFile(file);
         }

         return optList;
      }

      public static DialogResult ShowInputDialog(ref string input)
      {
         System.Drawing.Size size = new System.Drawing.Size(300, 50);
         Form inputBox = new Form();

         inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         inputBox.ClientSize = size;
         inputBox.Text = "Name";

         System.Windows.Forms.TextBox textBox = new TextBox();
         textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
         textBox.Location = new System.Drawing.Point(5, 5);
         textBox.Text = input;
         inputBox.Controls.Add(textBox);

         Button okButton = new Button();
         okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         okButton.Name = "okButton";
         okButton.Size = new System.Drawing.Size(75, 23);
         okButton.Text = "&OK";
         okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
         inputBox.Controls.Add(okButton);

         Button cancelButton = new Button();
         cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         cancelButton.Name = "cancelButton";
         cancelButton.Size = new System.Drawing.Size(75, 23);
         cancelButton.Text = "&Cancel";
         cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
         inputBox.Controls.Add(cancelButton);

         inputBox.AcceptButton = okButton;
         inputBox.CancelButton = cancelButton;

         DialogResult result = inputBox.ShowDialog();
         input = textBox.Text;
         return result;
      }
   }

   public class ImgResOptions
   {
      public ImageProcessMode resizeMode;
      public int tgtMegapixel;
      public int exactWidth;  // Can be -1 to keep aspect ratio
      public int exactHeight; // Can be -1 to keep aspect ratio
      public int exactLongerSize;
      public int jpegQuality; // Valid values are between 30 and 100
      public bool incrSizeIfSmaller;
   }

   public class VideoResOptions
   {
      public VideoProcessMode videoFileProcMode;
      public int verticalResolution;
      public int bitrateMbps;
   }

   public class ConvProfileOptions
   {
      public bool copyOtherFiles;
      public string extensionFilter;
      public ImgResOptions imgResOptions = new ImgResOptions();
      public VideoResOptions vidResOptions = new VideoResOptions();

      public bool SaveProfileInFile(string path)
      {
         try
         {
            StringBuilder sb = new StringBuilder();
            sb.Append(imgResOptions.exactHeight + Environment.NewLine);
            sb.Append(imgResOptions.exactLongerSize + Environment.NewLine);
            sb.Append(imgResOptions.exactWidth + Environment.NewLine);
            sb.Append(imgResOptions.incrSizeIfSmaller + Environment.NewLine);
            sb.Append(imgResOptions.jpegQuality + Environment.NewLine);
            sb.Append(imgResOptions.resizeMode + Environment.NewLine);
            sb.Append(imgResOptions.tgtMegapixel + Environment.NewLine);
            sb.Append(vidResOptions.bitrateMbps + Environment.NewLine);
            sb.Append(vidResOptions.verticalResolution + Environment.NewLine);
            sb.Append(vidResOptions.videoFileProcMode + Environment.NewLine);
            sb.Append(copyOtherFiles + Environment.NewLine);
            sb.Append(extensionFilter);
            System.IO.File.WriteAllText(path, sb.ToString());
         }
         catch (Exception e)
         {
            return false;
         }
         return true;
      }

      public bool LoadProfileFromFile(string path)
      {
         try
         {
            string[] fileLines = System.IO.File.ReadAllLines(path);
            this.imgResOptions.exactHeight = Int32.Parse(fileLines[0]);
            this.imgResOptions.exactLongerSize = Int32.Parse(fileLines[1]);
            this.imgResOptions.exactWidth = Int32.Parse(fileLines[2]);
            this.imgResOptions.incrSizeIfSmaller = bool.Parse(fileLines[3]);
            this.imgResOptions.jpegQuality = Int32.Parse(fileLines[4]);
            this.imgResOptions.resizeMode = (ImageProcessMode)Enum.Parse(typeof(ImageProcessMode), fileLines[5]);
            this.imgResOptions.tgtMegapixel = Int32.Parse(fileLines[6]);
            this.vidResOptions.bitrateMbps = Int32.Parse(fileLines[7]);
            this.vidResOptions.verticalResolution = Int32.Parse(fileLines[8]);
            this.vidResOptions.videoFileProcMode = (VideoProcessMode)Enum.Parse(typeof(VideoProcessMode), fileLines[9]);
            this.copyOtherFiles = bool.Parse(fileLines[10]);
            if (fileLines.Length > 11)
               this.extensionFilter = fileLines[11];
            else
               this.extensionFilter = "";
         }
         catch (Exception e)
         {
            return false;
         }
         return true;
      }
   }
}
