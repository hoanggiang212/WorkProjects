using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS;
using LMS.DAO;

namespace LMS.UI
{
    public partial class FormListCustomer : Form
    {
        public FormListCustomer()
        {
            InitializeComponent();
        }

        private void FormListCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerList();            
        }

        private void LoadCustomerList()
        {
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
