using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;



namespace RefillingStation
{
    public partial class LogFormcs : Form
    {
        public LogFormcs()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string DatePicked = dateTimePicker1.Value.ToShortDateString();
            string monthPicked = dateTimePicker1.Value.Month.ToString();
            string yearPicked = dateTimePicker1.Value.Year.ToString();
            string appFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string dbFile = Path.Combine(appFolder, "RefillingStationDatabase.sdf");
            string ConnectionString = String.Format(@"Data Source={0}", dbFile);
            SqlCeConnection conn = new SqlCeConnection(ConnectionString);
            //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\marvic\Documents\WaterForLess Edited\RefillingStation\RefillingStationDatabase.sdf");
            conn.Open();
            SqlCeCommand cmd = new SqlCeCommand("Select id,TotalAmountPrice, Date, Time FROM LogTable Where Date = @Date", conn);
            cmd.Parameters.AddWithValue("@Date", DatePicked);
            SqlCeCommand cmdmonth = new SqlCeCommand("SELECT SUM(TotalAmountPrice) AS OverAllPrice FROM LogTable Where Month = @Month AND Year = @Year ", conn);
            cmdmonth.Parameters.AddWithValue("@Month", monthPicked);
            cmdmonth.Parameters.AddWithValue("@Year", yearPicked);
            SqlCeDataReader reader = cmdmonth.ExecuteReader();
            while (reader.Read())
            {
                string totalprice = reader["OverAllPrice"].ToString();
                MonthlyTotalTB.Text = totalprice;
            }
            reader.Close();
            SqlCeCommand cmdyear = new SqlCeCommand("SELECT SUM(TotalAmountPrice) AS OverAllPrice FROM LogTable Where Year = @Year", conn);
            cmdyear.Parameters.AddWithValue("@Year", yearPicked);
            SqlCeDataReader yearreader = cmdyear.ExecuteReader();
            while (yearreader.Read())
            {
                string totalpriceperyear = yearreader["OverAllPrice"].ToString();
                TotalYearlyTB.Text = totalpriceperyear;
            }
            yearreader.Close();
            

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void LogFormcs_Load(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToShortDateString();
            string Month = DateTime.Now.Month.ToString();
            string Year = DateTime.Now.Year.ToString();
            string appFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string dbFile = Path.Combine(appFolder, "RefillingStationDatabase.sdf");
            string ConnectionString = String.Format(@"Data Source={0}", dbFile);
            SqlCeConnection conn = new SqlCeConnection(ConnectionString);
            //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\marvic\Documents\WaterForLess Edited\RefillingStation\RefillingStationDatabase.sdf");
            conn.Open();
            SqlCeCommand cmd = new SqlCeCommand("Select id, TotalAmountPrice, Date, Time FROM LogTable Where Date = @Date", conn);
            cmd.Parameters.AddWithValue("@Date", Date);
            SqlCeCommand cmdmonth = new SqlCeCommand("SELECT SUM(TotalAmountPrice) AS OverAllPrice FROM LogTable Where Month = @Month AND Year = @Year ", conn);
            cmdmonth.Parameters.AddWithValue("@Month", Month);
            cmdmonth.Parameters.AddWithValue("@Year", Year);
            SqlCeDataReader reader = cmdmonth.ExecuteReader();
            while (reader.Read())
            {
                string totalprice = reader["OverAllPrice"].ToString();
                MonthlyTotalTB.Text = totalprice;
            }
            reader.Close();
            SqlCeCommand cmdyear = new SqlCeCommand("SELECT SUM(TotalAmountPrice) AS OverAllPrice FROM LogTable Where Year = @Year", conn);
            cmdyear.Parameters.AddWithValue("@Year", Year);
            SqlCeDataReader yearreader = cmdyear.ExecuteReader();
            while (yearreader.Read())
            {
                string totalpriceperyear = yearreader["OverAllPrice"].ToString();
                TotalYearlyTB.Text = totalpriceperyear;
            }
            yearreader.Close();
            

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ClsPrint printdata = new ClsPrint(dataGridView1, "header doc text");
            printdata.PrintForm();

        }

        private void LogFormcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
        }

    }
}
