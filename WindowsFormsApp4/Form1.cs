using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    { // Rasuch Database project
        private DataSet myDS = new DataSet();
        private int nRow = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            nRow = 0;
            LoadFormData();
        }

        private void btnPrior_Click(object sender, EventArgs e)
        {
            nRow--;
            if (nRow < 0)
                nRow = 0;

            LoadFormData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            nRow++;
            if (nRow > myDS.Tables[0].Rows.Count - 1)
                nRow = myDS.Tables[0].Rows.Count - 1;
            LoadFormData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            nRow = myDS.Tables[0].Rows.Count - 1;
            LoadFormData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter myDA = new OleDbDataAdapter();
            OleDbCommand myCommand = new OleDbCommand();
            OleDbConnection myConnection = new OleDbConnection();

            myConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\delus\\Documents\\Database1.accdb";
            myCommand.CommandText = "SELECT Employees.ID, Employees.LastName, Employees.FirstName, Employees.Address1, Employees.Address2, Employees.City, Employees.State, Employees.Zip, Employees.PhoneNumber, Employees.DateBirth, Employees.DateHire, Employees.ActiveInd, DeptLookUp.[Desc], JobLookUp.[Desc] AS Expr1 FROM((DeptLookUp INNER JOIN Employees ON DeptLookUp.ID = Employees.DeptCode) INNER JOIN JobLookUp ON Employees.JobCode = JobLookUp.Code)";
            myCommand.Connection = myConnection;
            myDA.SelectCommand = myCommand;
            myDA.Fill(myDS);

            nRow = 0;
            LoadFormData();
        }
    

        private void LoadFormData()
        {
            txtEmpID.Text = myDS.Tables[0].Rows[nRow]["ID"].ToString();
            txtFirstName.Text = myDS.Tables[0].Rows[nRow]["FirstName"].ToString();
            txtLastName.Text = myDS.Tables[0].Rows[nRow]["LastName"].ToString();
            txtAddress1.Text = myDS.Tables[0].Rows[nRow]["Address1"].ToString();
            txtAddress2.Text = myDS.Tables[0].Rows[nRow]["Address2"].ToString();
            txtCity.Text = myDS.Tables[0].Rows[nRow]["City"].ToString();
            txtState.Text = myDS.Tables[0].Rows[nRow]["State"].ToString();
            txtZIP.Text = myDS.Tables[0].Rows[nRow]["ZIP"].ToString();
            txtPhoneNumber.Text = myDS.Tables[0].Rows[nRow]["PhoneNumber"].ToString();
            txtDOB.Text = myDS.Tables[0].Rows[nRow]["DateBirth"].ToString();
            txtDOH.Text = myDS.Tables[0].Rows[nRow]["DateHire"].ToString();
            txtDept.Text = myDS.Tables[0].Rows[nRow]["Desc"].ToString();
            txtJob.Text = myDS.Tables[0].Rows[nRow]["Expr1"].ToString();
            checkBox1.Checked = (bool)myDS.Tables[0].Rows[nRow]["ActiveInd"];
            
        }
    }
    
    
}
