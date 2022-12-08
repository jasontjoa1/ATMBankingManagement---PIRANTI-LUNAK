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
    public partial class FastCash : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public string AccNumber = Login.AccNumber;
        int oldBalance, newBalance;
        public FastCash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void accountBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Balance from AccountTbl where AccNum ='" + AccNumber + "'", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            balanceLabelFC.Text = "Balance " + oldBalance;
            Con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int amountFastCash = 100000;
            if (oldBalance < amountFastCash)
            {
                MessageBox.Show("Balance tidak cukup");

            }
            else if (amountFastCash == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            }
            else if (oldBalance == 50000)
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - amountFastCash) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - amountFastCash;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menarik uang!");
                    Con.Close();
                    addtransaction1();
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int amountFastCash = 200000;

            if (oldBalance < amountFastCash)
            {
                MessageBox.Show("Balance tidak cukup");

            }
            else if (amountFastCash == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            }
            else if (oldBalance == 50000)
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - amountFastCash) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - amountFastCash;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Withdrawn");
                    Con.Close();
                    addtransaction2();
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int amountFastCash = 500000;

            if (oldBalance < amountFastCash)
            {
                MessageBox.Show("Balance tidak cukup");

            }
            else if (amountFastCash == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            }
            else if (oldBalance == 50000)
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - amountFastCash) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - amountFastCash;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Withdrawn");
                    Con.Close();
                    addtransaction3();
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int amountFastCash = 1000000;

            if (oldBalance < amountFastCash)
            {
                MessageBox.Show("Balance tidak cukup");

            }
            else if (amountFastCash == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            }
            else if (oldBalance == 50000)
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - amountFastCash) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - amountFastCash; 
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Withdrawn");
                    Con.Close();
                    addtransaction4();
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

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            int amountFastCash = 1500000;

            if (oldBalance < amountFastCash)
            {
                MessageBox.Show("Balance tidak cukup");

            }
            else if (amountFastCash == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            }
            else if (oldBalance == 50000)
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - amountFastCash) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - amountFastCash;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Withdrawn");
                    Con.Close();
                    addtransaction5();
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

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            int amountFastCash = 2000000;

            if (oldBalance < amountFastCash)
            {
                MessageBox.Show("Balance tidak cukup");

            }
            else if (amountFastCash == oldBalance)
            {
                MessageBox.Show("Balance tidak boleh 0. Maaf Anda tidak dapat menarik uang.");
            }
            else if (oldBalance == 50000)
            {
                MessageBox.Show("Saldo anda minimal. Maaf Anda tidak dapat menarik uang.");
            }
            else if ((oldBalance - amountFastCash) < 50000)
            {
                MessageBox.Show("Maaf Anda tidak dapat menarik uang.\nSaldo Anda akan kurang dari saldo minimum jika Anda melakukannya.");
            }
            else
            {
                newBalance = oldBalance - amountFastCash;
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Withdrawn");
                    Con.Close();
                    addtransaction6();
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

        private void addtransaction1()
        {
            string TrfType = "FastCash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + 100000 + ",'" + DateTime.Today.Date.ToString() + "')";
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

        private void addtransaction2()
        {
            string TrfType = "FastCash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + 200000 + ",'" + DateTime.Today.Date.ToString() + "')";
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

        private void addtransaction3()
        {
            string TrfType = "FastCash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + 500000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction4()
        {
            string TrfType = "FastCash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + 1000000 + ",'" + DateTime.Today.Date.ToString() + "')";
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

        private void addtransaction5()
        {
            string TrfType = "FastCash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + 1500000 + ",'" + DateTime.Today.Date.ToString() + "')";
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

        private void addtransaction6()
        {
            string TrfType = "FastCash";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Login.AccNumber + "','" + TrfType + "'," + 2000000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void FastCash_Load(object sender, EventArgs e)
        {
            accountBalance();
        }
    }
}
