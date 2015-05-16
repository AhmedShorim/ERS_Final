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
    class Revenue_Report_Model
    {
        public Boolean Print(String user, String fromDate, String toDate)
        {
            SQLConnection.conn.Open();

            SQLConnection.cmd.Parameters.Clear();
            SQLConnection.cmd.CommandText = "select CONCAT('Room ', CAST(Room.R_ID as varchar(10))) as Name,sum(((Room.Price/60)*DATEDIFF(minute,Reservation.StartTime, Reservation.EndTime))) As Profit, 'income' as [type]"
                                            +" From Room"
                                            +" INNER JOIN Reservation on Room.R_ID=Reservation.R_ID"
                                            +" where Reservation.EndTime is NOT NULL and Reservation.StartTime>='" + fromDate + "' and"
                                            +" Reservation.EndTime<='" + toDate + "'"
                                            +" Group by Room.R_ID"
                                            +" UNION"
                                            +" select CONCAT('Catering Income - ', Catering.Name),sum(Catering.Price*Room_Catering.Quantity) As Profit, 'income' as [type]"
                                            +" from Room_Catering"
                                            +" Inner Join Catering on Room_Catering.F_ID=Catering.F_ID"
                                            +" Inner Join Reservation on Reservation.Res_ID=Room_Catering.Res_ID"
                                            + " where Reservation.EndTime is NOT NULL and Reservation.StartTime>='" + fromDate + "' and"
                                            + " Reservation.EndTime<='" + toDate + "'"
                                            +" Group by Catering.Name"
                                            +" UNION"
                                            +" select CONCAT('Catering Cost - ', Catering.Name),(sum(Catering.Cost*Room_Catering.Quantity)*-1) As Profit, 'expense' as [type]"
                                            +" from Room_Catering"
                                            +" Inner Join Catering on Room_Catering.F_ID=Catering.F_ID"
                                            +" Inner Join Reservation on Reservation.Res_ID=Room_Catering.Res_ID"
                                            + " where Reservation.EndTime is NOT NULL and Reservation.StartTime>='" + fromDate + "' and"
                                            + " Reservation.EndTime<='" + toDate + "'"
                                            +" Group by Catering.Name"
                                            +" UNION"
                                            +" select Expense.Description ,(sum(paid)*-1) as Paid, 'expense' as [type]"
                                            +" from Expense"
                                            + " where ExpenseTime >='" + fromDate + "'"
                                            +" group by Expense.Description";
            SQLConnection.cmd.CommandType = CommandType.Text;

            SqlDataReader temp = SQLConnection.cmd.ExecuteReader();

            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
            myReportDocument.Load(@"D:\Documents\CUFE\Semester 8 - Spring 2015\Software Engineering\Project\Entertainment-Rental-Software\Reports\Revenue_Report.rpt");
            myReportDocument.SetDatabaseLogon("ers_user", "12345");
            myReportDocument.SetParameterValue("fromDate", fromDate);
            myReportDocument.SetParameterValue("toDate", toDate);
            myReportDocument.SetParameterValue("user", user);

            if (temp.HasRows)
            {
                Report_Display rd = new Report_Display();
                rd.Text = "Revenue Report";
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
