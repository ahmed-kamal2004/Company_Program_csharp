using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

      
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        public DataTable SelectAllEmp()
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }


        public int InsertProject(string Pname, int pnumber, string Plocation, int Dnum)
        {
            string query = "INSERT INTO Project (Pname, Pnumber, Plocation, Dnum)" +
                            "Values ('" + Pname + "'," + pnumber + ",'" + Plocation + "'," + Dnum + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectDepNum()
        {
            string query= "SELECT Dnumber FROM Department;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectDepLoc()
        {
            string query = "SELECT DISTINCT Dlocation FROM Dept_Locations;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectProject(string location)
        {
            string query = "SELECT Pname,Dname FROM Department D, Project P, Dept_Locations L"
             +" where P.Dnum=D.Dnumber and L.Dnumber=D.Dnumber and L.Dlocation='"+location+"';"; 
            
            return dbMan.ExecuteReader(query);
        }
        public DataTable getEmployeesWithSalarylessThan(string salary )
        {

            string query = "SELECT SSN, Fname FROM Employee WHERE Salary < "+salary+"; ";
            return dbMan.ExecuteReader(query);

        }
        public object GetAverageSalary ()
            {
            string query = "SELECT AVG(salary) FROM Employee;";
            return dbMan.ExecuteScalar(query);
            }
        public object GetMaxSalary ()
            {
            string query = "SELECT Max(salary) FROM Employee;";
            return dbMan.ExecuteScalar(query);
            }
        public void InsertDepartment(string dname,string dnumber,string mgr_ssn,string mgr_start_date )
            {
            string query = "Insert INTO Department(Dname,Dnumber,Mgr_SSN,Mgr_Start_Date) VALUES ('"+dname+"',"+dnumber+","+mgr_ssn+",'"+mgr_start_date+"');";
            dbMan.ExecuteNonQuery(query);
            }
        public DataTable GetDepartments ()
            {
            string query = "SELECT * FROM Department";
            return dbMan.ExecuteReader(query);
            }
        public void AddLocation(string dnumber,string dlocation )
            {
            string query = "INSERT INTO Dept_Locations (Dnumber,Dlocation) VALUES("+dnumber+",'"+dlocation+"');";
            dbMan.ExecuteNonQuery(query);
            }
        public void ChangeManager(string dnumber,string mgr_ssn,string mgr_start_date )
            {
            string query = "UPDATE Department SET Mgr_SSN = "+mgr_ssn+" WHERE Dnumber = "+dnumber+";";
            dbMan.ExecuteNonQuery(query);
            }
        }
}
