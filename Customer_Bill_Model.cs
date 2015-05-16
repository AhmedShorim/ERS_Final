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
    class Customer_Bill_Model
    {
        public String GetCustomer(String Mobile)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select Name from Customer where Mobile = " + Mobile;
            SQLConnection.cmd.CommandType = CommandType.Text;

            Object temp = SQLConnection.cmd.ExecuteScalar();

            SQLConnection.conn.Close();

            if (temp == null)
                return "-1";
            else
                return temp.ToString();
        }

        public int GetResNum(String Mobile, String date)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select C_ID from Customer where Mobile = " + Mobile;
            SQLConnection.cmd.CommandType = CommandType.Text;

            String Cust_ID = SQLConnection.cmd.ExecuteScalar().ToString();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select COUNT(Res_ID) from Reservation where C_ID = " + Cust_ID + " AND EndTime is not NULL AND CONVERT(date, EndTime) = '" + date + "'";
            SQLConnection.cmd.CommandType = CommandType.Text;

            String temp = SQLConnection.cmd.ExecuteScalar().ToString();

            SQLConnection.conn.Close();

            if (temp == "0")
                return -1;
            else
                return int.Parse(temp);
        }

        public String GetReservationDetails(int i, String Mobile, String date)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select C_ID from Customer where Mobile = " + Mobile;
            SQLConnection.cmd.CommandType = CommandType.Text;

            String Cust_ID = SQLConnection.cmd.ExecuteScalar().ToString();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select R_ID, CONVERT(time, EndTime) as ResEndTime"
                                            + " from Reservation"
                                            + " where C_ID = " + Cust_ID
                                            + " AND EndTime is not NULL"
                                            + " AND CONVERT(date, EndTime) = '" + date + "'";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(SQLConnection.cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String ReservationDetail = "Room " + dt.Rows[i]["R_ID"].ToString() + " End Time: " + dt.Rows[i]["ResEndTime"].ToString();

            SQLConnection.conn.Close();

            return ReservationDetail;
        }

        public void Print(String user, String date, String choice, String CustName, String Mobile)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "Select Res_ID from Reservation"
                                            + " where C_ID = 2"
                                            + " AND CONVERT(date, EndTime) = '" + date + "'"
                                            + " AND CONVERT(time, EndTime) = '" + choice.Substring(choice.LastIndexOf("Time: ") + 6, 8) + "'";
            SQLConnection.cmd.CommandType = CommandType.Text;

            String Res_ID = SQLConnection.cmd.ExecuteScalar().ToString();

            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@"D:\Documents\CUFE\Semester 8 - Spring 2015\Software Engineering\Project\Entertainment-Rental-Software\Reports\Customer_Bill.rpt");
            myReportDocument.SetDatabaseLogon("ers_user", "12345");
            myReportDocument.SetParameterValue("ResID", Res_ID);
            myReportDocument.SetParameterValue("Mobile", Mobile);
            myReportDocument.SetParameterValue("CustName", CustName);
            myReportDocument.SetParameterValue("user", user);

            Report_Display rd = new Report_Display();
            rd.Text = "Customer Bill";
            rd.crystalReportViewer1.ReportSource = myReportDocument;
            rd.Show();

            SQLConnection.conn.Close();
        }
    }
}