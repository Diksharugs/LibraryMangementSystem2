using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class Members : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\hp\Documents\LIBRARY MANAGEMENT SYSTEM.mdf"";Integrated Security=True;Connect Timeout=30");
        public Members()
        {
            InitializeComponent();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            DisplayMembers();
        }

        private void DisplayMembers()
        {
            try
            {
                Con.Open();
                string query = "SELECT * FROM MembersTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HOME Home = new HOME();
            Home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberIDtextBox.Text.Trim() == "" || MemberNametextbox.Text.Trim() == "" || ContactNumtextbox.Text.Trim() == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "INSERT INTO MembersTbl (MemberId, MemberName, ContactNo) VALUES (@MemberId, @MemberName, @ContactNo)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@MemberId", MemberIDtextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberName", MemberNametextbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", ContactNumtextbox.Text.Trim());
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    MessageBox.Show("Record added Successfully");
                    DisplayMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberIDtextBox.Text.Trim() == "" || MemberNametextbox.Text.Trim() == "" || ContactNumtextbox.Text.Trim() == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "UPDATE MembersTbl SET MemberName=@MemberName, ContactNo=@ContactNo WHERE MemberId=@MemberId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@MemberName", MemberNametextbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", ContactNumtextbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberId", MemberIDtextBox.Text.Trim());
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    MessageBox.Show("Record Updated Successfully");
                    DisplayMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberIDtextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Enter the ID");
                }
                else
                {
                    Con.Open();
                    string query = "DELETE FROM MembersTbl WHERE MemberId=@MemberId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@MemberId", MemberIDtextBox.Text.Trim());
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    MessageBox.Show("Record deleted Successfully");
                    DisplayMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MemberIDtextBox.Text = " ";
            MemberNametextbox.Text = " ";
            ContactNumtextbox.Text = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MemberIDtextBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                MemberIDtextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                MemberIDtextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }


}
