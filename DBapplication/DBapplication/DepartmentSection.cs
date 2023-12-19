using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
    {
    public partial class DepartmentSection : Form
        {
        Controller controller;
        public DepartmentSection ()
            {
            InitializeComponent();
            controller = new Controller ();
            DataTable dt = controller.SelectAllEmp();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "SSN";
            comboBox1.ValueMember = "SSN";
            comboBox1.Refresh();
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "Fname";
            comboBox4.ValueMember = "SSN";
            comboBox4.Refresh();
            dt = controller.GetDepartments();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Dname";
            comboBox2.ValueMember = "Dnumber";
            comboBox2.Refresh();
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Dname";
            comboBox3.ValueMember = "Dnumber";
            comboBox3.Refresh();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        private void button1_Click ( object sender, EventArgs e )
            {
            string dname = textBox1.Text;
            string dnumber = textBox2.Text;
            string mgr_ssn = comboBox1.SelectedValue.ToString();
            if(dname == "" || dnumber =="" || !Int32.TryParse(dnumber,out int d) || !Int32.TryParse(mgr_ssn,out int ssn) )
                {
                MessageBox.Show("Invalid Input");

                }
            else
                {
                DateTime time_now = DateTime.Now;
                string date = time_now.ToString("yyyy-MM-dd");
                try
                    {
                    controller.InsertDepartment(dname, dnumber, mgr_ssn, date);
                    MessageBox.Show("Success");
                    DataTable dt = controller.GetDepartments();
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Dname";
                    comboBox2.ValueMember = "Dnumber";
                    comboBox2.Refresh();
                    comboBox3.DataSource = dt;
                    comboBox3.DisplayMember = "Dname";
                    comboBox3.ValueMember = "Dnumber";
                    comboBox3.Refresh();
                    }
                catch
                    {
                    MessageBox.Show("Invalid Input");
                    }
                }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            }

        private void button2_Click ( object sender, EventArgs e )
            {
            string new_loc = textBox3.Text;
            string dnumber = comboBox2.SelectedValue.ToString();
            if(new_loc == "" )
                {
                MessageBox.Show("Invalid Location");
                }
            else
                {
                controller.AddLocation(dnumber, new_loc);
                MessageBox.Show("Success");
                }
            }

        private void button3_Click ( object sender, EventArgs e )
            {
            string ssn = comboBox4.SelectedValue.ToString();
            string dnumber = comboBox3.SelectedValue.ToString();
            DateTime time_now = DateTime.Now;
            string date = time_now.ToString("yyyy-MM-dd");
            try
                {
                controller.ChangeManager(dnumber, ssn, date);
                MessageBox.Show("Success");
                }
            catch
                {
                MessageBox.Show("Unexpected Error");
                }
            }
        }
    }
