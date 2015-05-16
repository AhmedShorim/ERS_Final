using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ERS
{
    class Catering_Report_Model
    {
        public DataSet LoadItems()
        {
            SQLConnection.conn.Open();

            DataSet ds = new DataSet();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select Name, F_ID from Catering where Deleted = 0;";
            SQLConnection.cmd.CommandType = CommandType.Text;
            SQLConnection.adapter.SelectCommand = SQLConnection.cmd;
            SQLConnection.adapter.Fill(ds);
            SQLConnection.cmd.Parameters.Clear();

            SQLConnection.conn.Close();

            return ds;
        }

        public Boolean PrintOne(String user, String ID, String ItemName, String fromDate, String toDate)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select CONVERT(date, Reservation.StartTime) as ResDate, Catering.Name, Room_Catering.Quantity, Catering.Price from Room_Catering, Reservation, Catering where Room_Catering.F_ID = " + ID + " AND CONVERT(date, StartTime) > CONVERT(date, CAST('" + fromDate + "' AS DATETIME)) AND CONVERT(date, StartTime) < CONVERT(date, CAST('" + toDate + "' AS DATETIME))";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();

            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@"D:\Documents\CUFE\Semester 8 - Spring 2015\Software Engineering\Project\Entertainment-Rental-Software\Reports\Catering_OneItem_Report.rpt");
            myReportDocument.SetDatabaseLogon("ers_user", "12345");
            myReportDocument.SetParameterValue("fromDate", fromDate);
            myReportDocument.SetParameterValue("toDate", toDate);
            myReportDocument.SetParameterValue("fromDate1", fromDate);
            myReportDocument.SetParameterValue("toDate1", toDate);
            myReportDocument.SetParameterValue("ID", ID);
            myReportDocument.SetParameterValue("user", user);

            if (temp.HasRows)
            {
                Report_Display rd = new Report_Display();
                rd.Text = "Catering Report";
                rd.crystalReportViewer1.ReportSource = myReportDocument;
                rd.Show();
                SQLConnection.conn.Close();
                return true;
            }
            else
            {
                SQLConnection.conn.Close();
                return false;
            }
        }

        public Boolean PrintAll(String user, String fromDate, String toDate)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select CONVERT(date, Reservation.StartTime) as ResDate, Catering.Name, Room_Catering.Quantity, Catering.Price from Room_Catering, Reservation, Catering where CONVERT(date, StartTime) > CONVERT(date, CAST('" + fromDate + "' AS DATETIME)) AND CONVERT(date, StartTime) < CONVERT(date, CAST('" + toDate + "' AS DATETIME))";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();

            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@"D:\Documents\CUFE\Semester 8 - Spring 2015\Software Engineering\Project\Entertainment-Rental-Software\Reports\Catering_Report.rpt");
            myReportDocument.SetDatabaseLogon("ers_user", "12345");
            myReportDocument.SetParameterValue("fromDate", fromDate);
            myReportDocument.SetParameterValue("toDate", toDate);
            myReportDocument.SetParameterValue("fromDate1", fromDate);
            myReportDocument.SetParameterValue("toDate1", toDate);
            myReportDocument.SetParameterValue("user", user);

            if (temp.HasRows)
            {
                Report_Display rd = new Report_Display();
                rd.Text = "Catering Report";
                rd.crystalReportViewer1.ReportSource = myReportDocument;
                rd.Show();
                SQLConnection.conn.Close();
                return true;
            }
            else
            {
                SQLConnection.conn.Close();
                return false;
            }
        }
    }
}