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
    public partial class Balance : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Balance()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void accountBalance()
        {
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Balance from AccountTbl where AccNum ='"+AccNumLbl.Text+"'",Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Balancelbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            AccNumLbl.Text = Home.AccNumber;
            accountBalance();    
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
