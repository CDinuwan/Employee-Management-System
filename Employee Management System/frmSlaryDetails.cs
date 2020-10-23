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
    public partial class frmSlaryDetails : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        
        public frmSlaryDetails()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddSalary frm = new frmAddSalary(this);
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            try
            {
                if (colName == "Edit")
                {
                    frmAddSalary frm = new frmAddSalary(this);
                    frm.btnSave.Enabled = false;
                    frm.txtEmpId.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.txtName.Text=dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frm.txtSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frm.ShowDialog();
                }
                else if(colName=="Delete")
                {
                    if(MessageBox.Show("Are you sure you want to delete this record?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        con.Open();
                        cm = new SqlCommand("Delete from tblSalary where emp_id like '"+ dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Your record has been successfully deleted!");
                        LoadRecord();
                    }
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public void LoadRecord()
        {
            con.Open();
            dataGridView1.Rows.Clear();
            int i = 1;
            cm = new SqlCommand("Select * from tblSalary", con);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i+=1;
                dataGridView1.Rows.Add(i, dr["emp_id"].ToString(), dr["name"].ToString(), dr["salary"].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
