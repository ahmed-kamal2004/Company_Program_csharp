using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class ViewEmployees : Form
    {
        Controller controllerObj;
        public ViewEmployees()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.SelectAllEmp();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            }

        private void ViewEmployees_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click ( object sender, EventArgs e )
            {
            string salary = textBox1.Text;
            bool valid = Int32.TryParse( salary, out int id);
            if ( valid )
                {
                DataTable data_out = controllerObj.getEmployeesWithSalarylessThan(salary);
                dataGridView1.DataSource = data_out;
                dataGridView1.Refresh();
                }
            else
                {
                MessageBox.Show("InValid Integer");
                }
            }

        private void button1_Click ( object sender, EventArgs e )
            {
            DataTable dt = controllerObj.SelectAllEmp();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            }

        private void button3_Click ( object sender, EventArgs e )
            {
            textBox2.Text = "";
            textBox3.Text = "";
            object output = controllerObj.GetMaxSalary();
            textBox2.Text = output.ToString();
            }

        private void button4_Click ( object sender, EventArgs e )
            {
            textBox2.Text = "";
            textBox3.Text = "";
            object output = controllerObj.GetAverageSalary();
            textBox3.Text = output.ToString();
            }
        }
}
