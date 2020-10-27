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
    public partial class frmLogIn : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public frmLogIn()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyCon());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _username="",_role="",_name = "";
            try
            {
                bool found = false;
                con.Open();
                cm = new SqlCommand("select * from tblUser where username=@username and password=@password", con);
                cm.Parameters.AddWithValue("@username",txtUsername.Text);
                cm.Parameters.AddWithValue("@password", txtPassword.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    found= true;
                    _username = dr["username"].ToString();
                    _role = dr["role"].ToString();
                    _name = dr["name"].ToString();
                }
                else
                {
                    found = false;
                }
                if(found==true)
                {
                    if (_role == "system administrator")
                    {
                        MessageBox.Show("Access granted! Welcome system administrator " + _name, "Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Clear();
                        txtUsername.Clear();
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Access granted! Welcome user " + _name, "Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Clear();
                        txtUsername.Clear();
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.ShowDialog();
                    }
                }else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dr.Close();
                con.Close();
                

            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
