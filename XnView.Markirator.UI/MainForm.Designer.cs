namespace XnView.Markirator.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainFormTabs = new TabControl();
            evaluationTabPage = new TabPage();
            progressBar1 = new ProgressBar();
            groupImagesPath = new GroupBox();
            btSelectFolderForEvaluation = new Button();
            mainImagesList = new ImageList(components);
            btSelectImageForEvaluation = new Button();
            txtImagePath = new TextBox();
            btStartEvaluation = new Button();
            tabPage2 = new TabPage();
            grpImportTags = new GroupBox();
            btOpenTagsFile = new Button();
            txtImportTagsFile = new TextBox();
            btImportTags = new Button();
            outputTabPage = new TabPage();
            splitContainer1 = new SplitContainer();
            listViewOutput = new ListView();
            Title = new ColumnHeader();
            TimeStamp = new ColumnHeader();
            groupBox1 = new GroupBox();
            txtOutputEntry = new TextBox();
            installationTabPage = new TabPage();
            btSaveSettings = new Button();
            groupBox6 = new GroupBox();
            btSelectXnViewImagesCatalogPath = new Button();
            txtXnViewImagesCatalogPath = new TextBox();
            groupBox4 = new GroupBox();
            btSelectXnViewDb = new Button();
            txtXnViewDbFolder = new TextBox();
            groupBox3 = new GroupBox();
            btInstallDeepDanbooru = new Button();
            groupBox2 = new GroupBox();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            label2 = new Label();
            label3 = new Label();
            linkLabel2 = new LinkLabel();
            aboutPage = new TabPage();
            linkLabel6 = new LinkLabel();
            groupBox5 = new GroupBox();
            label7 = new Label();
            linkLabel5 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            label8 = new Label();
            label5 = new Label();
            evaluationBgWorker = new System.ComponentModel.BackgroundWorker();
            statusStrip = new StatusStrip();
            lbProgress = new ToolStripStatusLabel();
            label6 = new Label();
            label4 = new Label();
            mainFormTabs.SuspendLayout();
            evaluationTabPage.SuspendLayout();
            groupImagesPath.SuspendLayout();
            tabPage2.SuspendLayout();
            grpImportTags.SuspendLayout();
            outputTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            installationTabPage.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            aboutPage.SuspendLayout();
            groupBox5.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainFormTabs
            // 
            mainFormTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainFormTabs.Controls.Add(evaluationTabPage);
            mainFormTabs.Controls.Add(tabPage2);
            mainFormTabs.Controls.Add(outputTabPage);
            mainFormTabs.Controls.Add(installationTabPage);
            mainFormTabs.Controls.Add(aboutPage);
            mainFormTabs.ImageList = mainImagesList;
            mainFormTabs.Location = new Point(12, 12);
            mainFormTabs.Name = "mainFormTabs";
            mainFormTabs.SelectedIndex = 0;
            mainFormTabs.Size = new Size(425, 436);
            mainFormTabs.TabIndex = 1;
            // 
            // evaluationTabPage
            // 
            evaluationTabPage.Controls.Add(progressBar1);
            evaluationTabPage.Controls.Add(groupImagesPath);
            evaluationTabPage.Controls.Add(btStartEvaluation);
            evaluationTabPage.ImageKey = "robot.png";
            evaluationTabPage.Location = new Point(4, 24);
            evaluationTabPage.Name = "evaluationTabPage";
            evaluationTabPage.Padding = new Padding(3);
            evaluationTabPage.Size = new Size(417, 408);
            evaluationTabPage.TabIndex = 0;
            evaluationTabPage.Text = "Evaluation";
            evaluationTabPage.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(6, 64);
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(295, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 2;
            // 
            // groupImagesPath
            // 
            groupImagesPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupImagesPath.Controls.Add(btSelectFolderForEvaluation);
            groupImagesPath.Controls.Add(btSelectImageForEvaluation);
            groupImagesPath.Controls.Add(txtImagePath);
            groupImagesPath.Location = new Point(6, 6);
            groupImagesPath.Name = "groupImagesPath";
            groupImagesPath.Size = new Size(405, 52);
            groupImagesPath.TabIndex = 2;
            groupImagesPath.TabStop = false;
            groupImagesPath.Text = "Path to the image (or image folder)";
            // 
            // btSelectFolderForEvaluation
            // 
            btSelectFolderForEvaluation.AccessibleDescription = "";
            btSelectFolderForEvaluation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSelectFolderForEvaluation.ImageKey = "blue-folder-open.png";
            btSelectFolderForEvaluation.ImageList = mainImagesList;
            btSelectFolderForEvaluation.Location = new Point(350, 21);
            btSelectFolderForEvaluation.Name = "btSelectFolderForEvaluation";
            btSelectFolderForEvaluation.Size = new Size(24, 24);
            btSelectFolderForEvaluation.TabIndex = 7;
            btSelectFolderForEvaluation.UseVisualStyleBackColor = true;
            btSelectFolderForEvaluation.Click += BtSelectFolderForEvaluation_Click;
            // 
            // mainImagesList
            // 
            mainImagesList.ColorDepth = ColorDepth.Depth8Bit;
            mainImagesList.ImageStream = (ImageListStreamer)resources.GetObject("mainImagesList.ImageStream");
            mainImagesList.TransparentColor = Color.Transparent;
            mainImagesList.Images.SetKeyName(0, "information-italic.png");
            mainImagesList.Images.SetKeyName(1, "wand.png");
            mainImagesList.Images.SetKeyName(2, "script-import.png");
            mainImagesList.Images.SetKeyName(3, "database-import.png");
            mainImagesList.Images.SetKeyName(4, "robot.png");
            mainImagesList.Images.SetKeyName(5, "gear.png");
            mainImagesList.Images.SetKeyName(6, "disk-black.png");
            mainImagesList.Images.SetKeyName(7, "blue-folder-open-document.png");
            mainImagesList.Images.SetKeyName(8, "blue-folder-open.png");
            mainImagesList.Images.SetKeyName(9, "blue-folder-open-image.png");
            // 
            // btSelectImageForEvaluation
            // 
            btSelectImageForEvaluation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSelectImageForEvaluation.ImageKey = "blue-folder-open-image.png";
            btSelectImageForEvaluation.ImageList = mainImagesList;
            btSelectImageForEvaluation.Location = new Point(375, 21);
            btSelectImageForEvaluation.Name = "btSelectImageForEvaluation";
            btSelectImageForEvaluation.Size = new Size(24, 24);
            btSelectImageForEvaluation.TabIndex = 6;
            btSelectImageForEvaluation.UseVisualStyleBackColor = true;
            btSelectImageForEvaluation.Click += BtSelectImageForEvaluation_Click;
            // 
            // txtImagePath
            // 
            txtImagePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImagePath.Location = new Point(6, 22);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(338, 23);
            txtImagePath.TabIndex = 0;
            // 
            // btStartEvaluation
            // 
            btStartEvaluation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btStartEvaluation.Location = new Point(307, 64);
            btStartEvaluation.Name = "btStartEvaluation";
            btStartEvaluation.Size = new Size(104, 23);
            btStartEvaluation.TabIndex = 1;
            btStartEvaluation.Text = "Start Evaluation";
            btStartEvaluation.UseVisualStyleBackColor = true;
            btStartEvaluation.Click += BtStartEvaluation_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(grpImportTags);
            tabPage2.Controls.Add(btImportTags);
            tabPage2.ImageKey = "database-import.png";
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(417, 408);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Import";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpImportTags
            // 
            grpImportTags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpImportTags.Controls.Add(btOpenTagsFile);
            grpImportTags.Controls.Add(txtImportTagsFile);
            grpImportTags.Location = new Point(6, 6);
            grpImportTags.Name = "grpImportTags";
            grpImportTags.Size = new Size(405, 52);
            grpImportTags.TabIndex = 4;
            grpImportTags.TabStop = false;
            grpImportTags.Text = "Tags file path (JSON)";
            // 
            // btOpenTagsFile
            // 
            btOpenTagsFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btOpenTagsFile.ImageKey = "blue-folder-open-document.png";
            btOpenTagsFile.ImageList = mainImagesList;
            btOpenTagsFile.Location = new Point(375, 21);
            btOpenTagsFile.Name = "btOpenTagsFile";
            btOpenTagsFile.Size = new Size(24, 24);
            btOpenTagsFile.TabIndex = 5;
            btOpenTagsFile.UseVisualStyleBackColor = true;
            btOpenTagsFile.Click += BtOpenTagsFile_Click;
            // 
            // txtImportTagsFile
            // 
            txtImportTagsFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImportTagsFile.Location = new Point(6, 22);
            txtImportTagsFile.Name = "txtImportTagsFile";
            txtImportTagsFile.Size = new Size(363, 23);
            txtImportTagsFile.TabIndex = 0;
            // 
            // btImportTags
            // 
            btImportTags.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btImportTags.Location = new Point(307, 64);
            btImportTags.Margin = new Padding(3, 2, 3, 2);
            btImportTags.Name = "btImportTags";
            btImportTags.Size = new Size(104, 23);
            btImportTags.TabIndex = 3;
            btImportTags.Text = "Import Tags";
            btImportTags.UseVisualStyleBackColor = true;
            btImportTags.Click += BtImportTags_Click;
            // 
            // outputTabPage
            // 
            outputTabPage.Controls.Add(splitContainer1);
            outputTabPage.ImageKey = "script-import.png";
            outputTabPage.Location = new Point(4, 24);
            outputTabPage.Name = "outputTabPage";
            outputTabPage.Padding = new Padding(3);
            outputTabPage.Size = new Size(417, 408);
            outputTabPage.TabIndex = 2;
            outputTabPage.Text = "Output";
            outputTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listViewOutput);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(411, 402);
            splitContainer1.SplitterDistance = 291;
            splitContainer1.TabIndex = 1;
            // 
            // listViewOutput
            // 
            listViewOutput.Columns.AddRange(new ColumnHeader[] { Title, TimeStamp });
            listViewOutput.Dock = DockStyle.Fill;
            listViewOutput.FullRowSelect = true;
            listViewOutput.GridLines = true;
            listViewOutput.Location = new Point(0, 0);
            listViewOutput.Margin = new Padding(3, 2, 3, 2);
            listViewOutput.Name = "listViewOutput";
            listViewOutput.ShowGroups = false;
            listViewOutput.Size = new Size(411, 291);
            listViewOutput.TabIndex = 0;
            listViewOutput.UseCompatibleStateImageBehavior = false;
            listViewOutput.View = View.Details;
            listViewOutput.ItemSelectionChanged += ListViewOutput_ItemSelectionChanged;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 298;
            // 
            // TimeStamp
            // 
            TimeStamp.Text = "TimeStamp";
            TimeStamp.Width = 120;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOutputEntry);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(411, 107);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Description";
            // 
            // txtOutputEntry
            // 
            txtOutputEntry.Dock = DockStyle.Fill;
            txtOutputEntry.Location = new Point(3, 19);
            txtOutputEntry.Margin = new Padding(3, 2, 3, 2);
            txtOutputEntry.Multiline = true;
            txtOutputEntry.Name = "txtOutputEntry";
            txtOutputEntry.ScrollBars = ScrollBars.Vertical;
            txtOutputEntry.Size = new Size(405, 85);
            txtOutputEntry.TabIndex = 0;
            // 
            // installationTabPage
            // 
            installationTabPage.Controls.Add(btSaveSettings);
            installationTabPage.Controls.Add(groupBox6);
            installationTabPage.Controls.Add(groupBox4);
            installationTabPage.Controls.Add(groupBox3);
            installationTabPage.Controls.Add(groupBox2);
            installationTabPage.ImageKey = "gear.png";
            installationTabPage.Location = new Point(4, 24);
            installationTabPage.Margin = new Padding(3, 2, 3, 2);
            installationTabPage.Name = "installationTabPage";
            installationTabPage.Padding = new Padding(3, 2, 3, 2);
            installationTabPage.Size = new Size(417, 408);
            installationTabPage.TabIndex = 3;
            installationTabPage.Text = "Settings";
            installationTabPage.UseVisualStyleBackColor = true;
            // 
            // btSaveSettings
            // 
            btSaveSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btSaveSettings.ImageKey = "disk-black.png";
            btSaveSettings.ImageList = mainImagesList;
            btSaveSettings.Location = new Point(6, 336);
            btSaveSettings.Name = "btSaveSettings";
            btSaveSettings.Size = new Size(405, 24);
            btSaveSettings.TabIndex = 1;
            btSaveSettings.Text = "Save";
            btSaveSettings.TextAlign = ContentAlignment.MiddleRight;
            btSaveSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btSaveSettings.UseVisualStyleBackColor = true;
            btSaveSettings.Click += BtSaveSettings_Click;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(btSelectXnViewImagesCatalogPath);
            groupBox6.Controls.Add(txtXnViewImagesCatalogPath);
            groupBox6.Location = new Point(6, 260);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(405, 70);
            groupBox6.TabIndex = 12;
            groupBox6.TabStop = false;
            groupBox6.Text = "Base path of your pictures";
            // 
            // btSelectXnViewImagesCatalogPath
            // 
            btSelectXnViewImagesCatalogPath.AccessibleDescription = "";
            btSelectXnViewImagesCatalogPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSelectXnViewImagesCatalogPath.ImageKey = "blue-folder-open.png";
            btSelectXnViewImagesCatalogPath.ImageList = mainImagesList;
            btSelectXnViewImagesCatalogPath.Location = new Point(375, 21);
            btSelectXnViewImagesCatalogPath.Name = "btSelectXnViewImagesCatalogPath";
            btSelectXnViewImagesCatalogPath.Size = new Size(24, 24);
            btSelectXnViewImagesCatalogPath.TabIndex = 8;
            btSelectXnViewImagesCatalogPath.UseVisualStyleBackColor = true;
            btSelectXnViewImagesCatalogPath.Click += BtSelectXnViewImagesCatalogPath_Click;
            // 
            // txtXnViewImagesCatalogPath
            // 
            txtXnViewImagesCatalogPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtXnViewImagesCatalogPath.Location = new Point(6, 22);
            txtXnViewImagesCatalogPath.Name = "txtXnViewImagesCatalogPath";
            txtXnViewImagesCatalogPath.Size = new Size(363, 23);
            txtXnViewImagesCatalogPath.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(txtXnViewDbFolder);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(btSelectXnViewDb);
            groupBox4.Location = new Point(6, 184);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(405, 70);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Folder for Catalog";
            // 
            // btSelectXnViewDb
            // 
            btSelectXnViewDb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSelectXnViewDb.ImageKey = "blue-folder-open.png";
            btSelectXnViewDb.ImageList = mainImagesList;
            btSelectXnViewDb.Location = new Point(375, 21);
            btSelectXnViewDb.Name = "btSelectXnViewDb";
            btSelectXnViewDb.Size = new Size(24, 24);
            btSelectXnViewDb.TabIndex = 7;
            btSelectXnViewDb.UseVisualStyleBackColor = true;
            btSelectXnViewDb.Click += BtSelectXnViewDb_Click;
            // 
            // txtXnViewDbFolder
            // 
            txtXnViewDbFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtXnViewDbFolder.Location = new Point(6, 22);
            txtXnViewDbFolder.Name = "txtXnViewDbFolder";
            txtXnViewDbFolder.Size = new Size(363, 23);
            txtXnViewDbFolder.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(btInstallDeepDanbooru);
            groupBox3.Location = new Point(6, 128);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(405, 50);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tags Evaluation";
            // 
            // btInstallDeepDanbooru
            // 
            btInstallDeepDanbooru.Location = new Point(6, 21);
            btInstallDeepDanbooru.Margin = new Padding(3, 2, 3, 2);
            btInstallDeepDanbooru.Name = "btInstallDeepDanbooru";
            btInstallDeepDanbooru.Size = new Size(163, 22);
            btInstallDeepDanbooru.TabIndex = 0;
            btInstallDeepDanbooru.Text = "Install DeepDanbooru";
            btInstallDeepDanbooru.UseVisualStyleBackColor = true;
            btInstallDeepDanbooru.Click += BtInstallDeepDanbooru_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Controls.Add(linkLabel3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(linkLabel2);
            groupBox2.Location = new Point(6, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(405, 117);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Required components";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 1;
            label1.Text = "1) Microsoft C++ Build Tools";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(6, 33);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(335, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://visualstudio.microsoft.com/ru/visual-cpp-build-tools/";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(6, 93);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(374, 15);
            linkLabel3.TabIndex = 7;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "https://www.python.org/ftp/python/3.11.5/python-3.11.5-amd64.exe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 49);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "2) Python";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 79);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 6;
            label3.Text = "or from direct link:";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(6, 63);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(256, 15);
            linkLabel2.TabIndex = 5;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://www.python.org/downloads/windows/";
            // 
            // aboutPage
            // 
            aboutPage.Controls.Add(linkLabel6);
            aboutPage.Controls.Add(groupBox5);
            aboutPage.Controls.Add(label5);
            aboutPage.ImageKey = "information-italic.png";
            aboutPage.Location = new Point(4, 24);
            aboutPage.Name = "aboutPage";
            aboutPage.Padding = new Padding(3);
            aboutPage.Size = new Size(417, 408);
            aboutPage.TabIndex = 4;
            aboutPage.Text = "About";
            aboutPage.UseVisualStyleBackColor = true;
            // 
            // linkLabel6
            // 
            linkLabel6.AutoSize = true;
            linkLabel6.Location = new Point(6, 43);
            linkLabel6.Name = "linkLabel6";
            linkLabel6.Size = new Size(277, 15);
            linkLabel6.TabIndex = 14;
            linkLabel6.TabStop = true;
            linkLabel6.Text = "https://github.com/b4dp0ssum/XnView.Markirator";
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(linkLabel5);
            groupBox5.Controls.Add(linkLabel4);
            groupBox5.Controls.Add(label8);
            groupBox5.Location = new Point(6, 70);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(405, 58);
            groupBox5.TabIndex = 14;
            groupBox5.TabStop = false;
            groupBox5.Text = "Components";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 19);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 11;
            label7.Text = "DeepDanbooru:";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(105, 34);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(189, 15);
            linkLabel5.TabIndex = 13;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "https://p.yusukekamiyamane.com";
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(105, 19);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(263, 15);
            linkLabel4.TabIndex = 10;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "https://github.com/KichangKim/DeepDanbooru";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 34);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 12;
            label8.Text = "Fugue Icons:";
            // 
            // label5
            // 
            label5.Location = new Point(6, 3);
            label5.Name = "label5";
            label5.Size = new Size(405, 40);
            label5.TabIndex = 7;
            label5.Text = "This is simple application that is designed to integrate DeepDanbooru (image tag estimation system) and XnView (image viewer).\r\n\r\n";
            // 
            // evaluationBgWorker
            // 
            evaluationBgWorker.WorkerReportsProgress = true;
            evaluationBgWorker.DoWork += EvaluationBgWorker_DoWork;
            evaluationBgWorker.RunWorkerCompleted += EvaluationBgWorker_RunWorkerCompleted;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lbProgress });
            statusStrip.Location = new Point(0, 451);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(449, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // lbProgress
            // 
            lbProgress.Name = "lbProgress";
            lbProgress.Size = new Size(83, 17);
            lbProgress.Text = "lbProgressText";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(6, 48);
            label6.Name = "label6";
            label6.Size = new Size(250, 15);
            label6.TabIndex = 8;
            label6.Text = "XnView -> Settings -> Paths -> Other settings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(6, 48);
            label4.Name = "label4";
            label4.Size = new Size(229, 15);
            label4.TabIndex = 9;
            label4.Text = "XnView -> Settings -> Browser -> Catalog";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 473);
            Controls.Add(statusStrip);
            Controls.Add(mainFormTabs);
            Name = "MainForm";
            Text = "XnView.Markirator";
            mainFormTabs.ResumeLayout(false);
            evaluationTabPage.ResumeLayout(false);
            groupImagesPath.ResumeLayout(false);
            groupImagesPath.PerformLayout();
            tabPage2.ResumeLayout(false);
            grpImportTags.ResumeLayout(false);
            grpImportTags.PerformLayout();
            outputTabPage.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            installationTabPage.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            aboutPage.ResumeLayout(false);
            aboutPage.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl mainFormTabs;
        private TabPage evaluationTabPage;
        private TabPage tabPage2;
        private Button btStartEvaluation;
        private TabPage outputTabPage;
        private ProgressBar progressBar1;
        private GroupBox groupImagesPath;
        private TextBox txtImagePath;
        private System.ComponentModel.BackgroundWorker evaluationBgWorker;
        private TabPage installationTabPage;
        private Button btInstallDeepDanbooru;
        private Label label1;
        private LinkLabel linkLabel3;
        private Label label3;
        private LinkLabel linkLabel2;
        private Label label2;
        private LinkLabel linkLabel1;
        private GroupBox grpImportTags;
        private TextBox txtImportTagsFile;
        private Button btImportTags;
        private ListView listViewOutput;
        private SplitContainer splitContainer1;
        private TextBox txtOutputEntry;
        private ColumnHeader Title;
        private ColumnHeader TimeStamp;
        private TabPage aboutPage;
        private LinkLabel linkLabel5;
        private Label label8;
        private Label label7;
        private LinkLabel linkLabel4;
        private Label label5;
        private ImageList mainImagesList;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private TextBox txtXnViewDbFolder;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lbProgress;
        private LinkLabel linkLabel6;
        private GroupBox groupBox5;
        private Button btOpenTagsFile;
        private Button btSelectFolderForEvaluation;
        private Button btSelectImageForEvaluation;
        private GroupBox groupBox6;
        private Button btSaveSettings;
        private TextBox txtXnViewImagesCatalogPath;
        private Button btSelectXnViewImagesCatalogPath;
        private Button btSelectXnViewDb;
        private Label label4;
        private Label label6;
    }
}