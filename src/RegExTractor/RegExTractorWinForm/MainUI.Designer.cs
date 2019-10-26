namespace RegExTractorWinForm
{
    partial class RegExTractorMainUI
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchDirectory = new System.Windows.Forms.TextBox();
            this.bntSelectDirectory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxRecursive = new System.Windows.Forms.CheckBox();
            this.tBoxFileFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxSearchTermFile = new System.Windows.Forms.TextBox();
            this.btnSelectSearchTermFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxOutputFile = new System.Windows.Forms.TextBox();
            this.btnSelectOutputFile = new System.Windows.Forms.Button();
            this.btnDoWork = new System.Windows.Forms.Button();
            this.ctxMenuMainUi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.überToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuMainUi.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory to be searched";
            // 
            // tbSearchDirectory
            // 
            this.tbSearchDirectory.Location = new System.Drawing.Point(23, 35);
            this.tbSearchDirectory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSearchDirectory.Name = "tbSearchDirectory";
            this.tbSearchDirectory.Size = new System.Drawing.Size(294, 20);
            this.tbSearchDirectory.TabIndex = 1;
            // 
            // bntSelectDirectory
            // 
            this.bntSelectDirectory.Location = new System.Drawing.Point(321, 31);
            this.bntSelectDirectory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntSelectDirectory.Name = "bntSelectDirectory";
            this.bntSelectDirectory.Size = new System.Drawing.Size(25, 27);
            this.bntSelectDirectory.TabIndex = 2;
            this.bntSelectDirectory.Text = "...";
            this.bntSelectDirectory.UseVisualStyleBackColor = true;
            this.bntSelectDirectory.Click += new System.EventHandler(this.bntSelectDirectory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Filter";
            // 
            // checkBoxRecursive
            // 
            this.checkBoxRecursive.AutoSize = true;
            this.checkBoxRecursive.Location = new System.Drawing.Point(23, 58);
            this.checkBoxRecursive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxRecursive.Name = "checkBoxRecursive";
            this.checkBoxRecursive.Size = new System.Drawing.Size(156, 17);
            this.checkBoxRecursive.TabIndex = 5;
            this.checkBoxRecursive.Text = "Search directory recursively";
            this.checkBoxRecursive.UseVisualStyleBackColor = true;
            // 
            // tBoxFileFilter
            // 
            this.tBoxFileFilter.Location = new System.Drawing.Point(23, 102);
            this.tBoxFileFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBoxFileFilter.Name = "tBoxFileFilter";
            this.tBoxFileFilter.Size = new System.Drawing.Size(294, 20);
            this.tBoxFileFilter.TabIndex = 6;
            this.tBoxFileFilter.Text = "*.*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File with regular search expressions";
            // 
            // tBoxSearchTermFile
            // 
            this.tBoxSearchTermFile.Location = new System.Drawing.Point(23, 150);
            this.tBoxSearchTermFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBoxSearchTermFile.Name = "tBoxSearchTermFile";
            this.tBoxSearchTermFile.Size = new System.Drawing.Size(294, 20);
            this.tBoxSearchTermFile.TabIndex = 8;
            // 
            // btnSelectSearchTermFile
            // 
            this.btnSelectSearchTermFile.Location = new System.Drawing.Point(321, 145);
            this.btnSelectSearchTermFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectSearchTermFile.Name = "btnSelectSearchTermFile";
            this.btnSelectSearchTermFile.Size = new System.Drawing.Size(25, 27);
            this.btnSelectSearchTermFile.TabIndex = 9;
            this.btnSelectSearchTermFile.Text = "...";
            this.btnSelectSearchTermFile.UseVisualStyleBackColor = true;
            this.btnSelectSearchTermFile.Click += new System.EventHandler(this.btnSelectSearchTermFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Output File";
            // 
            // tBoxOutputFile
            // 
            this.tBoxOutputFile.Location = new System.Drawing.Point(23, 195);
            this.tBoxOutputFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBoxOutputFile.Name = "tBoxOutputFile";
            this.tBoxOutputFile.Size = new System.Drawing.Size(294, 20);
            this.tBoxOutputFile.TabIndex = 11;
            // 
            // btnSelectOutputFile
            // 
            this.btnSelectOutputFile.Location = new System.Drawing.Point(321, 191);
            this.btnSelectOutputFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectOutputFile.Name = "btnSelectOutputFile";
            this.btnSelectOutputFile.Size = new System.Drawing.Size(25, 27);
            this.btnSelectOutputFile.TabIndex = 12;
            this.btnSelectOutputFile.Text = "...";
            this.btnSelectOutputFile.UseVisualStyleBackColor = true;
            this.btnSelectOutputFile.Click += new System.EventHandler(this.btnSelectOutputFile_Click);
            // 
            // btnDoWork
            // 
            this.btnDoWork.Location = new System.Drawing.Point(23, 232);
            this.btnDoWork.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoWork.Name = "btnDoWork";
            this.btnDoWork.Size = new System.Drawing.Size(95, 26);
            this.btnDoWork.TabIndex = 13;
            this.btnDoWork.Text = "Start Search";
            this.btnDoWork.UseVisualStyleBackColor = true;
            this.btnDoWork.Click += new System.EventHandler(this.btnDoWork_Click);
            // 
            // ctxMenuMainUi
            // 
            this.ctxMenuMainUi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.überToolStripMenuItem});
            this.ctxMenuMainUi.Name = "ctxMenuMainUi";
            this.ctxMenuMainUi.Size = new System.Drawing.Size(118, 26);
            // 
            // überToolStripMenuItem
            // 
            this.überToolStripMenuItem.Name = "überToolStripMenuItem";
            this.überToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.überToolStripMenuItem.Text = "about ...";
            this.überToolStripMenuItem.Click += new System.EventHandler(this.überToolStripMenuItem_Click);
            // 
            // RegExTractorMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDoWork);
            this.Controls.Add(this.btnSelectOutputFile);
            this.Controls.Add(this.tBoxOutputFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectSearchTermFile);
            this.Controls.Add(this.tBoxSearchTermFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBoxFileFilter);
            this.Controls.Add(this.checkBoxRecursive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntSelectDirectory);
            this.Controls.Add(this.tbSearchDirectory);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegExTractorMainUI";
            this.Size = new System.Drawing.Size(375, 277);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegExTractorMainUI_MouseClick);
            this.ctxMenuMainUi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearchDirectory;
        private System.Windows.Forms.Button bntSelectDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxRecursive;
        private System.Windows.Forms.TextBox tBoxFileFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxSearchTermFile;
        private System.Windows.Forms.Button btnSelectSearchTermFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBoxOutputFile;
        private System.Windows.Forms.Button btnSelectOutputFile;
        private System.Windows.Forms.Button btnDoWork;
        private System.Windows.Forms.ContextMenuStrip ctxMenuMainUi;
        private System.Windows.Forms.ToolStripMenuItem überToolStripMenuItem;

    }
}
