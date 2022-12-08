using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATMBankingManagement
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }




        private void Educationtb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void Balancetb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PINtb_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void PINtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void AccNumTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }
        private bool digitValidation(string value)
        {
            bool cek = true;
            if (value.Length < 6)
            {
                return false;
            }
            else
            {
                if (value.Length > 6)
                {
                    return false;
                }
            }
            return cek;
        }

        private void Balancetb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            int bal = 50000;
            if (AccNameTb.Text == "" || Surnametb.Text == "" || AccNumTb.Text == "" || Phonetb.Text == "" || Addresstb.Text == "" || PINtb.Text == "" || Ocupationtb.Text == "")

            {
                MessageBox.Show("Data tidak cukup");
            }
            else if (digitValidation(PINtb.Text) == false)
            {
                MessageBox.Show("PIN harus 6 digit");

            }
            else
            {

                Con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select AccNum from AccountTbl where AccNum = '" + AccNumTb.Text + "'", Con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);



                if (dt.Rows.Count > 0)

                {
                    int check = Convert.ToInt32(AccNumTb.Text);
                    if (check == Convert.ToInt32(dt.Rows[0][0].ToString()))
                    {
                        MessageBox.Show("Nomor Akun sudah dipakai oleh user lain.");
                        Con.Close();
                    }
                }


                else
                {





                    Con.Close();

                    try
                    {
                        Con.Open();
                        string query = "insert into AccountTbl values('" + AccNumTb.Text + "','" + AccNameTb.Text + "','" + Surnametb.Text + "','" + DOBdate.Value.Date + "','" + Phonetb.Text + "','" + Addresstb.Text + "','" + Educationtb.SelectedItem.ToString() + "','" + Ocupationtb.Text + "'," + PINtb.Text + "," + bal + ")";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Berhasil membuat akun!");
                        Con.Close();
                        Login log = new Login();
                        log.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                }
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PINtb.UseSystemPasswordChar = false;
            } else
            {
                PINtb.UseSystemPasswordChar = true;
            }
        }
    }
}
