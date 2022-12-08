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
    public partial class History : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        public string AccNumber = Login.AccNumber;
        public History()
        {
            InitializeComponent();
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

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void popout()
        {
            Con.Open();
            string query = "SELECT * from Transactiontbl where AccNum ='" + AccNumber + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            HistoryDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void History_Load(object sender, EventArgs e)
        {

            popout();
        }
    }
}
