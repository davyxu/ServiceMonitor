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
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLneTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.btnWorkDir = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMenu.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(804, 426);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // logMenu
            // 
            this.logMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.ShowLneTextToolStripMenuItem,
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
            this.logMenu.Size = new System.Drawing.Size(160, 242);
            this.logMenu.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTab_Opening);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem7.Text = "复制行文字(&O)";
            // 
            // ShowLneTextToolStripMenuItem
            // 
            this.ShowLneTextToolStripMenuItem.Name = "ShowLneTextToolStripMenuItem";
            this.ShowLneTextToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ShowLneTextToolStripMenuItem.Text = "显示行文字(&D)";
            this.ShowLneTextToolStripMenuItem.Click += new System.EventHandler(this.ShowLineTextToolStripMenuItem_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "启动参数:";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(231, 438);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(323, 21);
            this.txtArgs.TabIndex = 1;
            this.txtArgs.TextChanged += new System.EventHandler(this.txtArgs_TextChanged);
            // 
            // btnWorkDir
            // 
            this.btnWorkDir.Location = new System.Drawing.Point(560, 436);
            this.btnWorkDir.Name = "btnWorkDir";
            this.btnWorkDir.Size = new System.Drawing.Size(75, 23);
            this.btnWorkDir.TabIndex = 0;
            this.btnWorkDir.Text = "工作目录";
            this.btnWorkDir.UseVisualStyleBackColor = true;
            this.btnWorkDir.Click += new System.EventHandler(this.btnSetWorkDir_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Location = new System.Drawing.Point(641, 436);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(75, 23);
            this.btnStartAll.TabIndex = 0;
            this.btnStartAll.Text = "启动所有";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 436);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Location = new System.Drawing.Point(720, 436);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(75, 23);
            this.btnStopAll.TabIndex = 0;
            this.btnStopAll.Text = "停止所有";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(87, 436);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
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
            // MonitorView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(805, 467);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStartAll);
            this.Controls.Add(this.btnWorkDir);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MonitorView";
            this.Text = "ServiceMonitor 2.4.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.logMenu.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ContextMenuStrip logMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ShowLneTextToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
    }
}

