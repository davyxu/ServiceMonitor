namespace ServiceMonitor
{
    partial class MonitorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorView));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.logMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyLineTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogSaveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.BuildRunFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoScrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelOp = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.btnWorkDir = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.logMenu.SuspendLayout();
            this.panelOp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(856, 517);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // logMenu
            // 
            this.logMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyLineTextToolStripMenuItem,
            this.LogSaveToFileToolStripMenuItem,
            this.toolStripMenuItem4,
            this.BuildRunFToolStripMenuItem,
            this.BuildToolStripMenuItem,
            this.toolStripMenuItem2,
            this.SearchToolStripMenuItem,
            this.toolStripMenuItem3,
            this.ClearToolStripMenuItem,
            this.ClearAllToolStripMenuItem,
            this.AutoScrollToolStripMenuItem,
            this.ManualStartToolStripMenuItem});
            this.logMenu.Name = "contextMenuStrip1";
            this.logMenu.Size = new System.Drawing.Size(160, 220);
            this.logMenu.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTab_Opening);
            // 
            // CopyLineTextToolStripMenuItem
            // 
            this.CopyLineTextToolStripMenuItem.Name = "CopyLineTextToolStripMenuItem";
            this.CopyLineTextToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.CopyLineTextToolStripMenuItem.Text = "复制行文字(&O)";
            this.CopyLineTextToolStripMenuItem.Click += new System.EventHandler(this.CopyLineTextToolStripMenuItem_Click);
            // 
            // LogSaveToFileToolStripMenuItem
            // 
            this.LogSaveToFileToolStripMenuItem.Name = "LogSaveToFileToolStripMenuItem";
            this.LogSaveToFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.LogSaveToFileToolStripMenuItem.Text = "日志保存文件...";
            this.LogSaveToFileToolStripMenuItem.Click += new System.EventHandler(this.LogSaveToFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(156, 6);
            // 
            // BuildRunFToolStripMenuItem
            // 
            this.BuildRunFToolStripMenuItem.Name = "BuildRunFToolStripMenuItem";
            this.BuildRunFToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.BuildRunFToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.BuildRunFToolStripMenuItem.Text = "编译运行(&F)";
            this.BuildRunFToolStripMenuItem.Click += new System.EventHandler(this.BuildRunFToolStripMenuItem_Click);
            // 
            // BuildToolStripMenuItem
            // 
            this.BuildToolStripMenuItem.Name = "BuildToolStripMenuItem";
            this.BuildToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.BuildToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.BuildToolStripMenuItem.Text = "编译(&B)";
            this.BuildToolStripMenuItem.Click += new System.EventHandler(this.BuildToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.SearchToolStripMenuItem.Text = "搜索(&S)";
            this.SearchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(156, 6);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ClearToolStripMenuItem.Text = "清空(&L)";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // ClearAllToolStripMenuItem
            // 
            this.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem";
            this.ClearAllToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ClearAllToolStripMenuItem.Text = "清空所有(&J)";
            this.ClearAllToolStripMenuItem.Click += new System.EventHandler(this.ClearAllToolStripMenuItem_Click);
            // 
            // AutoScrollToolStripMenuItem
            // 
            this.AutoScrollToolStripMenuItem.Name = "AutoScrollToolStripMenuItem";
            this.AutoScrollToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.AutoScrollToolStripMenuItem.Text = "自动卷轴";
            this.AutoScrollToolStripMenuItem.Click += new System.EventHandler(this.AutoScrollToolStripMenuItem_Click);
            // 
            // ManualStartToolStripMenuItem
            // 
            this.ManualStartToolStripMenuItem.Name = "ManualStartToolStripMenuItem";
            this.ManualStartToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ManualStartToolStripMenuItem.Text = "手动启动";
            this.ManualStartToolStripMenuItem.Click += new System.EventHandler(this.ManualStartToolStripMenuItem_Click);
            // 
            // panelOp
            // 
            this.panelOp.AutoScroll = true;
            this.panelOp.Controls.Add(this.label1);
            this.panelOp.Controls.Add(this.txtArgs);
            this.panelOp.Controls.Add(this.btnWorkDir);
            this.panelOp.Controls.Add(this.btnStartAll);
            this.panelOp.Controls.Add(this.btnStart);
            this.panelOp.Controls.Add(this.btnStopAll);
            this.panelOp.Controls.Add(this.btnStop);
            this.panelOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOp.Location = new System.Drawing.Point(3, 526);
            this.panelOp.Name = "panelOp";
            this.panelOp.Size = new System.Drawing.Size(856, 29);
            this.panelOp.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "启动参数:";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(228, 3);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(231, 21);
            this.txtArgs.TabIndex = 1;
            this.txtArgs.TextChanged += new System.EventHandler(this.txtArgs_TextChanged);
            // 
            // btnWorkDir
            // 
            this.btnWorkDir.Location = new System.Drawing.Point(465, 3);
            this.btnWorkDir.Name = "btnWorkDir";
            this.btnWorkDir.Size = new System.Drawing.Size(75, 23);
            this.btnWorkDir.TabIndex = 0;
            this.btnWorkDir.Text = "工作目录";
            this.btnWorkDir.UseVisualStyleBackColor = true;
            this.btnWorkDir.Click += new System.EventHandler(this.btnSetWorkDir_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Location = new System.Drawing.Point(691, 3);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(75, 23);
            this.btnStartAll.TabIndex = 0;
            this.btnStartAll.Text = "启动所有";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Location = new System.Drawing.Point(772, 3);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(75, 23);
            this.btnStopAll.TabIndex = 0;
            this.btnStopAll.Text = "停止所有";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(88, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelOp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabMain, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(862, 558);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tabMenu
            // 
            this.tabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseTabToolStripMenuItem,
            this.AddTabToolStripMenuItem,
            this.toolStripMenuItem1,
            this.MoveLeftToolStripMenuItem,
            this.MoveRightToolStripMenuItem,
            this.toolStripMenuItem5,
            this.CopyTabToolStripMenuItem,
            this.toolStripMenuItem6,
            this.OpenDirToolStripMenuItem});
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Size = new System.Drawing.Size(166, 154);
            // 
            // CloseTabToolStripMenuItem
            // 
            this.CloseTabToolStripMenuItem.Name = "CloseTabToolStripMenuItem";
            this.CloseTabToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.CloseTabToolStripMenuItem.Text = "关闭(&X)";
            this.CloseTabToolStripMenuItem.Click += new System.EventHandler(this.CloseTabToolStripMenuItem_Click);
            // 
            // AddTabToolStripMenuItem
            // 
            this.AddTabToolStripMenuItem.Name = "AddTabToolStripMenuItem";
            this.AddTabToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.AddTabToolStripMenuItem.Text = "添加(&A)";
            this.AddTabToolStripMenuItem.Click += new System.EventHandler(this.AddTabToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(162, 6);
            // 
            // CopyTabToolStripMenuItem
            // 
            this.CopyTabToolStripMenuItem.Name = "CopyTabToolStripMenuItem";
            this.CopyTabToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.CopyTabToolStripMenuItem.Text = "复制(&C)";
            this.CopyTabToolStripMenuItem.Click += new System.EventHandler(this.CopyTabToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(162, 6);
            // 
            // OpenDirToolStripMenuItem
            // 
            this.OpenDirToolStripMenuItem.Name = "OpenDirToolStripMenuItem";
            this.OpenDirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.OpenDirToolStripMenuItem.Text = "打开目标目录(&D)";
            this.OpenDirToolStripMenuItem.Click += new System.EventHandler(this.OpenDirToolStripMenuItem_Click_1);
            // 
            // MoveLeftToolStripMenuItem
            // 
            this.MoveLeftToolStripMenuItem.Name = "MoveLeftToolStripMenuItem";
            this.MoveLeftToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MoveLeftToolStripMenuItem.Text = "左移(&L)";
            this.MoveLeftToolStripMenuItem.Click += new System.EventHandler(this.MoveLeftToolStripMenuItem_Click);
            // 
            // MoveRightToolStripMenuItem
            // 
            this.MoveRightToolStripMenuItem.Name = "MoveRightToolStripMenuItem";
            this.MoveRightToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.MoveRightToolStripMenuItem.Text = "右移(&R)";
            this.MoveRightToolStripMenuItem.Click += new System.EventHandler(this.MoveRightToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // MonitorView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(862, 558);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonitorView";
            this.Text = "ServiceMonitor 2.3.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.logMenu.ResumeLayout(false);
            this.panelOp.ResumeLayout(false);
            this.panelOp.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Panel panelOp;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip logMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CopyLineTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogSaveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoScrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem BuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BuildRunFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ContextMenuStrip tabMenu;
        private System.Windows.Forms.ToolStripMenuItem CloseTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem CopyTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem OpenDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualStartToolStripMenuItem;
        private System.Windows.Forms.Button btnWorkDir;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MoveLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveRightToolStripMenuItem;
    }
}

