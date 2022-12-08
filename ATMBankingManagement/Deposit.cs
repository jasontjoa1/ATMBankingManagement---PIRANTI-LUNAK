using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMBankingManagement
{
    public partial class Deposit : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public string AccNumber = Login.AccNumber;

        public Deposit()
        {
            InitializeComponent();
        }

        private void addtransaction()
        {
            string TrfType = "Deposit";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + Amounttb.Text + ",'" + DateTime.Today.Date.ToString()+ "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Account Created Successfully");
                Con.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            Con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Amounttb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            int am;
            if (Amounttb.Text == "" || Convert.ToInt32(Amounttb.Text) <= 0)
            {
                MessageBox.Show("Tolong masukkan jumlah uang yang akan disetor");


            }
            else if (!int.TryParse(Amounttb.Text, out am))
            {
                MessageBox.Show("Tolong masukkan jumlah uang yang akan disetor");
                return;
            }
            else if (Convert.ToInt32(Amounttb.Text) < 50000){
                MessageBox.Show("Deposit harus lebih dari Rp.50.000");

            }
            else
            {
                newBalance = oldBalance + Convert.ToInt32(Amounttb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success Deposit");
                    Con.Close();
                    addtransaction();
                    Home home = new Home();
                    home.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int oldBalance, newBalance;
        private void accountBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Balance from AccountTbl where AccNum ='" + AccNumber + "'", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            accountBalance();
        }
}
}
