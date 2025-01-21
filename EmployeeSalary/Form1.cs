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

namespace EmployeeSalary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {


            SqlConnection sqlcon = new SqlConnection(@"Data Source=KHALED-0195;Initial Catalog=master;Integrated Security=True;Encrypt=False;");


            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand("select * from EmployeeSalaryTable;", sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            sqlcon.Close();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                
                var salary = Convert.ToInt32(selectedRow.Cells["salary"].Value);

                var totalServiceMonth = Convert.ToInt32(selectedRow.Cells["totalServiceMonth"].Value);
                

              
                var totalSalary = salary * totalServiceMonth;


                this.lblSalary.Text = totalSalary.ToString();
            }
            else
            {
                MessageBox.Show("Please select a row first!" , "selection error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
