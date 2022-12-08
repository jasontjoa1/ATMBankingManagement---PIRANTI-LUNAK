using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMBankingManagement
{
    public partial class ChangePin : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public string AccNumber = Login.AccNumber;
        int AccNum = Convert.ToInt32(Login.AccNumber);
        public ChangePin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
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

        private bool validateOldPIN (string oldPIN)
        {
            try
            {
                Con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from AccountTbl where AccNum ="+AccNum+" AND PIN =" + oldPINtb.Text + "", Con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Con.Close();
                    return true;
                }
                else
                {
                    Con.Close();
                    return false;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Con.Close();
            }
            return false;

        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

           
            if (Newtb.Text == "" || Confirmtb.Text == "" || oldPINtb.Text == "")
            {
                MessageBox.Show("Tolong masukkan PIN lama dan konfirmasikan PIN baru");
            } 
            else if (validateOldPIN(oldPINtb.Text) == false)
            {
                MessageBox.Show("Input untuk PIN lama anda salah!");
            }
            else if (digitValidation(Newtb.Text) == false || digitValidation(Confirmtb.Text) == false)
            {
                MessageBox.Show("PIN harus 6 digit");

            }
            else if (Newtb.Text != Confirmtb.Text)
            {
                MessageBox.Show("PIN baru tidak cocok");
            }
            else
            {
                
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set PIN=" + Newtb.Text + " where Accnum='" + AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil mengubah PIN Anda!");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Con.Close();


            }
        }

        private void ChangePin_Load(object sender, EventArgs e)
        {

        }

        private void Newtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void Confirmtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char abc = e.KeyChar;

            if (!char.IsDigit(abc) && abc != 8)
            {
                e.Handled = true;
            }
        }

        private void Newtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                oldPINtb.UseSystemPasswordChar = false;
            }
            else
            {
                oldPINtb.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Newtb.UseSystemPasswordChar = false;
            }
            else
            {
                Newtb.UseSystemPasswordChar = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Confirmtb.UseSystemPasswordChar = false;
            }
            else
            {
                Confirmtb.UseSystemPasswordChar = true;
            }
        }
    }
}
