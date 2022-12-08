using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMBankingManagement
{
    
    public partial class Withdraw : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public string AccNumber = Login.AccNumber;

        public Withdraw()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addtransaction()
        {
            string TrfType = "WithDraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + Amounttb.Text + ",'" + DateTime.Today.Date.ToString() + "')";
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

        int newBalance, oldBalance;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Amounttb.Text == "" )
            {
                MessageBox.Show("Tolong input jumlah withdrawal");
            } else if ( Convert.ToInt32(Amounttb.Text) <= 0)
            {
                MessageBox.Show("Input invalid");
            } else if (Convert.ToInt32(Amounttb.Text) > oldBalance)
            {
                MessageBox.Show("Balance tidak cukup");

            } else if (Convert.ToInt32(Amounttb.Text) == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            } else if (oldBalance == 50000 )
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - Convert.ToInt32(Amounttb.Text)) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - Convert.ToInt32(Amounttb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menarik uang!");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void accountBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Balance from AccountTbl where AccNum ='" + AccNumber + "'", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Balancelbl.Text = "Balance " + oldBalance.ToString();
            Con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }



        private void Withdraw_Load(object sender, EventArgs e)
        {
            accountBalance();
        }
    }
}
