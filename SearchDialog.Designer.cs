namespace ServiceMonitor
{
    partial class SearchDialog
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
            this.txtMain = new System.Windows.Forms.TextBox();
            this.resultList = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.search = new System.Windows.Forms.Button();
            this.caseSense = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(537, 21);
            this.txtMain.TabIndex = 0;
            this.txtMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMain_KeyPress);
            // 
            // resultList
            // 
            this.resultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultList.FormattingEnabled = true;
            this.resultList.ItemHeight = 12;
            this.resultList.Location = new System.Drawing.Point(0, 0);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(537, 239);
            this.resultList.TabIndex = 1;
            this.resultList.DoubleClick += new System.EventHandler(this.resultList_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.search);
            this.splitContainer1.Panel1.Controls.Add(this.caseSense);
            this.splitContainer1.Panel1.Controls.Add(this.txtMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.resultList);
            this.splitContainer1.Size = new System.Drawing.Size(537, 299);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 2;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(459, 24);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 2;
            this.search.Text = "搜索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // caseSense
            // 
            this.caseSense.AutoSize = true;
            this.caseSense.Location = new System.Drawing.Point(13, 28);
            this.caseSense.Name = "caseSense";
            this.caseSense.Size = new System.Drawing.Size(84, 16);
            this.caseSense.TabIndex = 1;
            this.caseSense.Text = "区分大小写";
            this.caseSense.UseVisualStyleBackColor = true;
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 299);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "搜索";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.CheckBox caseSense;
    }
}