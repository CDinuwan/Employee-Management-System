using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class frmAddEmployee : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();

        public frmAddEmployee()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyCon());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
            txtEmpId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtDob.Clear();
            txtSickness.Clear();
            txtSex.Clear();
            txtdateofjoining.Clear();
            txtContact.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to save this?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("insert into tblEmployee (emp_id,name,address,dob,sickness,sex,dateofjoining,telephonenumber)values(@emp_id,@name,@address,@dob,@sickness,@sex,@dateofjoining,@telephonenumber)", con);
                    cm.Parameters.AddWithValue("@emp_id",txtEmpId.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@dob", txtDob.Text);
                    cm.Parameters.AddWithValue("@sickness", txtSickness.Text);
                    cm.Parameters.AddWithValue("@sex", txtSex.Text);
                    cm.Parameters.AddWithValue("@dateofjoining", txtdateofjoining.Text);
                    cm.Parameters.AddWithValue("@telephonenumber", txtContact.Text);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your record has been successfully added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    this.Dispose();
                }
                
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
