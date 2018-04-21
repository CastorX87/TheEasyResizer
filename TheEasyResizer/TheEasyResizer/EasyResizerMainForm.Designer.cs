namespace TheEasyResizer
{
   partial class EasyResizerMainForm
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
         this.lbInputFiles = new System.Windows.Forms.ListBox();
         this.label1 = new System.Windows.Forms.Label();
         this.sbMainWindow = new System.Windows.Forms.StatusStrip();
         this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.btnRemoveSelFiles = new System.Windows.Forms.Button();
         this.btnShowOptions = new System.Windows.Forms.Button();
         this.cbSelectedCOnversionProfile = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.cbEnableMultithreading = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         this.tbOutDir = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.cbCreateSubdirs = new System.Windows.Forms.CheckBox();
         this.btnStartConversion = new System.Windows.Forms.Button();
         this.btnBrowseOutDir = new System.Windows.Forms.Button();
         this.tbRootPath = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.tbExampleOutput = new System.Windows.Forms.TextBox();
         this.cbTopmostDirOnly = new System.Windows.Forms.CheckBox();
         this.cbExistFileHandlMode = new System.Windows.Forms.ComboBox();
         this.label10 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.tbPathFfmpeg = new System.Windows.Forms.TextBox();
         this.btnBrowseFfmpegPath = new System.Windows.Forms.Button();
         this.ffmpegMessage = new System.Windows.Forms.Label();
         this.ffmpegLinkLabel = new System.Windows.Forms.LinkLabel();
         this.sbMainWindow.SuspendLayout();
         this.SuspendLayout();
         // 
         // lbInputFiles
         // 
         this.lbInputFiles.AllowDrop = true;
         this.lbInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lbInputFiles.FormattingEnabled = true;
         this.lbInputFiles.Location = new System.Drawing.Point(12, 25);
         this.lbInputFiles.Name = "lbInputFiles";
         this.lbInputFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this.lbInputFiles.Size = new System.Drawing.Size(539, 147);
         this.lbInputFiles.Sorted = true;
         this.lbInputFiles.TabIndex = 0;
         this.lbInputFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbInputFiles_DragDrop);
         this.lbInputFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbInputFiles_DragEnter);
         this.lbInputFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbInputFiles_MouseDown);
         this.lbInputFiles.Move += new System.EventHandler(this.lbInputFiles_Move);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(9, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(138, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "List of input files/directories:";
         // 
         // sbMainWindow
         // 
         this.sbMainWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
         this.sbMainWindow.Location = new System.Drawing.Point(0, 556);
         this.sbMainWindow.Name = "sbMainWindow";
         this.sbMainWindow.Size = new System.Drawing.Size(563, 22);
         this.sbMainWindow.TabIndex = 2;
         this.sbMainWindow.Text = "The Easy Resizer";
         // 
         // toolStripProgressBar1
         // 
         this.toolStripProgressBar1.Name = "toolStripProgressBar1";
         this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 17);
         this.toolStripStatusLabel1.Text = "The Easy Resizer";
         // 
         // btnRemoveSelFiles
         // 
         this.btnRemoveSelFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.btnRemoveSelFiles.Location = new System.Drawing.Point(12, 176);
         this.btnRemoveSelFiles.Name = "btnRemoveSelFiles";
         this.btnRemoveSelFiles.Size = new System.Drawing.Size(539, 23);
         this.btnRemoveSelFiles.TabIndex = 3;
         this.btnRemoveSelFiles.Text = "Remove selected files/directories";
         this.btnRemoveSelFiles.UseVisualStyleBackColor = true;
         this.btnRemoveSelFiles.Click += new System.EventHandler(this.btnRemoveSelFiles_Click);
         // 
         // btnShowOptions
         // 
         this.btnShowOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnShowOptions.Location = new System.Drawing.Point(458, 309);
         this.btnShowOptions.Name = "btnShowOptions";
         this.btnShowOptions.Size = new System.Drawing.Size(98, 23);
         this.btnShowOptions.TabIndex = 4;
         this.btnShowOptions.Text = "Options...";
         this.btnShowOptions.UseVisualStyleBackColor = true;
         this.btnShowOptions.Click += new System.EventHandler(this.btnShowOptions_Click);
         // 
         // cbSelectedCOnversionProfile
         // 
         this.cbSelectedCOnversionProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cbSelectedCOnversionProfile.FormattingEnabled = true;
         this.cbSelectedCOnversionProfile.Location = new System.Drawing.Point(198, 311);
         this.cbSelectedCOnversionProfile.Name = "cbSelectedCOnversionProfile";
         this.cbSelectedCOnversionProfile.Size = new System.Drawing.Size(254, 21);
         this.cbSelectedCOnversionProfile.TabIndex = 5;
         this.cbSelectedCOnversionProfile.TextChanged += new System.EventHandler(this.cbSelectedCOnversionProfile_TextChanged);
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(54, 314);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(138, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Selected conversion profile:";
         // 
         // cbEnableMultithreading
         // 
         this.cbEnableMultithreading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cbEnableMultithreading.AutoSize = true;
         this.cbEnableMultithreading.Location = new System.Drawing.Point(198, 367);
         this.cbEnableMultithreading.Name = "cbEnableMultithreading";
         this.cbEnableMultithreading.Size = new System.Drawing.Size(59, 17);
         this.cbEnableMultithreading.TabIndex = 7;
         this.cbEnableMultithreading.Text = "Enable";
         this.cbEnableMultithreading.UseVisualStyleBackColor = true;
         // 
         // label3
         // 
         this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(107, 340);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(85, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Output directory:";
         // 
         // tbOutDir
         // 
         this.tbOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.tbOutDir.Location = new System.Drawing.Point(198, 337);
         this.tbOutDir.Name = "tbOutDir";
         this.tbOutDir.Size = new System.Drawing.Size(254, 20);
         this.tbOutDir.TabIndex = 9;
         this.tbOutDir.Text = "C:\\Resized";
         this.tbOutDir.TextChanged += new System.EventHandler(this.tbOutDir_TextChanged);
         // 
         // label4
         // 
         this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(85, 368);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(107, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Multicore processing:";
         // 
         // label5
         // 
         this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.label5.Location = new System.Drawing.Point(254, 368);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(122, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "(Causes high CPU load.)";
         // 
         // label6
         // 
         this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(99, 392);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(93, 13);
         this.label6.TabIndex = 12;
         this.label6.Text = "Output directories:";
         // 
         // cbCreateSubdirs
         // 
         this.cbCreateSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cbCreateSubdirs.AutoSize = true;
         this.cbCreateSubdirs.Location = new System.Drawing.Point(198, 391);
         this.cbCreateSubdirs.Name = "cbCreateSubdirs";
         this.cbCreateSubdirs.Size = new System.Drawing.Size(195, 17);
         this.cbCreateSubdirs.TabIndex = 13;
         this.cbCreateSubdirs.Text = "Create subdirectories on output side";
         this.cbCreateSubdirs.UseVisualStyleBackColor = true;
         this.cbCreateSubdirs.CheckedChanged += new System.EventHandler(this.cbCreateSubdirs_CheckedChanged);
         // 
         // btnStartConversion
         // 
         this.btnStartConversion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnStartConversion.BackColor = System.Drawing.Color.PaleTurquoise;
         this.btnStartConversion.Location = new System.Drawing.Point(12, 510);
         this.btnStartConversion.Name = "btnStartConversion";
         this.btnStartConversion.Size = new System.Drawing.Size(544, 43);
         this.btnStartConversion.TabIndex = 14;
         this.btnStartConversion.Text = "START CONVERSION";
         this.btnStartConversion.UseVisualStyleBackColor = false;
         this.btnStartConversion.Click += new System.EventHandler(this.btnStartConversion_Click);
         // 
         // btnBrowseOutDir
         // 
         this.btnBrowseOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnBrowseOutDir.Location = new System.Drawing.Point(458, 337);
         this.btnBrowseOutDir.Name = "btnBrowseOutDir";
         this.btnBrowseOutDir.Size = new System.Drawing.Size(98, 23);
         this.btnBrowseOutDir.TabIndex = 15;
         this.btnBrowseOutDir.Text = "Browse...";
         this.btnBrowseOutDir.UseVisualStyleBackColor = true;
         this.btnBrowseOutDir.Click += new System.EventHandler(this.btnBrowseOutDir_Click);
         // 
         // tbRootPath
         // 
         this.tbRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbRootPath.Location = new System.Drawing.Point(12, 220);
         this.tbRootPath.Name = "tbRootPath";
         this.tbRootPath.ReadOnly = true;
         this.tbRootPath.Size = new System.Drawing.Size(539, 20);
         this.tbRootPath.TabIndex = 16;
         // 
         // label7
         // 
         this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(12, 204);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(146, 13);
         this.label7.TabIndex = 17;
         this.label7.Text = "Path that will be used as root:";
         // 
         // label8
         // 
         this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label8.AutoSize = true;
         this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.label8.Location = new System.Drawing.Point(9, 245);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(553, 13);
         this.label8.TabIndex = 18;
         this.label8.Text = "This path will be will be replaced on output side with the Output dir. when \"Crea" +
    "te input dir. on out. side\" is checked.";
         // 
         // label9
         // 
         this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(12, 267);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(200, 13);
         this.label9.TabIndex = 17;
         this.label9.Text = "Output of selected file with current setup:";
         // 
         // tbExampleOutput
         // 
         this.tbExampleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tbExampleOutput.Location = new System.Drawing.Point(12, 283);
         this.tbExampleOutput.Name = "tbExampleOutput";
         this.tbExampleOutput.ReadOnly = true;
         this.tbExampleOutput.Size = new System.Drawing.Size(539, 20);
         this.tbExampleOutput.TabIndex = 16;
         // 
         // cbTopmostDirOnly
         // 
         this.cbTopmostDirOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cbTopmostDirOnly.AutoSize = true;
         this.cbTopmostDirOnly.Enabled = false;
         this.cbTopmostDirOnly.Location = new System.Drawing.Point(198, 414);
         this.cbTopmostDirOnly.Name = "cbTopmostDirOnly";
         this.cbTopmostDirOnly.Size = new System.Drawing.Size(162, 17);
         this.cbTopmostDirOnly.TabIndex = 19;
         this.cbTopmostDirOnly.Text = "Create topmost directory only";
         this.cbTopmostDirOnly.UseVisualStyleBackColor = true;
         this.cbTopmostDirOnly.CheckedChanged += new System.EventHandler(this.cbTopmostDirOnly_CheckedChanged);
         // 
         // cbExistFileHandlMode
         // 
         this.cbExistFileHandlMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cbExistFileHandlMode.FormattingEnabled = true;
         this.cbExistFileHandlMode.Items.AddRange(new object[] {
            "Skip file if already existing in output path",
            "Append/increase index at end of file name",
            "Overwrite existing files"});
         this.cbExistFileHandlMode.Location = new System.Drawing.Point(198, 437);
         this.cbExistFileHandlMode.Name = "cbExistFileHandlMode";
         this.cbExistFileHandlMode.Size = new System.Drawing.Size(254, 21);
         this.cbExistFileHandlMode.TabIndex = 20;
         this.cbExistFileHandlMode.Text = "Skip file if already existing in output path";
         // 
         // label10
         // 
         this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(32, 440);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(160, 13);
         this.label10.TabIndex = 21;
         this.label10.Text = "Handling of already existing files:";
         // 
         // label11
         // 
         this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(99, 467);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(90, 13);
         this.label11.TabIndex = 12;
         this.label11.Text = "Path of FFMPEG:";
         // 
         // tbPathFfmpeg
         // 
         this.tbPathFfmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.tbPathFfmpeg.BackColor = System.Drawing.Color.OldLace;
         this.tbPathFfmpeg.Location = new System.Drawing.Point(198, 464);
         this.tbPathFfmpeg.Name = "tbPathFfmpeg";
         this.tbPathFfmpeg.Size = new System.Drawing.Size(254, 20);
         this.tbPathFfmpeg.TabIndex = 9;
         this.tbPathFfmpeg.Text = "C:\\ffmpeg";
         this.tbPathFfmpeg.TextChanged += new System.EventHandler(this.tbPathFfmpeg_TextChanged);
         // 
         // btnBrowseFfmpegPath
         // 
         this.btnBrowseFfmpegPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnBrowseFfmpegPath.Location = new System.Drawing.Point(458, 462);
         this.btnBrowseFfmpegPath.Name = "btnBrowseFfmpegPath";
         this.btnBrowseFfmpegPath.Size = new System.Drawing.Size(98, 23);
         this.btnBrowseFfmpegPath.TabIndex = 22;
         this.btnBrowseFfmpegPath.Text = "Browse...";
         this.btnBrowseFfmpegPath.UseVisualStyleBackColor = true;
         this.btnBrowseFfmpegPath.Click += new System.EventHandler(this.btnBrowseFfmpegPath_Click);
         // 
         // ffmpegMessage
         // 
         this.ffmpegMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.ffmpegMessage.AutoSize = true;
         this.ffmpegMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.ffmpegMessage.ForeColor = System.Drawing.Color.Indigo;
         this.ffmpegMessage.Location = new System.Drawing.Point(5, 488);
         this.ffmpegMessage.Name = "ffmpegMessage";
         this.ffmpegMessage.Size = new System.Drawing.Size(381, 13);
         this.ffmpegMessage.TabIndex = 18;
         this.ffmpegMessage.Text = "This application requires ffmepg to  resize/convert video files. Downloadable at " +
    "";
         // 
         // ffmpegLinkLabel
         // 
         this.ffmpegLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.ffmpegLinkLabel.AutoSize = true;
         this.ffmpegLinkLabel.Location = new System.Drawing.Point(380, 488);
         this.ffmpegLinkLabel.Name = "ffmpegLinkLabel";
         this.ffmpegLinkLabel.Size = new System.Drawing.Size(176, 13);
         this.ffmpegLinkLabel.TabIndex = 23;
         this.ffmpegLinkLabel.TabStop = true;
         this.ffmpegLinkLabel.Text = "https://ffmpeg.zeranoe.com/builds/";
         this.ffmpegLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ffmpegLinkLabel_LinkClicked);
         // 
         // EasyResizerMainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(563, 578);
         this.Controls.Add(this.ffmpegLinkLabel);
         this.Controls.Add(this.btnBrowseFfmpegPath);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.cbExistFileHandlMode);
         this.Controls.Add(this.cbTopmostDirOnly);
         this.Controls.Add(this.ffmpegMessage);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.tbExampleOutput);
         this.Controls.Add(this.tbRootPath);
         this.Controls.Add(this.btnBrowseOutDir);
         this.Controls.Add(this.btnStartConversion);
         this.Controls.Add(this.cbCreateSubdirs);
         this.Controls.Add(this.label11);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.tbPathFfmpeg);
         this.Controls.Add(this.tbOutDir);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.cbEnableMultithreading);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.cbSelectedCOnversionProfile);
         this.Controls.Add(this.btnShowOptions);
         this.Controls.Add(this.btnRemoveSelFiles);
         this.Controls.Add(this.sbMainWindow);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.lbInputFiles);
         this.Name = "EasyResizerMainForm";
         this.Text = "The Easy Resizer";
         this.Load += new System.EventHandler(this.EasyResizerMainForm_Load);
         this.sbMainWindow.ResumeLayout(false);
         this.sbMainWindow.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox lbInputFiles;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.StatusStrip sbMainWindow;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
      private System.Windows.Forms.Button btnRemoveSelFiles;
      private System.Windows.Forms.Button btnShowOptions;
      private System.Windows.Forms.ComboBox cbSelectedCOnversionProfile;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox cbEnableMultithreading;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox tbOutDir;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.CheckBox cbCreateSubdirs;
      private System.Windows.Forms.Button btnStartConversion;
      private System.Windows.Forms.Button btnBrowseOutDir;
      private System.Windows.Forms.TextBox tbRootPath;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox tbExampleOutput;
      private System.Windows.Forms.CheckBox cbTopmostDirOnly;
      private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
      private System.Windows.Forms.ComboBox cbExistFileHandlMode;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.TextBox tbPathFfmpeg;
      private System.Windows.Forms.Button btnBrowseFfmpegPath;
      private System.Windows.Forms.Label ffmpegMessage;
      private System.Windows.Forms.LinkLabel ffmpegLinkLabel;
   }
}

