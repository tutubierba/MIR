﻿using System;

namespace LibraryEditor
{
    partial class LMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LMain));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countBlanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBlanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.populateFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultMonsterFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultNPCFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultPlayerFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autofillFromCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RButtonOverlay = new System.Windows.Forms.RadioButton();
            this.RButtonImage = new System.Windows.Forms.RadioButton();
            this.checkboxRemoveBlackOnImport = new System.Windows.Forms.CheckBox();
            this.nudJump = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPreventAntiAliasing = new System.Windows.Forms.CheckBox();
            this.checkBoxQuality = new System.Windows.Forms.CheckBox();
            this.buttonSkipPrevious = new System.Windows.Forms.Button();
            this.buttonSkipNext = new System.Windows.Forms.Button();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.ExportButton = new System.Windows.Forms.Button();
            this.InsertImageButton = new System.Windows.Forms.Button();
            this.OffSetYTextBox = new System.Windows.Forms.TextBox();
            this.OffSetXTextBox = new System.Windows.Forms.TextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabImages = new System.Windows.Forms.TabPage();
            this.PreviewListView = new CustomFormControl.FixedListView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabFrames = new System.Windows.Forms.TabPage();
            this.frameGridView = new System.Windows.Forms.DataGridView();
            this.FrameAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FrameStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameSkip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameEffectStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameEffectCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameEffectSkip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameEffectInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameReverse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FrameBlend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OpenLibraryDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveLibraryDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImportImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenWeMadeDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.FolderLibraryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FrameAnimTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabImages.SuspendLayout();
            this.tabFrames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.functionsToolStripMenuItem,
            this.skinToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(1036, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "新建";
            this.newToolStripMenuItem.ToolTipText = "New .Lib";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "打开";
            this.openToolStripMenuItem.ToolTipText = "Open Shanda or Wemade files.";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.ToolTipText = "Saves currently open .Lib";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "另存为";
            this.saveAsToolStripMenuItem.ToolTipText = ".Lib Only.";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "关闭";
            this.closeToolStripMenuItem.ToolTipText = "Exit Application.";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToToolStripMenuItem,
            this.countBlanksToolStripMenuItem,
            this.removeBlanksToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.populateFramesToolStripMenuItem});
            this.functionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("functionsToolStripMenuItem.Image")));
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.functionsToolStripMenuItem.Text = "功能";
            // 
            // copyToToolStripMenuItem
            // 
            this.copyToToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToToolStripMenuItem.Image")));
            this.copyToToolStripMenuItem.Name = "copyToToolStripMenuItem";
            this.copyToToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToToolStripMenuItem.Text = "复制";
            this.copyToToolStripMenuItem.ToolTipText = "Copy to a new .Lib or to the end of an exsisting one.";
            this.copyToToolStripMenuItem.Click += new System.EventHandler(this.copyToToolStripMenuItem_Click);
            // 
            // countBlanksToolStripMenuItem
            // 
            this.countBlanksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("countBlanksToolStripMenuItem.Image")));
            this.countBlanksToolStripMenuItem.Name = "countBlanksToolStripMenuItem";
            this.countBlanksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.countBlanksToolStripMenuItem.Text = "计数空白";
            this.countBlanksToolStripMenuItem.ToolTipText = "Counts the blank images in the .Lib";
            this.countBlanksToolStripMenuItem.Click += new System.EventHandler(this.countBlanksToolStripMenuItem_Click);
            // 
            // removeBlanksToolStripMenuItem
            // 
            this.removeBlanksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.safeToolStripMenuItem});
            this.removeBlanksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeBlanksToolStripMenuItem.Image")));
            this.removeBlanksToolStripMenuItem.Name = "removeBlanksToolStripMenuItem";
            this.removeBlanksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeBlanksToolStripMenuItem.Text = "删除空白";
            this.removeBlanksToolStripMenuItem.ToolTipText = "Quick removal of blanks.";
            this.removeBlanksToolStripMenuItem.Click += new System.EventHandler(this.removeBlanksToolStripMenuItem_Click);
            // 
            // safeToolStripMenuItem
            // 
            this.safeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("safeToolStripMenuItem.Image")));
            this.safeToolStripMenuItem.Name = "safeToolStripMenuItem";
            this.safeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.safeToolStripMenuItem.Text = "安全";
            this.safeToolStripMenuItem.ToolTipText = "Use the safe method of removing blanks.";
            this.safeToolStripMenuItem.Click += new System.EventHandler(this.safeToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("convertToolStripMenuItem.Image")));
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertToolStripMenuItem.Text = "转换素材";
            this.convertToolStripMenuItem.ToolTipText = "Convert Wil/Wzl/Miz to .Lib";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // populateFramesToolStripMenuItem
            // 
            this.populateFramesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultMonsterFramesToolStripMenuItem,
            this.defaultNPCFramesToolStripMenuItem,
            this.defaultPlayerFramesToolStripMenuItem,
            this.autofillFromCodeToolStripMenuItem});
            this.populateFramesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("populateFramesToolStripMenuItem.Image")));
            this.populateFramesToolStripMenuItem.Name = "populateFramesToolStripMenuItem";
            this.populateFramesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.populateFramesToolStripMenuItem.Text = "填充帧";
            // 
            // defaultMonsterFramesToolStripMenuItem
            // 
            this.defaultMonsterFramesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("defaultMonsterFramesToolStripMenuItem.Image")));
            this.defaultMonsterFramesToolStripMenuItem.Name = "defaultMonsterFramesToolStripMenuItem";
            this.defaultMonsterFramesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defaultMonsterFramesToolStripMenuItem.Text = "默认怪物帧";
            this.defaultMonsterFramesToolStripMenuItem.Click += new System.EventHandler(this.defaultMonsterFramesToolStripMenuItem_Click);
            // 
            // defaultNPCFramesToolStripMenuItem
            // 
            this.defaultNPCFramesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("defaultNPCFramesToolStripMenuItem.Image")));
            this.defaultNPCFramesToolStripMenuItem.Name = "defaultNPCFramesToolStripMenuItem";
            this.defaultNPCFramesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defaultNPCFramesToolStripMenuItem.Text = "默认NPC帧";
            this.defaultNPCFramesToolStripMenuItem.Click += new System.EventHandler(this.defaultNPCFramesToolStripMenuItem_Click);
            // 
            // defaultPlayerFramesToolStripMenuItem
            // 
            this.defaultPlayerFramesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("defaultPlayerFramesToolStripMenuItem.Image")));
            this.defaultPlayerFramesToolStripMenuItem.Name = "defaultPlayerFramesToolStripMenuItem";
            this.defaultPlayerFramesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defaultPlayerFramesToolStripMenuItem.Text = "默认播放器帧";
            this.defaultPlayerFramesToolStripMenuItem.Click += new System.EventHandler(this.defaultPlayerFramesToolStripMenuItem_Click);
            // 
            // autofillFromCodeToolStripMenuItem
            // 
            this.autofillFromCodeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("autofillFromCodeToolStripMenuItem.Image")));
            this.autofillFromCodeToolStripMenuItem.Name = "autofillFromCodeToolStripMenuItem";
            this.autofillFromCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autofillFromCodeToolStripMenuItem.Text = "从代码自动填充";
            this.autofillFromCodeToolStripMenuItem.Click += new System.EventHandler(this.autofillNpcFramesToolStripMenuItem_Click);
            // 
            // skinToolStripMenuItem
            // 
            this.skinToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.skinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("skinToolStripMenuItem.Image")));
            this.skinToolStripMenuItem.Name = "skinToolStripMenuItem";
            this.skinToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.skinToolStripMenuItem.Text = "Skin";
            this.skinToolStripMenuItem.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 325;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1036, 627);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.checkboxRemoveBlackOnImport);
            this.splitContainer2.Panel1.Controls.Add(this.nudJump);
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxPreventAntiAliasing);
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxQuality);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSkipPrevious);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSkipNext);
            this.splitContainer2.Panel1.Controls.Add(this.buttonReplace);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox);
            this.splitContainer2.Panel1.Controls.Add(this.ZoomTrackBar);
            this.splitContainer2.Panel1.Controls.Add(this.ExportButton);
            this.splitContainer2.Panel1.Controls.Add(this.InsertImageButton);
            this.splitContainer2.Panel1.Controls.Add(this.OffSetYTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.OffSetXTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.DeleteButton);
            this.splitContainer2.Panel1.Controls.Add(this.AddButton);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.HeightLabel);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.WidthLabel);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.ForeColor = System.Drawing.Color.Black;
            this.splitContainer2.Panel1MinSize = 240;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel);
            this.splitContainer2.Size = new System.Drawing.Size(1036, 357);
            this.splitContainer2.SplitterDistance = 240;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RButtonOverlay);
            this.groupBox1.Controls.Add(this.RButtonImage);
            this.groupBox1.Location = new System.Drawing.Point(11, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 35);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看模式";
            // 
            // RButtonOverlay
            // 
            this.RButtonOverlay.AutoSize = true;
            this.RButtonOverlay.Location = new System.Drawing.Point(68, 14);
            this.RButtonOverlay.Name = "RButtonOverlay";
            this.RButtonOverlay.Size = new System.Drawing.Size(47, 16);
            this.RButtonOverlay.TabIndex = 1;
            this.RButtonOverlay.Text = "覆盖";
            this.RButtonOverlay.UseVisualStyleBackColor = true;
            this.RButtonOverlay.CheckedChanged += new System.EventHandler(this.RButtonViewMode_CheckedChanged);
            // 
            // RButtonImage
            // 
            this.RButtonImage.AutoSize = true;
            this.RButtonImage.Checked = true;
            this.RButtonImage.Location = new System.Drawing.Point(7, 14);
            this.RButtonImage.Name = "RButtonImage";
            this.RButtonImage.Size = new System.Drawing.Size(47, 16);
            this.RButtonImage.TabIndex = 0;
            this.RButtonImage.TabStop = true;
            this.RButtonImage.Text = "图像";
            this.RButtonImage.UseVisualStyleBackColor = true;
            this.RButtonImage.CheckedChanged += new System.EventHandler(this.RButtonViewMode_CheckedChanged);
            // 
            // checkboxRemoveBlackOnImport
            // 
            this.checkboxRemoveBlackOnImport.AutoSize = true;
            this.checkboxRemoveBlackOnImport.Checked = true;
            this.checkboxRemoveBlackOnImport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxRemoveBlackOnImport.Location = new System.Drawing.Point(11, 308);
            this.checkboxRemoveBlackOnImport.Name = "checkboxRemoveBlackOnImport";
            this.checkboxRemoveBlackOnImport.Size = new System.Drawing.Size(96, 16);
            this.checkboxRemoveBlackOnImport.TabIndex = 22;
            this.checkboxRemoveBlackOnImport.Text = "导入时去黑色";
            this.checkboxRemoveBlackOnImport.UseVisualStyleBackColor = true;
            // 
            // nudJump
            // 
            this.nudJump.Location = new System.Drawing.Point(77, 202);
            this.nudJump.Maximum = new decimal(new int[] {
            650000,
            0,
            0,
            0});
            this.nudJump.Name = "nudJump";
            this.nudJump.Size = new System.Drawing.Size(77, 21);
            this.nudJump.TabIndex = 21;
            this.nudJump.ValueChanged += new System.EventHandler(this.nudJump_ValueChanged);
            this.nudJump.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudJump_KeyDown);
            // 
            // checkBoxPreventAntiAliasing
            // 
            this.checkBoxPreventAntiAliasing.AutoSize = true;
            this.checkBoxPreventAntiAliasing.Location = new System.Drawing.Point(95, 330);
            this.checkBoxPreventAntiAliasing.Name = "checkBoxPreventAntiAliasing";
            this.checkBoxPreventAntiAliasing.Size = new System.Drawing.Size(72, 16);
            this.checkBoxPreventAntiAliasing.TabIndex = 20;
            this.checkBoxPreventAntiAliasing.Text = "无抗锯齿";
            this.checkBoxPreventAntiAliasing.UseVisualStyleBackColor = true;
            this.checkBoxPreventAntiAliasing.CheckedChanged += new System.EventHandler(this.checkBoxPreventAntiAliasing_CheckedChanged);
            // 
            // checkBoxQuality
            // 
            this.checkBoxQuality.AutoSize = true;
            this.checkBoxQuality.Location = new System.Drawing.Point(11, 330);
            this.checkBoxQuality.Name = "checkBoxQuality";
            this.checkBoxQuality.Size = new System.Drawing.Size(60, 16);
            this.checkBoxQuality.TabIndex = 19;
            this.checkBoxQuality.Text = "无模糊";
            this.checkBoxQuality.UseVisualStyleBackColor = true;
            this.checkBoxQuality.CheckedChanged += new System.EventHandler(this.checkBoxQuality_CheckedChanged);
            // 
            // buttonSkipPrevious
            // 
            this.buttonSkipPrevious.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSkipPrevious.Image = ((System.Drawing.Image)(resources.GetObject("buttonSkipPrevious.Image")));
            this.buttonSkipPrevious.Location = new System.Drawing.Point(42, 199);
            this.buttonSkipPrevious.Name = "buttonSkipPrevious";
            this.buttonSkipPrevious.Size = new System.Drawing.Size(30, 24);
            this.buttonSkipPrevious.TabIndex = 17;
            this.buttonSkipPrevious.Tag = "";
            this.buttonSkipPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSkipPrevious.UseVisualStyleBackColor = true;
            this.buttonSkipPrevious.Click += new System.EventHandler(this.buttonSkipPrevious_Click);
            // 
            // buttonSkipNext
            // 
            this.buttonSkipNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSkipNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonSkipNext.Image")));
            this.buttonSkipNext.Location = new System.Drawing.Point(159, 199);
            this.buttonSkipNext.Name = "buttonSkipNext";
            this.buttonSkipNext.Size = new System.Drawing.Size(30, 24);
            this.buttonSkipNext.TabIndex = 16;
            this.buttonSkipNext.Tag = "";
            this.buttonSkipNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSkipNext.UseVisualStyleBackColor = true;
            this.buttonSkipNext.Click += new System.EventHandler(this.buttonSkipNext_Click);
            // 
            // buttonReplace
            // 
            this.buttonReplace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReplace.Image = ((System.Drawing.Image)(resources.GetObject("buttonReplace.Image")));
            this.buttonReplace.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReplace.Location = new System.Drawing.Point(10, 133);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(105, 24);
            this.buttonReplace.TabIndex = 15;
            this.buttonReplace.Tag = "";
            this.buttonReplace.Text = "替换图像";
            this.buttonReplace.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(10, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(16, 16);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 14;
            this.pictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox, "Switch from Black to White background.");
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // ZoomTrackBar
            // 
            this.ZoomTrackBar.LargeChange = 1;
            this.ZoomTrackBar.Location = new System.Drawing.Point(42, 229);
            this.ZoomTrackBar.Minimum = 1;
            this.ZoomTrackBar.Name = "ZoomTrackBar";
            this.ZoomTrackBar.Size = new System.Drawing.Size(147, 45);
            this.ZoomTrackBar.TabIndex = 4;
            this.ZoomTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.ZoomTrackBar.Value = 1;
            this.ZoomTrackBar.Scroll += new System.EventHandler(this.ZoomTrackBar_Scroll);
            // 
            // ExportButton
            // 
            this.ExportButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ExportButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportButton.Image")));
            this.ExportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportButton.Location = new System.Drawing.Point(121, 162);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(105, 24);
            this.ExportButton.TabIndex = 3;
            this.ExportButton.Tag = "";
            this.ExportButton.Text = "导出图像";
            this.ExportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // InsertImageButton
            // 
            this.InsertImageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.InsertImageButton.Image = ((System.Drawing.Image)(resources.GetObject("InsertImageButton.Image")));
            this.InsertImageButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InsertImageButton.Location = new System.Drawing.Point(121, 133);
            this.InsertImageButton.Name = "InsertImageButton";
            this.InsertImageButton.Size = new System.Drawing.Size(105, 24);
            this.InsertImageButton.TabIndex = 1;
            this.InsertImageButton.Tag = "";
            this.InsertImageButton.Text = "插入图像";
            this.InsertImageButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.InsertImageButton.UseVisualStyleBackColor = true;
            this.InsertImageButton.Click += new System.EventHandler(this.InsertImageButton_Click);
            // 
            // OffSetYTextBox
            // 
            this.OffSetYTextBox.Location = new System.Drawing.Point(123, 70);
            this.OffSetYTextBox.Name = "OffSetYTextBox";
            this.OffSetYTextBox.Size = new System.Drawing.Size(65, 21);
            this.OffSetYTextBox.TabIndex = 6;
            this.OffSetYTextBox.TextChanged += new System.EventHandler(this.OffSetYTextBox_TextChanged);
            // 
            // OffSetXTextBox
            // 
            this.OffSetXTextBox.Location = new System.Drawing.Point(123, 46);
            this.OffSetXTextBox.Name = "OffSetXTextBox";
            this.OffSetXTextBox.Size = new System.Drawing.Size(65, 21);
            this.OffSetXTextBox.TabIndex = 5;
            this.OffSetXTextBox.TextChanged += new System.EventHandler(this.OffSetXTextBox_TextChanged);
            // 
            // DeleteButton
            // 
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteButton.Location = new System.Drawing.Point(121, 103);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(105, 24);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Tag = "";
            this.DeleteButton.Text = "删除图像";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.Location = new System.Drawing.Point(10, 103);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(105, 24);
            this.AddButton.TabIndex = 0;
            this.AddButton.Tag = "";
            this.AddButton.Text = "添加图像";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(67, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "偏移 Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(67, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "偏移 X:";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HeightLabel.Location = new System.Drawing.Point(123, 28);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(65, 12);
            this.HeightLabel.TabIndex = 10;
            this.HeightLabel.Text = "<没有图像>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(79, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "高度:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WidthLabel.Location = new System.Drawing.Point(123, 11);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(65, 12);
            this.WidthLabel.TabIndex = 8;
            this.WidthLabel.Text = "<没有图像>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(79, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "宽度:";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.ImageBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(790, 355);
            this.panel.TabIndex = 1;
            // 
            // ImageBox
            // 
            this.ImageBox.BackColor = System.Drawing.Color.Transparent;
            this.ImageBox.Location = new System.Drawing.Point(0, 0);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(64, 64);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabImages);
            this.tabControl.Controls.Add(this.tabFrames);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1034, 264);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabImages
            // 
            this.tabImages.Controls.Add(this.PreviewListView);
            this.tabImages.Location = new System.Drawing.Point(4, 22);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(1026, 238);
            this.tabImages.TabIndex = 0;
            this.tabImages.Text = "图像";
            this.tabImages.UseVisualStyleBackColor = true;
            // 
            // PreviewListView
            // 
            this.PreviewListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PreviewListView.BackColor = System.Drawing.Color.GhostWhite;
            this.PreviewListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(152)))), ((int)(((byte)(156)))));
            this.PreviewListView.HideSelection = false;
            this.PreviewListView.LargeImageList = this.ImageList;
            this.PreviewListView.Location = new System.Drawing.Point(3, 3);
            this.PreviewListView.Name = "PreviewListView";
            this.PreviewListView.Size = new System.Drawing.Size(1020, 232);
            this.PreviewListView.TabIndex = 0;
            this.PreviewListView.UseCompatibleStateImageBehavior = false;
            this.PreviewListView.VirtualMode = true;
            this.PreviewListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.PreviewListView_RetrieveVirtualItem);
            this.PreviewListView.SelectedIndexChanged += new System.EventHandler(this.PreviewListView_SelectedIndexChanged);
            this.PreviewListView.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.PreviewListView_VirtualItemsSelectionRangeChanged);
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabFrames
            // 
            this.tabFrames.Controls.Add(this.frameGridView);
            this.tabFrames.Location = new System.Drawing.Point(4, 22);
            this.tabFrames.Name = "tabFrames";
            this.tabFrames.Size = new System.Drawing.Size(1026, 238);
            this.tabFrames.TabIndex = 1;
            this.tabFrames.Text = "帧";
            this.tabFrames.UseVisualStyleBackColor = true;
            // 
            // frameGridView
            // 
            this.frameGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.frameGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frameGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FrameAction,
            this.FrameStart,
            this.FrameCount,
            this.FrameSkip,
            this.FrameInterval,
            this.FrameEffectStart,
            this.FrameEffectCount,
            this.FrameEffectSkip,
            this.FrameEffectInterval,
            this.FrameReverse,
            this.FrameBlend});
            this.frameGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frameGridView.Location = new System.Drawing.Point(0, 0);
            this.frameGridView.Name = "frameGridView";
            this.frameGridView.Size = new System.Drawing.Size(1026, 238);
            this.frameGridView.TabIndex = 2;
            this.frameGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.frameGridView_CellValidating);
            this.frameGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.frameGridView_DefaultValuesNeeded);
            this.frameGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.frameGridView_RowEnter);
            // 
            // FrameAction
            // 
            this.FrameAction.HeaderText = "Action";
            this.FrameAction.Name = "FrameAction";
            this.FrameAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FrameAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrameStart
            // 
            this.FrameStart.HeaderText = "Start";
            this.FrameStart.Name = "FrameStart";
            // 
            // FrameCount
            // 
            this.FrameCount.HeaderText = "Count";
            this.FrameCount.Name = "FrameCount";
            // 
            // FrameSkip
            // 
            this.FrameSkip.HeaderText = "Skip";
            this.FrameSkip.Name = "FrameSkip";
            // 
            // FrameInterval
            // 
            this.FrameInterval.HeaderText = "Interval";
            this.FrameInterval.Name = "FrameInterval";
            // 
            // FrameEffectStart
            // 
            this.FrameEffectStart.HeaderText = "EffectStart";
            this.FrameEffectStart.Name = "FrameEffectStart";
            // 
            // FrameEffectCount
            // 
            this.FrameEffectCount.HeaderText = "EffectCount";
            this.FrameEffectCount.Name = "FrameEffectCount";
            // 
            // FrameEffectSkip
            // 
            this.FrameEffectSkip.HeaderText = "EffectSkip";
            this.FrameEffectSkip.Name = "FrameEffectSkip";
            // 
            // FrameEffectInterval
            // 
            this.FrameEffectInterval.HeaderText = "EffectInterval";
            this.FrameEffectInterval.Name = "FrameEffectInterval";
            // 
            // FrameReverse
            // 
            this.FrameReverse.HeaderText = "Reverse";
            this.FrameReverse.Name = "FrameReverse";
            // 
            // FrameBlend
            // 
            this.FrameBlend.HeaderText = "Blend";
            this.FrameBlend.Name = "FrameBlend";
            // 
            // OpenLibraryDialog
            // 
            this.OpenLibraryDialog.Filter = "Library|*.Lib";
            // 
            // SaveLibraryDialog
            // 
            this.SaveLibraryDialog.Filter = "Library|*.Lib";
            // 
            // ImportImageDialog
            // 
            this.ImportImageDialog.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            this.ImportImageDialog.Multiselect = true;
            // 
            // OpenWeMadeDialog
            // 
            this.OpenWeMadeDialog.Filter = "WeMade|*.Wil;*.Wtl|Shanda|*.Wzl;*.Miz|Lib|*.Lib";
            this.OpenWeMadeDialog.Multiselect = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 652);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1036, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel.Text = "所选图像:";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar.Step = 1;
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // FolderLibraryDialog
            // 
            this.FolderLibraryDialog.ShowNewFolderButton = false;
            // 
            // FrameAnimTimer
            // 
            this.FrameAnimTimer.Tick += new System.EventHandler(this.FrameAnimTimer_Tick);
            // 
            // LMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 674);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(650, 418);
            this.Name = "LMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "素材编辑器";
            this.Resize += new System.EventHandler(this.LMain_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabImages.ResumeLayout(false);
            this.tabFrames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frameGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;

        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OpenLibraryDialog;
        private System.Windows.Forms.SaveFileDialog SaveLibraryDialog;
        private System.Windows.Forms.OpenFileDialog ImportImageDialog;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.OpenFileDialog OpenWeMadeDialog;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBlanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countBlanksToolStripMenuItem;
        private System.Windows.Forms.TextBox OffSetYTextBox;
        private System.Windows.Forms.TextBox OffSetXTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button InsertImageButton;
        private System.Windows.Forms.ToolStripMenuItem safeToolStripMenuItem;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TrackBar ZoomTrackBar;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem skinToolStripMenuItem;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button buttonSkipPrevious;
        private System.Windows.Forms.Button buttonSkipNext;
        private System.Windows.Forms.CheckBox checkBoxQuality;
        private System.Windows.Forms.CheckBox checkBoxPreventAntiAliasing;
        private System.Windows.Forms.NumericUpDown nudJump;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabImages;
        private CustomFormControl.FixedListView PreviewListView;
        private System.Windows.Forms.TabPage tabFrames;
        private System.Windows.Forms.DataGridView frameGridView;
        private System.Windows.Forms.ToolStripMenuItem populateFramesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultMonsterFramesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultPlayerFramesToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderLibraryDialog;
        private System.Windows.Forms.ToolStripMenuItem autofillFromCodeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn FrameAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameSkip;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameEffectStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameEffectCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameEffectSkip;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameEffectInterval;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FrameReverse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FrameBlend;
        private System.Windows.Forms.ToolStripMenuItem defaultNPCFramesToolStripMenuItem;
        private System.Windows.Forms.Timer FrameAnimTimer;
        private System.Windows.Forms.CheckBox checkboxRemoveBlackOnImport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RButtonOverlay;
        private System.Windows.Forms.RadioButton RButtonImage;
    }
}

