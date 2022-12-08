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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ATMBankingManagement
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public static string AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (AccNumtb.Text == "" || PinCodetb.Text == "")
            {
                MessageBox.Show("Input tidak lengkap");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from AccountTbl where AccNum =" + AccNumtb.Text + " AND PIN =" + PinCodetb.Text + "", Con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        AccNumber = AccNumtb.Text;
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                        Con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nomor Akun atau PIN Anda Salah");
                    }
                    Con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    Con.Close();
                }
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

       
        private void AccNumtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void PinCodetb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                PinCodetb.UseSystemPasswordChar = false;
            }
            else
            {
                PinCodetb.UseSystemPasswordChar = true;
            }
        }
    }
}
