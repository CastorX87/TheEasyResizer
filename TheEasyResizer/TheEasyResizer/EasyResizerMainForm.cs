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
   public partial class EasyResizerMainForm : Form
   {
      // --------- VARIABLES --------- //
      private string[] mCmdLineArgs = null; // Array of command line arguments
      private List<string> mListOfInputElements = null;
      private List<string> mListOfConversionProfileNames = null;
      private string mCurrentProfileName = "";
      private List<Thread> mConverterThreads;
      private FileDispenser mFileDispenser;
      private List<bool> mThreadFinished = new List<bool>();
      private Utility.ExecAllowState mExecAllowed = new Utility.ExecAllowState();

      // --------- FUNCTIONS --------- //
      public EasyResizerMainForm(string[] cmdLineArgs)
      {
         this.mListOfInputElements = new List<string>();
         this.mCmdLineArgs = cmdLineArgs;
         if (this.mCmdLineArgs.Length > 1)
         {
            for (int i = 1; i < this.mCmdLineArgs.Length; i++)
            {
               var filePaths = this.mCmdLineArgs[i].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

               mListOfInputElements.AddRange(filePaths);
               //filePaths
               //GetListOfFiles(filePaths, MediaType.Image, ref mFinalListOfFiles);
            }
         }
         InitializeComponent();
         SetStatusbarMessage("Total number of input elemets: " + mListOfInputElements.Count);
         lbInputFiles.DataSource = mListOfInputElements;
         tbRootPath.Text = GetCommonFolder();
         UpdateExample();

         UpdateProfileList();
      }

      private void UpdateProfileList(string forcedProfile = "")
      {
         var entries = Utility.LoadAllOptions();
         if (entries.Count > 0)
         {
            var profileNames = entries.Keys;
            var profileObjects = entries.Values;
            mListOfConversionProfileNames = profileNames.ToList();
            cbSelectedCOnversionProfile.DataSource = null;
            cbSelectedCOnversionProfile.DataSource = mListOfConversionProfileNames;

            if (string.IsNullOrWhiteSpace(forcedProfile) == false)
            {
               mCurrentProfileName = forcedProfile;
               cbSelectedCOnversionProfile.Text = forcedProfile;
            }
            else
            {
               mCurrentProfileName = mListOfConversionProfileNames[0];
               cbSelectedCOnversionProfile.Text = mCurrentProfileName;
            }
         }
         else
         {
            cbSelectedCOnversionProfile.Text = "NO PROFILE AVAILABLE";
         }
      }

      private static bool SaveConvProfOptInFile(string path, ConvProfileOptions convOptToSave)
      {
         StringBuilder sbFileContent = new StringBuilder();

         sbFileContent.Append(convOptToSave.imgResOptions.resizeMode.ToString() + Environment.NewLine);
         sbFileContent.Append(convOptToSave.imgResOptions.tgtMegapixel + Environment.NewLine);
         sbFileContent.Append(convOptToSave.imgResOptions.exactWidth + Environment.NewLine);
         sbFileContent.Append(convOptToSave.imgResOptions.exactHeight + Environment.NewLine);
         sbFileContent.Append(convOptToSave.imgResOptions.exactLongerSize + Environment.NewLine);
         sbFileContent.Append(convOptToSave.imgResOptions.incrSizeIfSmaller + Environment.NewLine);
         sbFileContent.Append(convOptToSave.imgResOptions.jpegQuality + Environment.NewLine);
         sbFileContent.Append(convOptToSave.vidResOptions.videoFileProcMode + Environment.NewLine);
         sbFileContent.Append(convOptToSave.vidResOptions.bitrateMbps + Environment.NewLine);
         sbFileContent.Append(convOptToSave.vidResOptions.verticalResolution + Environment.NewLine);
         sbFileContent.Append(convOptToSave.copyOtherFiles + Environment.NewLine);

         try
         {
            File.WriteAllText(path, sbFileContent.ToString());
         }
         catch (Exception e)
         {
            return false;
         }

         return true;
      }

      public void SetConvStartButton(string text, Color bgColor)
      {
         if (InvokeRequired)
         {
            this.Invoke(new Action<string, Color>(SetConvStartButton), new object[] { text, bgColor });
            return;
         }
         btnStartConversion.Text = text;
         btnStartConversion.BackColor = bgColor;
      }

      public void SetStatusbarMessage(string message)
      {
         if (InvokeRequired)
         {
            this.Invoke(new Action<string>(SetStatusbarMessage), new object[] { message });
            return;
         }
         toolStripStatusLabel1.Text = message;
      }

      public void SetStatusbarProgressBar(int value)
      {
         if (InvokeRequired)
         {
            this.Invoke(new Action<int>(SetStatusbarProgressBar), new object[] { value });
            return;
         }
         toolStripProgressBar1.Value = value;
      }

      private void btnRemoveSelFiles_Click(object sender, EventArgs e)
      {
         foreach (var item in lbInputFiles.SelectedItems)
         {
            mListOfInputElements.Remove(item.ToString());
         }

         lbInputFiles.DataSource = null;
         lbInputFiles.DataSource = mListOfInputElements;
         tbRootPath.Text = GetCommonFolder();
         UpdateExample();

         SetStatusbarMessage("Total number of input elemets: " + mListOfInputElements.Count);
      }

      private void lbInputFiles_DragEnter(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            e.Effect = DragDropEffects.All;
         else
            e.Effect = DragDropEffects.None;
      }

      string mLastSelectedExampleFile = "Example.jpeg";

      private void lbInputFiles_DragDrop(object sender, DragEventArgs e)
      {
         string[] filepaths;
         filepaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
         mListOfInputElements.AddRange(filepaths);
         //GetListOfFiles((string[])e.Data.GetData(DataFormats.FileDrop, false), MediaType.Image, ref mListOfInputElements);

         lbInputFiles.DataSource = null;
         lbInputFiles.DataSource = mListOfInputElements;
         tbRootPath.Text = GetCommonFolder();
         UpdateExample();

         SetStatusbarMessage("Total number of files: " + mListOfInputElements.Count);
      }

      private void btnShowOptions_Click(object sender, EventArgs e)
      {
         ConvProfileOptionsForm profileOptions = new ConvProfileOptionsForm(cbSelectedCOnversionProfile.Text);
         profileOptions.ShowDialog();
         cbSelectedCOnversionProfile.Text = profileOptions.ReturnSelectedConvOptions();
         mCurrentProfileName = profileOptions.ReturnSelectedConvOptions();
         UpdateProfileList(mCurrentProfileName);
      }

      private void EasyResizerMainForm_Load(object sender, EventArgs e)
      {
         ffmepgCheck();
         ffmpegLinkLabel.Links.Add(0, "https://ffmpeg.zeranoe.com/builds/".Length, "https://ffmpeg.zeranoe.com/builds/");
      }

      private string GetCommonFolder()
      {
         string retFolder = "";
         string screenPath = "";
         if (mListOfInputElements.Count == 0)
            return "Warning: Can not be determined. You have to add input files/directories first.";
         string[] pathParts = mListOfInputElements[0].Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

         for (int i = 0; i < pathParts.Length; i++)
         {
            screenPath = (i == 0 ? "" : screenPath + "\\") + pathParts[i];
            bool allContains = true;
            foreach (var inputElem in mListOfInputElements)
            {
               if (inputElem.ToLower().StartsWith(screenPath.ToLower()) == false)
               {
                  allContains = false;
                  break;
               }
            }
            if (allContains)
               retFolder = screenPath;
         }

         if (retFolder != "" && Directory.Exists(retFolder) == false)
            retFolder = Path.GetDirectoryName(retFolder);

         if (retFolder == "")
         {
            retFolder = "Warning: Can not be determined. Input elements are on different drives. Directories for drives will be created.";
         }

         return retFolder;
      }

      private void UpdateExample(string inputFileExample = "Example")
      {
         if (string.IsNullOrWhiteSpace(tbOutDir.Text))
         {
            tbExampleOutput.Text = "No output directory ha been specified.";
            return;
         }

         if (Directory.Exists(inputFileExample))
            inputFileExample = inputFileExample + "\\Example.jpeg";

         tbExampleOutput.Text = Utility.GenerateOutPath(inputFileExample, cbCreateSubdirs.Checked, cbTopmostDirOnly.Checked, tbRootPath.Text, tbOutDir.Text);
      }

      

      public class ThreadConvOptions
      {
         public int threadIndex;
         public bool createSubdirs;
         public bool topmostDirOnly;
         public string rootPath;
         public string outputDir;
         public ExistingFileHandlingMode existFileHandlMode;
         public ConvProfileOptions convOptions;
         public string ffmpegPath;
         public List<bool> threadFinishedList;
      }

      string ThreadId()
      {
         return "0x" + Thread.CurrentThread.ManagedThreadId.ToString("X4");
      }

      void CreateDirIfDoesNotExist(string outputPath)
      {
         string outputFileDirectory = Path.GetDirectoryName(outputPath);
         if (Directory.Exists(outputFileDirectory) == false)
         {
            AppendLineToFileLog("[" + ThreadId() + "] Creating directory: " + outputFileDirectory);
            Directory.CreateDirectory(outputFileDirectory);
         }
      }

      int mNumFilesAtStart = 0;

      void ConvertThreadFunction(ThreadConvOptions threadOptions)
      {
         AppendLineToFileLog("Thread reporting with ID: 0x" + Thread.CurrentThread.ManagedThreadId.ToString("X4"));
         Thread.Sleep(100);

         string inputFileName = "";
         while(string.IsNullOrWhiteSpace((inputFileName = mFileDispenser.GetNextFile())) == false && mExecAllowed.execAllowed == true)
         {
            SetStatusbarProgressBar((int)((1.0f - (float)mFileDispenser.GetNumRemainigFiles() / mNumFilesAtStart) * 100));

            AppendLineToFileLog("[" + ThreadId() + "] Analyzing input file: " + inputFileName);

            string outputPath = Utility.GenerateOutPath(
               inputFileName,
               threadOptions.createSubdirs,
               threadOptions.topmostDirOnly,
               threadOptions.rootPath,
               threadOptions.outputDir,
               threadOptions.existFileHandlMode);

            MediaType mediaType = Utility.MediaTypeOfFile(inputFileName);

            if (string.IsNullOrWhiteSpace(outputPath))
            {
               AppendLineToFileLog("[" + ThreadId() + "] Skipping file");
               continue;
            } else
            {
               AppendLineToFileLog("[" + ThreadId() + "] Processing file");
            }

            if (mediaType == MediaType.Image)
            {
               if(threadOptions.convOptions.imgResOptions.resizeMode == ImageProcessMode.Skip)
               {
                  AppendLineToFileLog("[" + ThreadId() + "] Skipping file");
                  continue;
               }
               if (threadOptions.convOptions.imgResOptions.resizeMode == ImageProcessMode.Copy)
               {
                  AppendLineToFileLog("[" + ThreadId() + "] Copying file");
                  File.Copy(inputFileName, outputPath, true);
                  continue;
               }
               CreateDirIfDoesNotExist(outputPath);
               Image inputImage = Utility.LoadImageAndRotate(inputFileName);
               int newW = inputImage.Width, newH = inputImage.Height;
               Utility.CalcNewSize(threadOptions.convOptions.imgResOptions, inputImage.Width, inputImage.Height, out newW, out newH);
               Bitmap resized = Utility.ResizeImage(inputImage, newW, newH);
               Utility.SaveBitmalAsJpeg(resized, outputPath, threadOptions.convOptions.imgResOptions.jpegQuality);
               resized.Dispose();
               inputImage.Dispose();
            }
            if(mediaType == MediaType.Video)
            {
               if (threadOptions.convOptions.vidResOptions.videoFileProcMode == VideoProcessMode.Skip)
               {
                  AppendLineToFileLog("[" + ThreadId() + "] Skipping file");
                  continue;
               }
               if (threadOptions.convOptions.vidResOptions.videoFileProcMode == VideoProcessMode.Copy)
               {
                  AppendLineToFileLog("[" + ThreadId() + "] Copying file");
                  File.Copy(inputFileName, outputPath, true);
                  continue;
               }
               if (threadOptions.convOptions.vidResOptions.videoFileProcMode == VideoProcessMode.Resize)
               {
                  AppendLineToFileLog("[" + ThreadId() + "] Resizing video file");
                  if(Utility.CallFfmpeg(threadOptions.ffmpegPath, inputFileName, outputPath, threadOptions.convOptions.vidResOptions.verticalResolution, true, threadOptions.convOptions.vidResOptions.bitrateMbps, mExecAllowed))
                  {
                     SetStatusbarMessage("FFMPEG.exe or FFPROBE.exe not found.");
                     AppendLineToFileLog("[" + ThreadId() + "] An error occured while converting the video file. FFMPEG.exe/FFPROBE.exe is probably missing.");
                  }
               }
            }
            if(mediaType == MediaType.Other)
            {
               if(threadOptions.convOptions.copyOtherFiles)
               {
                  if(threadOptions.convOptions.extensionFilter.Split(new string[] { ",", " ", ";" },
                     StringSplitOptions.RemoveEmptyEntries).Count(x => outputPath.ToUpper().EndsWith(x.ToUpper())) > 0)
                  {
                     AppendLineToFileLog("[" + ThreadId() + "] Copying file");
                     File.Copy(inputFileName, outputPath, true);
                     continue;
                  }
               }
            }
         }

         if (mExecAllowed.execAllowed == false)
            return;

         lock (threadOptions.threadFinishedList)
         {
            threadOptions.threadFinishedList[threadOptions.threadIndex] = true;
            if (threadOptions.threadFinishedList.All(x => x == true))
            {
               SetStatusbarMessage("JOB FINISHED");
               SetConvStartButton("START CONVERSION", Color.PaleTurquoise);
            }
         }
      }

      string lockable = "";
      void AppendLineToFileLog(string logText, bool eraseFileFirst = false)
      {
         lock (lockable)
         {
            if (eraseFileFirst)
            {
               File.WriteAllText("Log.txt", logText + Environment.NewLine);
            }
            else
            {
               File.AppendAllText("Log.txt", logText + Environment.NewLine);
            }
         }
      }

      ExistingFileHandlingMode GetExistFileHandlModeFromGui()
      {
         string selVal = "";
         this.Invoke((MethodInvoker)delegate ()
         {
            selVal = cbExistFileHandlMode.Text;
         });

         if (selVal == "Skip file if already existing in output path")
            return ExistingFileHandlingMode.Skip;
         if (selVal == "Append/increase index at end of file name")
            return ExistingFileHandlingMode.AddIndex;
         return ExistingFileHandlingMode.Overwrite;
      }

      private void btnStartConversion_Click(object sender, EventArgs e)
      {
         bool allFinished = false;
         lock(mThreadFinished)
         {
            allFinished = mThreadFinished.All(x => x == true);
         }
         if(mThreadFinished != null && allFinished == false)
         {
            if(MessageBox.Show("Are you sure you want to stop the conversion process?", "Stop conversion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
               return;
            }
            mExecAllowed.execAllowed = false;
            Thread.Sleep(1000);
            foreach(Thread thread in mConverterThreads)
            {
               if(thread.IsAlive)
               {
                  thread.Abort();
               }
            }
            btnStartConversion.Text = "START CONVERSION";
            btnStartConversion.BackColor = Color.PaleTurquoise;
            mThreadFinished = new List<bool>();
            SetStatusbarProgressBar(0);
            SetStatusbarMessage("Job aborted by user.");
            return;
         }

         SetStatusbarMessage("Starting resize/convert procedure...");

         btnStartConversion.Text = "STOP CONVERSION";
         btnStartConversion.BackColor = Color.LightSalmon;

         int numProcessors = Environment.ProcessorCount;
         int numThreadsToCreate = cbEnableMultithreading.Checked ? numProcessors : 1;

         AppendLineToFileLog("Starting conversion on " + numThreadsToCreate + " threads.", true);

         List<string> allFiles = new List<string>();
         Utility.GetListOfFiles(mListOfInputElements.ToArray(), ref allFiles);
         mFileDispenser = new FileDispenser(allFiles.ToArray());
         ConvProfileOptions convProfOpt = new ConvProfileOptions();
         convProfOpt.LoadProfileFromFile(mCurrentProfileName);
         mNumFilesAtStart = mFileDispenser.GetNumRemainigFiles();

         mExecAllowed.execAllowed = true;
         mThreadFinished = new List<bool>();
         mConverterThreads = new List<Thread>();
         for (int threadIndexG = 0; threadIndexG < numThreadsToCreate; threadIndexG++)
         {
            int threadIndex = threadIndexG;
            mConverterThreads.Add(new Thread(() => ConvertThreadFunction(new ThreadConvOptions()
            {
               createSubdirs = cbCreateSubdirs.Checked,
               convOptions = Utility.LoadAllOptions()[mCurrentProfileName],
               existFileHandlMode = GetExistFileHandlModeFromGui(),
               outputDir = tbOutDir.Text,
               rootPath = tbRootPath.Text,
               topmostDirOnly = cbTopmostDirOnly.Checked,
               ffmpegPath = tbPathFfmpeg.Text,
               threadFinishedList = mThreadFinished,
               threadIndex = threadIndex
            })));
            mThreadFinished.Add(false);
         }

         foreach (Thread thread in mConverterThreads)
            thread.Start();

         SetStatusbarMessage("Working...");
      }

      private void btnBrowseOutDir_Click(object sender, EventArgs e)
      {

      }

      private void tbOutDir_TextChanged(object sender, EventArgs e)
      {
         UpdateExample(mLastSelectedExampleFile);
      }

      private void lbInputFiles_Move(object sender, EventArgs e)
      {

      }

      private void lbInputFiles_MouseDown(object sender, MouseEventArgs e)
      {
         ListBox lb = ((ListBox)sender);
         Point pt = new Point(e.X, e.Y);
         int index = lb.IndexFromPoint(pt);

         if (index >= 0)
         {
            mLastSelectedExampleFile = lb.Items[index].ToString();
            UpdateExample(mLastSelectedExampleFile);
         }
      }

      private void cbCreateSubdirs_CheckedChanged(object sender, EventArgs e)
      {
         if (cbCreateSubdirs.Checked)
         {
            cbTopmostDirOnly.Enabled = true;
         }
         else
         {
            cbTopmostDirOnly.Checked = false;
            cbTopmostDirOnly.Enabled = false;
         }
         UpdateExample(mLastSelectedExampleFile);
      }

      private void cbTopmostDirOnly_CheckedChanged(object sender, EventArgs e)
      {
         UpdateExample(mLastSelectedExampleFile);
      }

      private void btnBrowseFfmpegPath_Click(object sender, EventArgs e)
      {

      }

      private void cbSelectedCOnversionProfile_TextChanged(object sender, EventArgs e)
      {
         // Profile must be loaded here!
      }

      void ffmepgCheck()
      {
         if (tbPathFfmpeg.Text.Length > 0)
         {
            if (File.Exists(tbPathFfmpeg.Text + "\\bin\\ffmpeg.exe") == false || File.Exists(tbPathFfmpeg.Text + "\\bin\\ffprobe.exe") == false)
            {
               SetStatusbarMessage("WARNING: ffmpeg/ffprobe.exe not found in '" + tbPathFfmpeg.Text + "\\bin" + "'.");
               tbPathFfmpeg.BackColor = Color.IndianRed;
            } else
            {
               tbPathFfmpeg.BackColor = Color.OldLace;
               SetStatusbarMessage("INFO: ffmpeg/ffprobe.exe location is correct.");
            }
         }
      }

      private void tbPathFfmpeg_TextChanged(object sender, EventArgs e)
      {
         ffmepgCheck();
      }

      private void ffmpegLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
      }
   }
}
