﻿namespace XrmToolBox___CRM_Bulk_Workflow_Tool
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.btnWhoAmI = new System.Windows.Forms.Button();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripSplitButton();
            this.workflowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCountRecords = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExecuteWFs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolImageList = new System.Windows.Forms.ImageList(this.components);
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecordCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbViews = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radFetchXML = new System.Windows.Forms.RadioButton();
            this.radViews = new System.Windows.Forms.RadioButton();
            this.cmbWorkflows = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFetch = new System.Windows.Forms.GroupBox();
            this.rtxtFetchXML = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStripMenu.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.grpFetch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWhoAmI
            // 
            this.btnWhoAmI.Location = new System.Drawing.Point(535, 613);
            this.btnWhoAmI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWhoAmI.Name = "btnWhoAmI";
            this.btnWhoAmI.Size = new System.Drawing.Size(100, 28);
            this.btnWhoAmI.TabIndex = 1;
            this.btnWhoAmI.Text = "Who Am I";
            this.btnWhoAmI.UseVisualStyleBackColor = true;
            this.btnWhoAmI.Visible = false;
            this.btnWhoAmI.Click += new System.EventHandler(this.BtnWhoAmIClick);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnCountRecords,
            this.toolStripSeparator3,
            this.btnExecuteWFs,
            this.toolStripSeparator4,
            this.btnHelp});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1215, 27);
            this.toolStripMenu.TabIndex = 2;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(127, 24);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.TsbCloseClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workflowsToolStripMenuItem,
            this.viewsToolStripMenuItem});
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 24);
            this.btnRefresh.Text = "Refresh";
            // 
            // workflowsToolStripMenuItem
            // 
            this.workflowsToolStripMenuItem.Name = "workflowsToolStripMenuItem";
            this.workflowsToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.workflowsToolStripMenuItem.Text = "&Workflows";
            this.workflowsToolStripMenuItem.Click += new System.EventHandler(this.workflowsToolStripMenuItem_Click_1);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.viewsToolStripMenuItem.Text = "&Views";
            this.viewsToolStripMenuItem.Click += new System.EventHandler(this.viewsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnCountRecords
            // 
            this.btnCountRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnCountRecords.Image")));
            this.btnCountRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCountRecords.Name = "btnCountRecords";
            this.btnCountRecords.Size = new System.Drawing.Size(129, 24);
            this.btnCountRecords.Text = "Count Records";
            this.btnCountRecords.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnExecuteWFs
            // 
            this.btnExecuteWFs.Image = ((System.Drawing.Image)(resources.GetObject("btnExecuteWFs.Image")));
            this.btnExecuteWFs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExecuteWFs.Name = "btnExecuteWFs";
            this.btnExecuteWFs.Size = new System.Drawing.Size(138, 24);
            this.btnExecuteWFs.Text = "Start Workflows";
            this.btnExecuteWFs.Click += new System.EventHandler(this.btnExecuteWFs_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 24);
            this.btnHelp.Text = "toolStripButton1";
            this.btnHelp.ToolTipText = "HELP / Contact Andy Popkin";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // toolImageList
            // 
            this.toolImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolImageList.ImageStream")));
            this.toolImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.toolImageList.Images.SetKeyName(0, "AP Logo.png");
            this.toolImageList.Images.SetKeyName(1, "nologo.png");
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.label6);
            this.grpControls.Controls.Add(this.txtDelay);
            this.grpControls.Controls.Add(this.label5);
            this.grpControls.Controls.Add(this.txtBatch);
            this.grpControls.Controls.Add(this.label4);
            this.grpControls.Controls.Add(this.txtRecordCount);
            this.grpControls.Controls.Add(this.label3);
            this.grpControls.Controls.Add(this.cmbViews);
            this.grpControls.Controls.Add(this.label2);
            this.grpControls.Controls.Add(this.radFetchXML);
            this.grpControls.Controls.Add(this.radViews);
            this.grpControls.Controls.Add(this.cmbWorkflows);
            this.grpControls.Controls.Add(this.label1);
            this.grpControls.Location = new System.Drawing.Point(20, 65);
            this.grpControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpControls.Name = "grpControls";
            this.grpControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpControls.Size = new System.Drawing.Size(507, 455);
            this.grpControls.TabIndex = 3;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Control Center";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(383, 380);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "seconds";
            // 
            // txtDelay
            // 
            this.txtDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelay.Location = new System.Drawing.Point(241, 377);
            this.txtDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(132, 26);
            this.txtDelay.TabIndex = 11;
            this.txtDelay.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(108, 380);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Interval Delay:";
            // 
            // txtBatch
            // 
            this.txtBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatch.Location = new System.Drawing.Point(241, 342);
            this.txtBatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(132, 26);
            this.txtBatch.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(133, 346);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Batch Size:";
            // 
            // txtRecordCount
            // 
            this.txtRecordCount.Enabled = false;
            this.txtRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecordCount.Location = new System.Drawing.Point(241, 308);
            this.txtRecordCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRecordCount.Name = "txtRecordCount";
            this.txtRecordCount.Size = new System.Drawing.Size(132, 26);
            this.txtRecordCount.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Record Count:";
            // 
            // cmbViews
            // 
            this.cmbViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbViews.FormattingEnabled = true;
            this.cmbViews.Location = new System.Drawing.Point(41, 213);
            this.cmbViews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbViews.Name = "cmbViews";
            this.cmbViews.Size = new System.Drawing.Size(408, 28);
            this.cmbViews.TabIndex = 5;
            this.cmbViews.SelectedIndexChanged += new System.EventHandler(this.cmbViews_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 193);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Views";
            // 
            // radFetchXML
            // 
            this.radFetchXML.AutoSize = true;
            this.radFetchXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFetchXML.Location = new System.Drawing.Point(277, 139);
            this.radFetchXML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radFetchXML.Name = "radFetchXML";
            this.radFetchXML.Size = new System.Drawing.Size(142, 24);
            this.radFetchXML.TabIndex = 3;
            this.radFetchXML.Text = "Use FetchXML";
            this.radFetchXML.UseVisualStyleBackColor = true;
            this.radFetchXML.CheckedChanged += new System.EventHandler(this.radFetchXML_CheckedChanged);
            // 
            // radViews
            // 
            this.radViews.AutoSize = true;
            this.radViews.Checked = true;
            this.radViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radViews.Location = new System.Drawing.Point(83, 139);
            this.radViews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radViews.Name = "radViews";
            this.radViews.Size = new System.Drawing.Size(110, 24);
            this.radViews.TabIndex = 2;
            this.radViews.TabStop = true;
            this.radViews.Text = "Use Views";
            this.radViews.UseVisualStyleBackColor = true;
            this.radViews.CheckedChanged += new System.EventHandler(this.radViews_CheckedChanged);
            // 
            // cmbWorkflows
            // 
            this.cmbWorkflows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWorkflows.FormattingEnabled = true;
            this.cmbWorkflows.Location = new System.Drawing.Point(41, 63);
            this.cmbWorkflows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbWorkflows.Name = "cmbWorkflows";
            this.cmbWorkflows.Size = new System.Drawing.Size(408, 28);
            this.cmbWorkflows.TabIndex = 1;
            this.cmbWorkflows.SelectedIndexChanged += new System.EventHandler(this.cmbWorkflows_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "On-Demand Workflows";
            // 
            // grpFetch
            // 
            this.grpFetch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFetch.Controls.Add(this.rtxtFetchXML);
            this.grpFetch.Location = new System.Drawing.Point(535, 65);
            this.grpFetch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFetch.Name = "grpFetch";
            this.grpFetch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFetch.Size = new System.Drawing.Size(616, 455);
            this.grpFetch.TabIndex = 4;
            this.grpFetch.TabStop = false;
            this.grpFetch.Text = "FetchXML Query";
            // 
            // rtxtFetchXML
            // 
            this.rtxtFetchXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtFetchXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtFetchXML.Location = new System.Drawing.Point(4, 19);
            this.rtxtFetchXML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxtFetchXML.Name = "rtxtFetchXML";
            this.rtxtFetchXML.Size = new System.Drawing.Size(608, 432);
            this.rtxtFetchXML.TabIndex = 0;
            this.rtxtFetchXML.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(20, 550);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1131, 39);
            this.progressBar1.TabIndex = 5;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.grpFetch);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.btnWhoAmI);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(1215, 738);
            this.Load += new System.EventHandler(this.MainControl_Load_1);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.grpFetch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWhoAmI;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ImageList toolImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCountRecords;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExecuteWFs;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.TextBox txtRecordCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbViews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radFetchXML;
        private System.Windows.Forms.RadioButton radViews;
        private System.Windows.Forms.ComboBox cmbWorkflows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpFetch;
        private System.Windows.Forms.RichTextBox rtxtFetchXML;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem workflowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label label5;
    }
}
