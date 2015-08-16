using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegExTractorWinForm;

namespace ReExTractorWinFormHost
{
    public partial class RegExTractorHostForm : Form
    {
        public RegExTractorHostForm()
        {
            InitializeComponent();
            RegExTractorMainUI ui = new RegExTractorMainUI();
            this.Controls.Add(ui);
            ui.Dock = DockStyle.Fill;
            
            
        }
    }
}
