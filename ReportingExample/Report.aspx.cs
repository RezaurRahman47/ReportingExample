using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace ReportingExample
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }

       

        private void ShowReport()
        {
            ReportViewer1.Reset();

            ReportDataSource getDataSource = new ReportDataSource("Employee", GeTable());

            ReportViewer1.LocalReport.DataSources.Add(getDataSource);

            ReportViewer1.LocalReport.ReportPath = "EmployeeReport.rdlc";

            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GeTable()
        {
            DataTable dataTable= new DataTable();

            string query = "SELECT * FROM Employee";

            string connectionString = @"Data Source = REMON-PC\SQLEXPRESS; Database= EmployeeSalary; Integrated Security=true;";
            
            SqlConnection connection = new SqlConnection(connectionString);
            
            SqlCommand command = new SqlCommand(query,connection);
            
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            dataTable.Load(reader);

            return dataTable;
        }
    }
}