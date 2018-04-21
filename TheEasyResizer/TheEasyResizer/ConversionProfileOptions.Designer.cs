namespace TheEasyResizer
{
   partial class ConvProfileOptionsForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.cbExistingProfiles = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.btnLoadSelectedProfile = new System.Windows.Forms.Button();
         this.btnOverwriteProfile = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label9 = new System.Windows.Forms.Label();
         this.rbImgResModeCopy = new System.Windows.Forms.RadioButton();
         this.rbImgResModeSkip = new System.Windows.Forms.RadioButton();
         this.label3 = new System.Windows.Forms.Label();
         this.tbExactSizeH = new System.Windows.Forms.TextBox();
         this.tbExactSizeW = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tbLongerSideSize = new System.Windows.Forms.TextBox();
         this.tbWantedMegapixels = new System.Windows.Forms.TextBox();
         this.cbIncreaseSizeWhenSmaller = new System.Windows.Forms.CheckBox();
         this.rbImgResModeTgtLongerSide = new System.Windows.Forms.RadioButton();
         this.rbImgResModeTgtSize = new System.Windows.Forms.RadioButton();
         this.rbImgResModeTgtMegapixels = new System.Windows.Forms.RadioButton();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.tbJpegQuality = new System.Windows.Forms.TrackBar();
         this.btnSaveAsNewProfile = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.rbVideoModeResize = new System.Windows.Forms.RadioButton();
         this.rbVideoModeCopy = new System.Windows.Forms.RadioButton();
         this.rbVideoModeSkip = new System.Windows.Forms.RadioButton();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.cbVideoBitrate = new System.Windows.Forms.ComboBox();
         this.cbVideoResolution = new System.Windows.Forms.ComboBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.textBox3 = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.tbOtherFileExtFilter = new System.Windows.Forms.TextBox();
         this.cbCopyOtherFiles = new System.Windows.Forms.CheckBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tbJpegQuality)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // cbExistingProfiles
         // 
         this.cbExistingProfiles.FormattingEnabled = true;
         this.cbExistingProfiles.Location = new System.Drawing.Point(121, 6);
         this.cbExistingProfiles.Name = "cbExistingProfiles";
         this.cbExistingProfiles.Size = new System.Drawing.Size(329, 21);
         this.cbExistingProfiles.TabIndex = 0;
         this.cbExistingProfiles.SelectedIndexChanged += new System.EventHandler(this.cbExistingProfiles_SelectedIndexChanged);
         this.cbExistingProfiles.TextChanged += new System.EventHandler(this.cbExistingProfiles_TextChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(103, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Load existing profile:";
         // 
         // btnLoadSelectedProfile
         // 
         this.btnLoadSelectedProfile.Location = new System.Drawing.Point(322, 33);
         this.btnLoadSelectedProfile.Name = "btnLoadSelectedProfile";
         this.btnLoadSelectedProfile.Size = new System.Drawing.Size(128, 23);
         this.btnLoadSelectedProfile.TabIndex = 2;
         this.btnLoadSelectedProfile.Text = "Load selected profile";
         this.btnLoadSelectedProfile.UseVisualStyleBackColor = true;
         // 
         // btnOverwriteProfile
         // 
         this.btnOverwriteProfile.Location = new System.Drawing.Point(322, 62);
         this.btnOverwriteProfile.Name = "btnOverwriteProfile";
         this.btnOverwriteProfile.Size = new System.Drawing.Size(128, 23);
         this.btnOverwriteProfile.TabIndex = 3;
         this.btnOverwriteProfile.Text = "Overwrite profile";
         this.btnOverwriteProfile.UseVisualStyleBackColor = true;
         this.btnOverwriteProfile.Click += new System.EventHandler(this.btnOverwriteProfile_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.rbImgResModeCopy);
         this.groupBox1.Controls.Add(this.rbImgResModeSkip);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.tbExactSizeH);
         this.groupBox1.Controls.Add(this.tbExactSizeW);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tbLongerSideSize);
         this.groupBox1.Controls.Add(this.tbWantedMegapixels);
         this.groupBox1.Controls.Add(this.cbIncreaseSizeWhenSmaller);
         this.groupBox1.Controls.Add(this.rbImgResModeTgtLongerSide);
         this.groupBox1.Controls.Add(this.rbImgResModeTgtSize);
         this.groupBox1.Controls.Add(this.rbImgResModeTgtMegapixels);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.tbJpegQuality);
         this.groupBox1.Location = new System.Drawing.Point(12, 33);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(304, 242);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Image resize options";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(94, 223);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(102, 13);
         this.label9.TabIndex = 17;
         this.label9.Text = "JPEG coding quality";
         // 
         // rbImgResModeCopy
         // 
         this.rbImgResModeCopy.AutoSize = true;
         this.rbImgResModeCopy.Location = new System.Drawing.Point(6, 43);
         this.rbImgResModeCopy.Name = "rbImgResModeCopy";
         this.rbImgResModeCopy.Size = new System.Drawing.Size(85, 17);
         this.rbImgResModeCopy.TabIndex = 14;
         this.rbImgResModeCopy.TabStop = true;
         this.rbImgResModeCopy.Text = "Copy images";
         this.rbImgResModeCopy.UseVisualStyleBackColor = true;
         // 
         // rbImgResModeSkip
         // 
         this.rbImgResModeSkip.AutoSize = true;
         this.rbImgResModeSkip.Location = new System.Drawing.Point(6, 19);
         this.rbImgResModeSkip.Name = "rbImgResModeSkip";
         this.rbImgResModeSkip.Size = new System.Drawing.Size(82, 17);
         this.rbImgResModeSkip.TabIndex = 14;
         this.rbImgResModeSkip.TabStop = true;
         this.rbImgResModeSkip.Text = "Skip images";
         this.rbImgResModeSkip.UseVisualStyleBackColor = true;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.label3.Location = new System.Drawing.Point(22, 115);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(224, 13);
         this.label3.TabIndex = 13;
         this.label3.Text = "Use -1 by width or height to keep aspect ratio.";
         // 
         // tbExactSizeH
         // 
         this.tbExactSizeH.Location = new System.Drawing.Point(136, 93);
         this.tbExactSizeH.Name = "tbExactSizeH";
         this.tbExactSizeH.Size = new System.Drawing.Size(39, 20);
         this.tbExactSizeH.TabIndex = 2;
         this.tbExactSizeH.Text = "-1";
         // 
         // tbExactSizeW
         // 
         this.tbExactSizeW.Location = new System.Drawing.Point(81, 93);
         this.tbExactSizeW.Name = "tbExactSizeW";
         this.tbExactSizeW.Size = new System.Drawing.Size(39, 20);
         this.tbExactSizeW.TabIndex = 2;
         this.tbExactSizeW.Text = "1920";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(123, 96);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(12, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "x";
         // 
         // tbLongerSideSize
         // 
         this.tbLongerSideSize.Location = new System.Drawing.Point(119, 132);
         this.tbLongerSideSize.Name = "tbLongerSideSize";
         this.tbLongerSideSize.Size = new System.Drawing.Size(39, 20);
         this.tbLongerSideSize.TabIndex = 2;
         this.tbLongerSideSize.Text = "1920";
         // 
         // tbWantedMegapixels
         // 
         this.tbWantedMegapixels.Location = new System.Drawing.Point(126, 67);
         this.tbWantedMegapixels.Name = "tbWantedMegapixels";
         this.tbWantedMegapixels.Size = new System.Drawing.Size(25, 20);
         this.tbWantedMegapixels.TabIndex = 2;
         this.tbWantedMegapixels.Text = "3";
         // 
         // cbIncreaseSizeWhenSmaller
         // 
         this.cbIncreaseSizeWhenSmaller.AutoSize = true;
         this.cbIncreaseSizeWhenSmaller.Location = new System.Drawing.Point(6, 158);
         this.cbIncreaseSizeWhenSmaller.Name = "cbIncreaseSizeWhenSmaller";
         this.cbIncreaseSizeWhenSmaller.Size = new System.Drawing.Size(152, 17);
         this.cbIncreaseSizeWhenSmaller.TabIndex = 1;
         this.cbIncreaseSizeWhenSmaller.Text = "Increase size when smaller";
         this.cbIncreaseSizeWhenSmaller.UseVisualStyleBackColor = true;
         // 
         // rbImgResModeTgtLongerSide
         // 
         this.rbImgResModeTgtLongerSide.AutoSize = true;
         this.rbImgResModeTgtLongerSide.Location = new System.Drawing.Point(6, 133);
         this.rbImgResModeTgtLongerSide.Name = "rbImgResModeTgtLongerSide";
         this.rbImgResModeTgtLongerSide.Size = new System.Drawing.Size(115, 17);
         this.rbImgResModeTgtLongerSide.TabIndex = 0;
         this.rbImgResModeTgtLongerSide.Text = "Longer side length:";
         this.rbImgResModeTgtLongerSide.UseVisualStyleBackColor = true;
         // 
         // rbImgResModeTgtSize
         // 
         this.rbImgResModeTgtSize.AutoSize = true;
         this.rbImgResModeTgtSize.Checked = true;
         this.rbImgResModeTgtSize.Location = new System.Drawing.Point(6, 94);
         this.rbImgResModeTgtSize.Name = "rbImgResModeTgtSize";
         this.rbImgResModeTgtSize.Size = new System.Drawing.Size(76, 17);
         this.rbImgResModeTgtSize.TabIndex = 0;
         this.rbImgResModeTgtSize.TabStop = true;
         this.rbImgResModeTgtSize.Text = "Exact size:";
         this.rbImgResModeTgtSize.UseVisualStyleBackColor = true;
         // 
         // rbImgResModeTgtMegapixels
         // 
         this.rbImgResModeTgtMegapixels.AutoSize = true;
         this.rbImgResModeTgtMegapixels.Location = new System.Drawing.Point(6, 68);
         this.rbImgResModeTgtMegapixels.Name = "rbImgResModeTgtMegapixels";
         this.rbImgResModeTgtMegapixels.Size = new System.Drawing.Size(121, 17);
         this.rbImgResModeTgtMegapixels.TabIndex = 0;
         this.rbImgResModeTgtMegapixels.Text = "Wanted megapixels:";
         this.rbImgResModeTgtMegapixels.UseVisualStyleBackColor = true;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(269, 224);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(33, 13);
         this.label8.TabIndex = 16;
         this.label8.Text = "100%";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(6, 223);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(27, 13);
         this.label7.TabIndex = 16;
         this.label7.Text = "50%";
         // 
         // tbJpegQuality
         // 
         this.tbJpegQuality.Location = new System.Drawing.Point(6, 191);
         this.tbJpegQuality.Name = "tbJpegQuality";
         this.tbJpegQuality.Size = new System.Drawing.Size(287, 45);
         this.tbJpegQuality.TabIndex = 15;
         this.tbJpegQuality.Value = 1;
         // 
         // btnSaveAsNewProfile
         // 
         this.btnSaveAsNewProfile.Location = new System.Drawing.Point(322, 91);
         this.btnSaveAsNewProfile.Name = "btnSaveAsNewProfile";
         this.btnSaveAsNewProfile.Size = new System.Drawing.Size(128, 23);
         this.btnSaveAsNewProfile.TabIndex = 3;
         this.btnSaveAsNewProfile.Text = "Save as new profile...";
         this.btnSaveAsNewProfile.UseVisualStyleBackColor = true;
         this.btnSaveAsNewProfile.Click += new System.EventHandler(this.btnSaveAsNewProfile_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.rbVideoModeResize);
         this.groupBox2.Controls.Add(this.rbVideoModeCopy);
         this.groupBox2.Controls.Add(this.rbVideoModeSkip);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Controls.Add(this.cbVideoBitrate);
         this.groupBox2.Controls.Add(this.cbVideoResolution);
         this.groupBox2.Location = new System.Drawing.Point(12, 281);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(438, 122);
         this.groupBox2.TabIndex = 5;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Video resize options";
         // 
         // rbVideoModeResize
         // 
         this.rbVideoModeResize.AutoSize = true;
         this.rbVideoModeResize.Location = new System.Drawing.Point(6, 66);
         this.rbVideoModeResize.Name = "rbVideoModeResize";
         this.rbVideoModeResize.Size = new System.Drawing.Size(107, 17);
         this.rbVideoModeResize.TabIndex = 13;
         this.rbVideoModeResize.Text = "Resize video files";
         this.rbVideoModeResize.UseVisualStyleBackColor = true;
         // 
         // rbVideoModeCopy
         // 
         this.rbVideoModeCopy.AutoSize = true;
         this.rbVideoModeCopy.Location = new System.Drawing.Point(6, 43);
         this.rbVideoModeCopy.Name = "rbVideoModeCopy";
         this.rbVideoModeCopy.Size = new System.Drawing.Size(99, 17);
         this.rbVideoModeCopy.TabIndex = 13;
         this.rbVideoModeCopy.Text = "Copy video files";
         this.rbVideoModeCopy.UseVisualStyleBackColor = true;
         // 
         // rbVideoModeSkip
         // 
         this.rbVideoModeSkip.AutoSize = true;
         this.rbVideoModeSkip.Checked = true;
         this.rbVideoModeSkip.Location = new System.Drawing.Point(6, 20);
         this.rbVideoModeSkip.Name = "rbVideoModeSkip";
         this.rbVideoModeSkip.Size = new System.Drawing.Size(96, 17);
         this.rbVideoModeSkip.TabIndex = 13;
         this.rbVideoModeSkip.TabStop = true;
         this.rbVideoModeSkip.Text = "Skip video files";
         this.rbVideoModeSkip.UseVisualStyleBackColor = true;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(224, 94);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(32, 13);
         this.label5.TabIndex = 12;
         this.label5.Text = "Mb/s";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(144, 94);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(40, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Bitrate:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(6, 94);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(60, 13);
         this.label6.TabIndex = 11;
         this.label6.Text = "Resolution:";
         // 
         // cbVideoBitrate
         // 
         this.cbVideoBitrate.FormattingEnabled = true;
         this.cbVideoBitrate.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
         this.cbVideoBitrate.Location = new System.Drawing.Point(186, 91);
         this.cbVideoBitrate.Name = "cbVideoBitrate";
         this.cbVideoBitrate.Size = new System.Drawing.Size(35, 21);
         this.cbVideoBitrate.TabIndex = 8;
         this.cbVideoBitrate.Text = "3";
         // 
         // cbVideoResolution
         // 
         this.cbVideoResolution.FormattingEnabled = true;
         this.cbVideoResolution.Items.AddRange(new object[] {
            "320",
            "480",
            "720",
            "1080"});
         this.cbVideoResolution.Location = new System.Drawing.Point(72, 91);
         this.cbVideoResolution.Name = "cbVideoResolution";
         this.cbVideoResolution.Size = new System.Drawing.Size(66, 21);
         this.cbVideoResolution.TabIndex = 9;
         this.cbVideoResolution.Text = "720";
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.textBox3);
         this.groupBox3.Controls.Add(this.label10);
         this.groupBox3.Controls.Add(this.tbOtherFileExtFilter);
         this.groupBox3.Controls.Add(this.cbCopyOtherFiles);
         this.groupBox3.Location = new System.Drawing.Point(12, 409);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(438, 89);
         this.groupBox3.TabIndex = 6;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Other files";
         // 
         // textBox3
         // 
         this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.textBox3.Location = new System.Drawing.Point(136, 43);
         this.textBox3.Multiline = true;
         this.textBox3.Name = "textBox3";
         this.textBox3.ReadOnly = true;
         this.textBox3.Size = new System.Drawing.Size(296, 40);
         this.textBox3.TabIndex = 7;
         this.textBox3.Text = "Example: \"raw,arw\", keep it empty if you dont want to use extension filtering. Wh" +
    "en enabled only the files with these extensions will be copied.";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(133, 20);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(96, 13);
         this.label10.TabIndex = 2;
         this.label10.Text = "File extension filter:";
         // 
         // tbOtherFileExtFilter
         // 
         this.tbOtherFileExtFilter.Location = new System.Drawing.Point(235, 17);
         this.tbOtherFileExtFilter.Name = "tbOtherFileExtFilter";
         this.tbOtherFileExtFilter.Size = new System.Drawing.Size(197, 20);
         this.tbOtherFileExtFilter.TabIndex = 1;
         // 
         // cbCopyOtherFiles
         // 
         this.cbCopyOtherFiles.AutoSize = true;
         this.cbCopyOtherFiles.Location = new System.Drawing.Point(9, 19);
         this.cbCopyOtherFiles.Name = "cbCopyOtherFiles";
         this.cbCopyOtherFiles.Size = new System.Drawing.Size(98, 17);
         this.cbCopyOtherFiles.TabIndex = 0;
         this.cbCopyOtherFiles.Text = "Copy other files";
         this.cbCopyOtherFiles.UseVisualStyleBackColor = true;
         // 
         // textBox1
         // 
         this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.textBox1.Location = new System.Drawing.Point(323, 121);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.ReadOnly = true;
         this.textBox1.Size = new System.Drawing.Size(127, 49);
         this.textBox1.TabIndex = 7;
         this.textBox1.Text = "Dont forget to save or overwrite your changes before closing this window.";
         // 
         // ConvProfileOptionsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(462, 510);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnSaveAsNewProfile);
         this.Controls.Add(this.btnOverwriteProfile);
         this.Controls.Add(this.btnLoadSelectedProfile);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cbExistingProfiles);
         this.Name = "ConvProfileOptionsForm";
         this.Text = "ConversionProfileOptions";
         this.Load += new System.EventHandler(this.ConvProfileOptionsForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tbJpegQuality)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox cbExistingProfiles;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnLoadSelectedProfile;
      private System.Windows.Forms.Button btnOverwriteProfile;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox cbIncreaseSizeWhenSmaller;
      private System.Windows.Forms.RadioButton rbImgResModeTgtLongerSide;
      private System.Windows.Forms.RadioButton rbImgResModeTgtSize;
      private System.Windows.Forms.RadioButton rbImgResModeTgtMegapixels;
      private System.Windows.Forms.TextBox tbWantedMegapixels;
      private System.Windows.Forms.Button btnSaveAsNewProfile;
      private System.Windows.Forms.TextBox tbExactSizeH;
      private System.Windows.Forms.TextBox tbExactSizeW;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox tbLongerSideSize;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox cbVideoBitrate;
      private System.Windows.Forms.ComboBox cbVideoResolution;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox cbCopyOtherFiles;
      private System.Windows.Forms.RadioButton rbVideoModeResize;
      private System.Windows.Forms.RadioButton rbVideoModeCopy;
      private System.Windows.Forms.RadioButton rbVideoModeSkip;
      private System.Windows.Forms.RadioButton rbImgResModeSkip;
      private System.Windows.Forms.RadioButton rbImgResModeCopy;
      private System.Windows.Forms.TrackBar tbJpegQuality;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox tbOtherFileExtFilter;
      private System.Windows.Forms.TextBox textBox3;
      private System.Windows.Forms.Label label10;
   }
}