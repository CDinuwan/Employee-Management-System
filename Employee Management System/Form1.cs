﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Width = 45;
            frmDashboad frm = new frmDashboad();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
            btnEmployee.Enabled = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(panel3.Width==45)
            {
                panel3.Width = 250;
                btnEmployee.Enabled = true;
            }
            else
            {
                panel3.Width = 45;
                btnEmployee.Enabled = false;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             frmDashboad frm = new frmDashboad();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEmployeeDetails frm = new frmEmployeeDetails();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            frmSlaryDetails frm = new frmSlaryDetails();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmLogIn frm = new frmLogIn();
            frm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUserSettings frm = new frmUserSettings();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }
    }
}
