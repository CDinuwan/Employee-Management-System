using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class frmAddSalary : Form
    {
        public frmAddSalary()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtEmpId.Clear();
            txtName.Clear();
            txtSalary.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
