using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegExTractorWinForm
{
    public partial class RegExTractorMainUI: UserControl
    {
        public RegExTractorMainUI()
        {
            InitializeComponent();
        }
        
        private string searchDirectory;
        private bool recursive;
        private string filter;
        private string searchTermFile;
        private string outputFile;


        private void bntSelectDirectory_Click(object sender, EventArgs e)
        {
            SelectDirectory();
        }

        private void SelectDirectory()
        {
            var folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                searchDirectory = folderBrowser.SelectedPath;
                tbSearchDirectory.Text = searchDirectory;
            }
        }

        private void btnSelectSearchTermFile_Click(object sender, EventArgs e)
        {
            SelectSearchTermFile();            
        }

        private void SelectSearchTermFile()
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                searchTermFile = fileDialog.FileName;
                tBoxSearchTermFile.Text = searchTermFile;
            }
        }

        private void btnSelectOutputFile_Click(object sender, EventArgs e)
        {
            SelectOutputFile();
        }

        private void SelectOutputFile()
        {
            var fileDialog = new SaveFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFile = fileDialog.FileName;
                tBoxOutputFile.Text = outputFile;
            }
        }

        private void btnDoWork_Click(object sender, EventArgs e)
        {
            ProgressDialog progress = new ProgressDialog(searchDirectory, checkBoxRecursive.Checked, tBoxFileFilter.Text, searchTermFile, outputFile);
            progress.ShowDialog();
        }
       
    }
}
