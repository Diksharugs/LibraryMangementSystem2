using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class SignUp : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Documents\\LIBRARY MANAGEMENT SYSTEM.mdf\";Integrated Security=True;Connect Timeout=30");

        public SignUp()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (email.Text == "" || username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        string checkUsername = "SELECT * FROM admin WHERE username= @username";
                        using (SqlCommand checkuser = new SqlCommand(checkUsername, connect))
                        {
                            checkuser.Parameters.AddWithValue("@username", username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkuser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(username.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO admin(email, username, password, date_created) VALUES (@email, @username, @password, @date)";
                                using (SqlCommand insertCommand = new SqlCommand(insertData, connect))
                                {
                                    insertCommand.Parameters.AddWithValue("@email", email.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@username", username.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@password", password.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@date", DateTime.Now);

                                    insertCommand.ExecuteNonQuery();
                                    MessageBox.Show("Account created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Form1 form1 = new Form1();
                                    form1.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting to database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.UseSystemPasswordChar = false; 
            }
            else
            {
                password.UseSystemPasswordChar = true; 
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
