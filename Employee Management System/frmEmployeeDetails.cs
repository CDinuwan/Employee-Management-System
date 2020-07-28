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
    public partial class frmEmployeeDetails : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public frmEmployeeDetails()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadRecord()
        {
            int i;
            dataGridView1.Rows.Clear();
            con.Open();
            cm = new SqlCommand("select * from tblemployee",con);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i=+1;
                dataGridView1.Rows.Add(i, dr["emp_id"].ToString(), dr["name"].ToString(), dr["address"].ToString(), dr["dob"].ToString(), dr["sickness"].ToString(), dr["sex"].ToString(), dr["dateofjoining"].ToString(), dr["telephonenumber"].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if(colName=="Delete")
                {
                    if(MessageBox.Show("Are you sure you want to delete this record?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        con.Open();
                        cm = new SqlCommand("delete from tblemployee where id like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        LoadRecord();
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddEmployee frm = new frmAddEmployee();
            frm.ShowDialog();
        }
    }
}
