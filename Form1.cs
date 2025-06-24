using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Documents\\LIBRARY MANAGEMENT SYSTEM.mdf\";Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; // Hide password by default
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter both username and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string query = "SELECT * FROM admin WHERE username = @username AND password = @password";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Login successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login unsuccessful. Please check your username and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }
    }
}
