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
    class Rooms_Report_Model
    {
        public DataSet LoadRooms()
        {
            SQLConnection.conn.Open();

            DataSet ds = new DataSet();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Retrieve_Rooms";
            SQLConnection.cmd.CommandType = CommandType.StoredProcedure;
            SQLConnection.adapter.SelectCommand = SQLConnection.cmd;
            SQLConnection.adapter.Fill(ds);
            SQLConnection.cmd.Parameters.Clear();

            SQLConnection.conn.Close();

            return ds;
        }

        public Boolean Print_One(String user, String ID, String fromDate, String toDate)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID, CONVERT(date, StartTime) as ResDate,  StartTime, EndTime from Reservation where R_ID = " + ID + " AND EndTime is not NULL AND CONVERT(date, StartTime) > CONVERT(date, CAST('" + fromDate + "' AS DATETIME)) AND CONVERT(date, StartTime) < CONVERT(date, CAST('" + toDate + "' AS DATETIME))";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();

            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@"D:\Documents\CUFE\Semester 8 - Spring 2015\Software Engineering\Project\Entertainment-Rental-Software\Reports\Room_Report.rpt");
            myReportDocument.SetDatabaseLogon("ers_user", "12345");
            myReportDocument.SetParameterValue("fromDate", fromDate);
            myReportDocument.SetParameterValue("toDate", toDate);
            myReportDocument.SetParameterValue("ID", ID);
            myReportDocument.SetParameterValue("fromDate1", fromDate);
            myReportDocument.SetParameterValue("toDate1", toDate);
            myReportDocument.SetParameterValue("user", user);

            if (temp.HasRows)
            {
                Report_Display rd = new Report_Display();
                rd.Text = "Room Report";
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

        public Boolean Print_ALL(String user, String fromDate, String toDate)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID, CONVERT(date, StartTime) as ResDate,  StartTime, EndTime from Reservation where EndTime is not NULL AND CONVERT(date, StartTime) > CONVERT(date, CAST('" + fromDate + "' AS DATETIME)) AND CONVERT(date, StartTime) < CONVERT(date, CAST('" + toDate + "' AS DATETIME))";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();
            
            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@"D:\Documents\CUFE\Semester 8 - Spring 2015\Software Engineering\Project\Entertainment-Rental-Software\Reports\Rooms_Report.rpt");
            myReportDocument.SetDatabaseLogon("ers_user", "12345");
            myReportDocument.SetParameterValue("fromDate", fromDate);
            myReportDocument.SetParameterValue("toDate", toDate);
            myReportDocument.SetParameterValue("fromDate1", fromDate);
            myReportDocument.SetParameterValue("toDate1", toDate);
            myReportDocument.SetParameterValue("user", user);

            if (temp.HasRows)
            {
                Report_Display rd = new Report_Display();
                rd.Text = "Rooms Report";
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
