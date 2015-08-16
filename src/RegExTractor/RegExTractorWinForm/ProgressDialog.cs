using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegExTractorModules;
using RegExTractorShared;

namespace RegExTractorWinForm
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            throw new NotImplementedException();
        }

        private RegExTractorSimpleWorkflow workflow;
        private BackgroundWorker backgroundWorker;       

        private string searchDirectory;
        private bool recursive;
        private string filter;
        private string searchTermFile;
        private string outputFile;

        public ProgressDialog(string SearchDirectory, bool Recursive, string Filter, string SearchTermFile, string OutputFile)
        {
            InitializeComponent();
            searchDirectory = SearchDirectory;
            recursive = Recursive;
            filter = Filter;
            searchTermFile = SearchTermFile;
            outputFile = OutputFile;

            workflow = new RegExTractorSimpleWorkflow();
            workflow.SingleFileCrawlFinished += workflow_SingleFileCrawlFinished;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.WorkerSupportsCancellation = true;            

            if (!backgroundWorker.IsBusy) backgroundWorker.RunWorkerAsync();
            
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        

        void workflow_SingleFileCrawlFinished(object sender, ReportProgressEventArgs e)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { workflow_SingleFileCrawlFinished(sender, e); }));
            }
            else labelProgress.Text = e.Message;            
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            workflow.Process(searchDirectory, recursive, filter, searchTermFile, outputFile);
        }      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelAsync();
        }

        private void CancelAsync()
        {
            workflow.CancelAsync();
            this.Text = this.Text + " (Abbruch, bitte warten ...)";
            this.btnCancel.Enabled = false;
        }

        private void ProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                e.Cancel = true;
                MessageBox.Show("Suche läuft ... \r\nZum Abbruch bitte Schaltfläche benutzen!");                
            }
        }
    }
}
