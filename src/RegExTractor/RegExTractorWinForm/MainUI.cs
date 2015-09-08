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
             
        private void bntSelectDirectory_Click(object sender, EventArgs e)
        {
            SelectDirectory();
        }

        private void SelectDirectory()
        {
            var folderBrowser = new FolderBrowserDialog();
            // if already a path was set in ui pass it to dialog
            folderBrowser.SelectedPath = tbSearchDirectory.Text;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {            
                tbSearchDirectory.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnSelectSearchTermFile_Click(object sender, EventArgs e)
        {
            SelectSearchTermFile();            
        }

        private void SelectSearchTermFile()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Datei mit Suchbegriffen auswählen";
            fileDialog.Filter = "Text-Dateien|*.txt|Alle Dateien|*.*";


            try
            {
                var initalDir = System.IO.Path.GetDirectoryName(tBoxSearchTermFile.Text);
                fileDialog.InitialDirectory = initalDir;
                fileDialog.FileName = System.IO.Path.GetFileName(tBoxSearchTermFile.Text);
            }
            catch (System.ArgumentException)
            {               
                // Path may be emtpy, do nothing and go ahead
            }

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tBoxSearchTermFile.Text = fileDialog.FileName;                
            }
        }

        private void btnSelectOutputFile_Click(object sender, EventArgs e)
        {
            SelectOutputFile();
        }

        private void SelectOutputFile()
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.Title = "XML Ausgabe speichern unter ...";
            fileDialog.Filter = "XML-Dateien|*.xml|Alle Dateien|*.*";

            try
            {
                var initalDir = System.IO.Path.GetDirectoryName(tBoxOutputFile.Text);
                fileDialog.InitialDirectory = initalDir;
                fileDialog.FileName = System.IO.Path.GetFileName(tBoxOutputFile.Text);
            }
            catch (System.ArgumentException)
            {
                // Path may be emtpy, do nothing and go ahead
            }
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tBoxOutputFile.Text = fileDialog.FileName;                
            }
        }

        private void btnDoWork_Click(object sender, EventArgs e)
        {
            ProgressDialog progress = new ProgressDialog(tbSearchDirectory.Text, checkBoxRecursive.Checked, tBoxFileFilter.Text, tBoxSearchTermFile.Text, tBoxOutputFile.Text);
            progress.ShowDialog();
        }

        private void RegExTractorMainUI_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {                
                ctxMenuMainUi.Show(PointToScreen(e.Location));
            }
        }

        private void überToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutDialog = new About();
            aboutDialog.ShowDialog();
        }
       
    }
}
