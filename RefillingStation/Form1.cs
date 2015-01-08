using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace RefillingStation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string dbFile = Path.Combine(appFolder, "RefillingStationDatabase.sdf");
            string ConnectionString = String.Format(@"Data Source={0}", dbFile);
            SqlCeConnection conn = new SqlCeConnection(ConnectionString);
            //SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\marvic\Documents\WaterForLess Edited\RefillingStation\RefillingStationDatabase.sdf");

            SqlCeCommand cmdGallon = new SqlCeCommand("Select Price FROM PriceTable WHERE ServiceItem = 'Gallon'", conn);
            SqlCeCommand cmdBottle = new SqlCeCommand("Select Price FROM PriceTable WHERE ServiceItem = 'Bottle'", conn);
            SqlCeCommand cmdDelivery = new SqlCeCommand("Select Price FROM PriceTable WHERE ServiceItem = 'Delivery'", conn);
            SqlCeCommand cmdPurchase = new SqlCeCommand("Select Price FROM PriceTable WHERE ServiceItem = 'Purchase'", conn);
            SqlCeCommand cmd = new SqlCeCommand("Select * FROM PriceTable", conn);
            try
            {
                conn.Open();
                SqlCeDataReader dr = cmdGallon.ExecuteReader();
                while (dr.Read())
                {

                    Decimal GallonPriceDecimal = dr.GetDecimal(0);
                    string GallonPriceString = GallonPriceDecimal.ToString();
                    GallonLabel.Text = GallonPriceString;
                }
                dr.Close();
                SqlCeDataReader drBottle = cmdBottle.ExecuteReader();
                while (drBottle.Read())
                {

                    Decimal BottlePriceDecimal = drBottle.GetDecimal(0);
                    string BottlePriceString = BottlePriceDecimal.ToString();
                    BottleLabel.Text = BottlePriceString;
                }
                drBottle.Close();
                SqlCeDataReader drDelivery = cmdDelivery.ExecuteReader();
                while (drDelivery.Read())
                {

                    Decimal DeliveryPriceDecimal = drDelivery.GetDecimal(0);
                    string DeliveryPriceString = DeliveryPriceDecimal.ToString();
                    DeliveryLabel.Text = DeliveryPriceString;
                }
                drDelivery.Close();
                SqlCeDataReader drPurchase = cmdPurchase.ExecuteReader();
                while (drPurchase.Read())
                {

                    Decimal PurchasePriceDecimal = drPurchase.GetDecimal(0);
                    string PurchasePriceString = PurchasePriceDecimal.ToString();
                    PurchaseLabel.Text = PurchasePriceString;
                }
                drPurchase.Close();



            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void numUpdownBottle_ValueChanged(object sender, EventArgs e)
        {
            Double bottlepriceint = Convert.ToDouble(BottleLabel.Text);


            TotalBottlePriceTB.Text = (Convert.ToDouble(numUpdownBottle.Value) * bottlepriceint).ToString();
        }

        private void numUpdownGallon_ValueChanged(object sender, EventArgs e)
        {
            Double gallonpriceint = Convert.ToDouble(GallonLabel.Text);

            TotalGallonPriceTB.Text = (Convert.ToDouble(numUpdownGallon.Value) * gallonpriceint).ToString();
        }

        private void TotalBottlePriceTB_TextChanged(object sender, EventArgs e)
        {
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice + DeliveryPrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice).ToString();
            }
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + DeliveryPrice).ToString();
            }
        }

        private void PickUpRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice + DeliveryPrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice).ToString();
            }
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + DeliveryPrice).ToString();
            }
        }

        private void DeliveryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice + DeliveryPrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice).ToString();
            }
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + DeliveryPrice).ToString();
            }
        }



        private void PurchaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice + DeliveryPrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice).ToString();
            }
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + DeliveryPrice).ToString();
            }
        }

        private void RefillRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice + DeliveryPrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice).ToString();
            }
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + DeliveryPrice).ToString();
            }
        }

        private void TotalGallonPriceTB_TextChanged(object sender, EventArgs e)
        {
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice + DeliveryPrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == true)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double PurchasePrice = Convert.ToDouble(PurchaseLabel.Text) * Convert.ToDouble(numUpdownGallon.Value);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + PurchasePrice).ToString();
            }
            if (PickUpRadioButton.Checked == true && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice).ToString();
            }
            if (PickUpRadioButton.Checked == false && PurchaseRadioButton.Checked == false)
            {
                Double TotalBottlePrice = Convert.ToDouble(TotalBottlePriceTB.Text);
                Double TotalGallonPrice = Convert.ToDouble(TotalGallonPriceTB.Text);
                Double DeliveryPrice = Convert.ToDouble(DeliveryLabel.Text);
                TotalAmountTextBox.Text = (TotalBottlePrice + TotalGallonPrice + DeliveryPrice).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePriceForm m = new ChangePriceForm();
            m.Show();
            this.Hide();
        }

        private void FinalizeTransactionButton_Click(object sender, EventArgs e)
        {
            if (TotalAmountTextBox.Text != "0")
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string timeoftheday = DateTime.Now.ToShortTimeString();
                        string dateoftheday = DateTime.Now.ToShortDateString();
                        string monthoftheday = DateTime.Now.Month.ToString();
                        string yearoftheday = DateTime.Now.Year.ToString();
                        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\marvic\Documents\WaterForLess Edited\RefillingStation\RefillingStationDatabase.sdf");
                        conn.Open();
                        SqlCeCommand cmdInsertLog = new SqlCeCommand("INSERT INTO LogTable (TotalAmountPrice, Date, Time, Month, Year) VALUES (@TotalTransactionPrice, @Date, @Time, @Month, @Year)", conn);
                        cmdInsertLog.Parameters.AddWithValue("@TotalTransactionPrice", TotalAmountTextBox.Text);
                        cmdInsertLog.Parameters.AddWithValue("@Date", dateoftheday);
                        cmdInsertLog.Parameters.AddWithValue("@Time", timeoftheday);
                        cmdInsertLog.Parameters.AddWithValue("@Month", monthoftheday);
                        cmdInsertLog.Parameters.AddWithValue("@Year", yearoftheday);
                        cmdInsertLog.ExecuteNonQuery();
                        MessageBox.Show("Transaction Succesful");
                        numUpdownBottle.ResetText();
                        numUpdownGallon.ResetText();
                        TotalGallonPriceTB.Text = "0";
                        TotalBottlePriceTB.Text = "0";
                        TotalAmountTextBox.Text = "";
                        conn.Close();
                    }
                    catch (SqlCeException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Transaction price cannot be 0");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            
            LogFormcs logform = new LogFormcs();
            logform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PriceListGroupBox.Visible == false && ChangePriceButton.Visible == false)
            {
                PriceListGroupBox.Visible = true;
                ChangePriceButton.Visible = true;
            }
            else
            {
                PriceListGroupBox.Visible = false;
                ChangePriceButton.Visible = false;
            }
        }

        private void PriceListGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are about to Exit","Exit" ,MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK) 
            {
                e.Cancel = false;
            }
            if (dialogResult == DialogResult.Cancel) 
            {
                e.Cancel = true;
            }
        }

        
    }
}
