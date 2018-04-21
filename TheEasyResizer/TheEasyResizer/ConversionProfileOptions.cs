using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheEasyResizer
{
   public partial class ConvProfileOptionsForm : Form
   {
      Dictionary<string, ConvProfileOptions> mConvOptionsLoaded = new Dictionary<string, ConvProfileOptions>();
      string mSelectedConvOptions = "";

      public string ReturnSelectedConvOptions()
      {
         return mSelectedConvOptions;
      }

      public ConvProfileOptionsForm(string startupProfile = "")
      {
         InitializeComponent();
         UpdateProfileList(true, startupProfile);
         if(mConvOptionsLoaded.ContainsKey(startupProfile))
            SetGuiUsingConvProfileOptions(mConvOptionsLoaded[startupProfile]);
      }

      private void UpdateProfileList(bool chnageComboBoxOfProfiles, string forcedProfile = "")
      {
         mConvOptionsLoaded = Utility.LoadAllOptions();
         if (mConvOptionsLoaded.Count > 0)
         {
            var profileNames = mConvOptionsLoaded.Keys;
            var profileObjects = mConvOptionsLoaded.Values;

            if (chnageComboBoxOfProfiles)
            {
               cbExistingProfiles.DataSource = null;
               cbExistingProfiles.DataSource = profileNames.ToList();
               cbExistingProfiles.Text = string.IsNullOrEmpty(forcedProfile) ? profileNames.ToArray()[0] : forcedProfile;
            }
            

            if (string.IsNullOrEmpty(forcedProfile))
               mSelectedConvOptions = profileNames.ToArray()[0];
            else
               mSelectedConvOptions = forcedProfile;
         }
         else
         {
            cbExistingProfiles.Text = "NO PROFILE AVAILABLE";
            mSelectedConvOptions = "";
         }
      }

      public void SetGuiUsingConvProfileOptions(ConvProfileOptions options)
      {
         if (InvokeRequired)
         {
            this.Invoke(new Action<ConvProfileOptions>(SetGuiUsingConvProfileOptions), new object[] { options });
            return;
         }

         tbExactSizeH.Text = options.imgResOptions.exactHeight.ToString();
         tbExactSizeW.Text = options.imgResOptions.exactWidth.ToString();
         tbLongerSideSize.Text = options.imgResOptions.exactLongerSize.ToString();
         tbWantedMegapixels.Text = options.imgResOptions.tgtMegapixel.ToString();
         cbIncreaseSizeWhenSmaller.Checked = options.imgResOptions.incrSizeIfSmaller;
         tbJpegQuality.Value = (int)((options.imgResOptions.jpegQuality - 50.0f) / 50.0f * 10.0f);

         rbImgResModeSkip.Checked = (options.imgResOptions.resizeMode == ImageProcessMode.Skip);
         rbImgResModeCopy.Checked = (options.imgResOptions.resizeMode == ImageProcessMode.Copy);
         rbImgResModeTgtMegapixels.Checked = (options.imgResOptions.resizeMode == ImageProcessMode.ResizeTgtMegapixel);
         rbImgResModeTgtSize.Checked = (options.imgResOptions.resizeMode == ImageProcessMode.ResizeExactSize);
         rbImgResModeTgtLongerSide.Checked = (options.imgResOptions.resizeMode == ImageProcessMode.ResizeLengthOfLongerSize);

         cbVideoBitrate.Text = options.vidResOptions.bitrateMbps.ToString();
         cbVideoResolution.Text = options.vidResOptions.verticalResolution.ToString();

         rbVideoModeSkip.Checked = (options.vidResOptions.videoFileProcMode == VideoProcessMode.Skip);
         rbVideoModeCopy.Checked = (options.vidResOptions.videoFileProcMode == VideoProcessMode.Copy);
         rbVideoModeResize.Checked = (options.vidResOptions.videoFileProcMode == VideoProcessMode.Resize);

         cbCopyOtherFiles.Checked = options.copyOtherFiles;
         tbOtherFileExtFilter.Text = options.extensionFilter;
      }

      private ConvProfileOptions CreateProfileOptionsFromGui()
      {
         ConvProfileOptions profOptions = new ConvProfileOptions();
         profOptions.imgResOptions.exactHeight = Int32.Parse(tbExactSizeH.Text);
         profOptions.imgResOptions.exactWidth = Int32.Parse(tbExactSizeW.Text);
         profOptions.imgResOptions.exactLongerSize = Int32.Parse(tbLongerSideSize.Text);
         profOptions.imgResOptions.tgtMegapixel = Int32.Parse(tbWantedMegapixels.Text);
         profOptions.imgResOptions.incrSizeIfSmaller = cbIncreaseSizeWhenSmaller.Checked;
         profOptions.imgResOptions.jpegQuality = (int)((tbJpegQuality.Value / (float)10) * 50 + 50);
         if (rbImgResModeSkip.Checked)
            profOptions.imgResOptions.resizeMode = ImageProcessMode.Skip;
         if (rbImgResModeCopy.Checked)
            profOptions.imgResOptions.resizeMode = ImageProcessMode.Copy;
         if (rbImgResModeTgtMegapixels.Checked)
            profOptions.imgResOptions.resizeMode = ImageProcessMode.ResizeTgtMegapixel;
         if (rbImgResModeTgtSize.Checked)
            profOptions.imgResOptions.resizeMode = ImageProcessMode.ResizeExactSize;
         if (rbImgResModeTgtLongerSide.Checked)
            profOptions.imgResOptions.resizeMode = ImageProcessMode.ResizeLengthOfLongerSize;

         profOptions.vidResOptions.bitrateMbps = Int32.Parse(cbVideoBitrate.Text);
         profOptions.vidResOptions.verticalResolution = Int32.Parse(cbVideoResolution.Text.Replace("p", ""));

         if (rbVideoModeSkip.Checked)
            profOptions.vidResOptions.videoFileProcMode = VideoProcessMode.Skip;
         if (rbVideoModeCopy.Checked)
            profOptions.vidResOptions.videoFileProcMode = VideoProcessMode.Copy;
         if (rbVideoModeResize.Checked)
            profOptions.vidResOptions.videoFileProcMode = VideoProcessMode.Resize;

         profOptions.copyOtherFiles = cbCopyOtherFiles.Checked;
         profOptions.extensionFilter = tbOtherFileExtFilter.Text;

         return profOptions;
      }

      private List<string> LoadListOfProfiles()
      {
         List<string> listOfProfiles = new List<string>();

         return listOfProfiles;
      }

      private void ConvProfileOptionsForm_Load(object sender, EventArgs e)
      {
         /*if(string.IsNullOrEmpty(mSelectedConvOptions))
         {
            MessageBox.Show("You have to select a valid profile to load.", "ERROR");
            return;
         }*/


      }

      private void btnSaveAsNewProfile_Click(object sender, EventArgs e)
      {
         string inputTex = "Please enter the name you want to give for the new provile.";
         if (Utility.ShowInputDialog(ref inputTex) == DialogResult.OK && string.IsNullOrWhiteSpace(inputTex) == false)
         {
            if (CreateProfileOptionsFromGui().SaveProfileInFile(inputTex + ".terco") == false)
            {
               MessageBox.Show("An error occured: file can't be saved.", "ERROR");
            } else
            {
               UpdateProfileList(true, inputTex);
            }
         }
      }

      private void btnOverwriteProfile_Click(object sender, EventArgs e)
      {
         if (CreateProfileOptionsFromGui().SaveProfileInFile(mSelectedConvOptions + ".terco") == false)
         {
            MessageBox.Show("An error occured: file can't be saved.", "ERROR");
         }
         else
         {
            UpdateProfileList(false, mSelectedConvOptions);
            cbExistingProfiles.Text = mSelectedConvOptions;
         }
      }

      private void cbExistingProfiles_TextChanged(object sender, EventArgs e)
      {
         mSelectedConvOptions = cbExistingProfiles.Text;
         UpdateProfileList(false, mSelectedConvOptions);
         if(mConvOptionsLoaded.ContainsKey(mSelectedConvOptions))
            SetGuiUsingConvProfileOptions(mConvOptionsLoaded[mSelectedConvOptions]);
      }

      private void cbExistingProfiles_SelectedIndexChanged(object sender, EventArgs e)
      {

      }
   }
}
