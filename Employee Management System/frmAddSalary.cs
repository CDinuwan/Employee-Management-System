﻿using System;
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
    public partial class frmAddSalary : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmSlaryDetails frm = new frmSlaryDetails();
        public frmAddSalary(frmSlaryDetails f)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyCon());
            frm = f;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("INSERT INTO tblSalary(emp_id,name,salary) values (@emp_id,@name,@salary)", con);
                    cm.Parameters.AddWithValue("@emp_id", txtEmpId.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@salary", txtSalary.Text);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your record is successfully added!");
                    Clear();
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to update this record?","Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("update tblSalary set emp_id=@emp_id,name=@name,salary=@salary", con);
                    cm.Parameters.AddWithValue("@emp_id", txtEmpId.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@salary", txtSalary.Text);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Your record has been successfully updated!");
                    con.Close();
                    Clear();
                    frm.LoadRecord();
                    this.Dispose();
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
