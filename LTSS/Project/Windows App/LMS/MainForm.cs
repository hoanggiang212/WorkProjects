using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.UI;

namespace LMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void viesCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListCustomer f = new FormListCustomer();
            f.MdiParent = this;
            f.Show();

        }

        private void tạoMớiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormCreateCustomer f = new FormCreateCustomer();
            //f.MdiParent = this;
            //f.Show();
            
        }
    }
}
