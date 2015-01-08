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
    public partial class ChangePriceForm : Form
    {
        public ChangePriceForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        


        private void SavePriceButton_Click(object sender, EventArgs e)
        {
            try
            {
                string appFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string dbFile = Path.Combine(appFolder, "RefillingStationDatabase.sdf");
                string ConnectionString = String.Format(@"Data Source={0}", dbFile);
                SqlCeConnection conn = new SqlCeConnection(ConnectionString);
                //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\marvic\Documents\WaterForLess Edited\RefillingStation\RefillingStationDatabase.sdf");
                conn.Open();
                SqlCeCommand cmdGallon = new SqlCeCommand("UPDATE PriceTable SET Price= @Price Where ServiceItem='Gallon'", conn);
                cmdGallon.Parameters.AddWithValue("@Price", NumUpDownPesoGallon.Value + NumUpDownCentGallon.Value);
                cmdGallon.ExecuteNonQuery();
                SqlCeCommand cmdBottle = new SqlCeCommand("Update PriceTable SET Price= @Price  Where ServiceItem='Bottle'", conn);
                cmdBottle.Parameters.AddWithValue("@Price", NumUpDownPesoBottle.Value + NumUpDownCentBottle.Value);
                cmdBottle.ExecuteNonQuery();
                SqlCeCommand cmdDelivery = new SqlCeCommand("Update PriceTable SET Price= @Price  Where ServiceItem='Delivery'", conn);
                cmdDelivery.Parameters.AddWithValue("@Price", NumUpDownPesoDelivery.Value + NumUpDownCentDelivery.Value);
                cmdDelivery.ExecuteNonQuery();
                SqlCeCommand cmdPurchase = new SqlCeCommand("Update PriceTable SET Price= @Price  Where ServiceItem='Purchase'", conn);
                cmdPurchase.Parameters.AddWithValue("@Price", NumUpDownPesoPurchase.Value + NumUpDownCentPurchase.Value);
                cmdPurchase.ExecuteNonQuery();


            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MainForm m = new MainForm();
                m.Show();
                this.Hide();

            }

        }

        private void ChangePriceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
        }

    }
}