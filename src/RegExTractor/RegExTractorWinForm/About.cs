using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RegExTractorWinForm
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
            HandleMaxThreadOverrideState();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void numericUpDownThread_ValueChanged(object sender, EventArgs e)
        {
            RuntimeSettings.MaxThreads = Convert.ToInt32(numericUpDownThread.Value);
        }

        private void cBoxOverrideMaxThreads_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void HandleMaxThreadOverrideState()
        {
            if (RuntimeSettings.MaxThreads == 4)
            {
                numericUpDownThread.Enabled = false;
                cBoxOverrideMaxThreads.Checked = false;
            }
            else
            {
                numericUpDownThread.Enabled = true;
                cBoxOverrideMaxThreads.Checked = true;
            }

            numericUpDownThread.Value = RuntimeSettings.MaxThreads;
        }

        private void cBoxOverrideMaxThreads_Click(object sender, EventArgs e)
        {
            if (!cBoxOverrideMaxThreads.Checked)
            {
                // Reset max thread if checkbox get unchecked
                RuntimeSettings.MaxThreads = 4;
                HandleMaxThreadOverrideState();
            }
            else
            {
                // Warn user
                MessageBox.Show(this, "Changing maximum threads may\r\nresult in serious stability issues!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownThread.Enabled = true;
            }            
        }

       
    }
}
