using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class Loan : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Documents\\LIBRARY MANAGEMENT SYSTEM.mdf\";Integrated Security=True;Connect Timeout=30");

        public Loan()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click); // Issue Loan
            this.button2.Click += new System.EventHandler(this.button2_Click); // Clear
            this.button5.Click += new System.EventHandler(this.button5_Click); // Home
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            DisplayLoans();
        }

        private void DisplayLoans()
        {
            try
            {
                if (Con.State != ConnectionState.Open)
                    Con.Open();

                string query = "SELECT * FROM Loantbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading loans: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) // Issue Loan
        {
            if (MemberIDTextBox.Text == "" || MemberNameTextBox.Text == "" ||
                BookIDTextBox.Text == "" || BookTitleTextBox.Text == "")
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                // Validate Book ID
                int bookId;
                if (!int.TryParse(BookIDTextBox.Text.Trim(), out bookId) || bookId < 1 || bookId > 8)
                {
                    MessageBox.Show("Invalid Book ID. Only IDs 1 to 8 are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Con.State != ConnectionState.Open)
                    Con.Open();

                // Check if Member ID exists
                string checkMemberQuery = "SELECT COUNT(*) FROM MembersTbl WHERE MemberId = @MemberId";
                SqlCommand checkMemberCmd = new SqlCommand(checkMemberQuery, Con);
                checkMemberCmd.Parameters.AddWithValue("@MemberId", MemberIDTextBox.Text.Trim());
                int memberExists = (int)checkMemberCmd.ExecuteScalar();

                if (memberExists == 0)
                {
                    MessageBox.Show("Invalid Member ID. Member does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //database
                string query = "INSERT INTO Loantbl (BookID, BookTitle, MemberID, MemberName, LoanDate, DueDate) " +
                               "VALUES (@BookID, @BookTitle, @MemberID, @MemberName, @LoanDate, @DueDate)";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@BookID", bookId);
                cmd.Parameters.AddWithValue("@BookTitle", BookTitleTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@MemberID", MemberIDTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@MemberName", MemberNameTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@LoanDate", LoanDatePicker.Value);
                cmd.Parameters.AddWithValue("@DueDate", DueDatePicker.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Book Loaned Successfully");
                DisplayLoans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error issuing loan: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) // Clear
        {
            MemberIDTextBox.Clear();
            MemberNameTextBox.Clear();
            BookIDTextBox.Clear();
            BookTitleTextBox.Clear();
            LoanDatePicker.Value = DateTime.Today;
            DueDatePicker.Value = DateTime.Today.AddDays(14);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void button6_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void MemberIDTextBox_TextChanged(object sender, EventArgs e) { }

        private void BookIDTextBox_TextChanged(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                if (MemberIDTextBox.Text == "" || MemberNameTextBox.Text == "" ||
                    BookIDTextBox.Text == "" || BookTitleTextBox.Text == "")
                {
                    MessageBox.Show("Missing Information");
                    return;
                }

                try
                {
                    if (!int.TryParse(BookIDTextBox.Text.Trim(), out int bookId) || bookId < 1 || bookId > 8)
                    {
                        MessageBox.Show("Invalid Book ID. Only IDs 1 to 8 are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Con.State != ConnectionState.Open)
                        Con.Open();

                    // Check if Member ID exists
                    string checkMemberQuery = "SELECT COUNT(*) FROM MembersTbl WHERE MemberId = @MemberId";
                    SqlCommand checkMemberCmd = new SqlCommand(checkMemberQuery, Con);
                    checkMemberCmd.Parameters.AddWithValue("@MemberId", MemberIDTextBox.Text.Trim());
                    int memberExists = (int)checkMemberCmd.ExecuteScalar();

                    if (memberExists == 0)
                    {
                        MessageBox.Show("Invalid Member ID. Member does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insert into database
                    string query = "INSERT INTO Loantbl (BookID, BookTitle, MemberID, MemberName, LoanDate, DueDate) " +
                                   "VALUES (@BookID, @BookTitle, @MemberID, @MemberName, @LoanDate, @DueDate)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    cmd.Parameters.AddWithValue("@BookTitle", BookTitleTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberID", MemberIDTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@MemberName", MemberNameTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoanDate", LoanDatePicker.Value);
                    cmd.Parameters.AddWithValue("@DueDate", DueDatePicker.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Book Loaned Successfully");
                    DisplayLoans();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error issuing loan: " + ex.Message);
                }
                finally
                {
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MemberIDTextBox.Clear();
            MemberNameTextBox.Clear();
            BookIDTextBox.Clear();
            BookTitleTextBox.Clear();
            LoanDatePicker.Value = DateTime.Today;
            DueDatePicker.Value = DateTime.Today.AddDays(10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (MemberIDTextBox.Text == "" || BookIDTextBox.Text == "")
                {
                    MessageBox.Show("Enter Member ID and Book ID to delete a loan.");
                    return;
                }

                try
                {
                    if (Con.State != ConnectionState.Open)
                        Con.Open();

                    string query = "DELETE FROM Loantbl WHERE MemberID = @MemberID AND BookID = @BookID";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@MemberID", MemberIDTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@BookID", BookIDTextBox.Text.Trim());
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Loan Deleted Successfully");
                        DisplayLoans();
                    }
                    else
                    {
                        MessageBox.Show("Loan not found with provided Member ID and Book ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting loan: " + ex.Message);
                }
                finally
                {
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookIDTextBox.Text = "";
            BookTitleTextBox.Text = "";
            MemberIDTextBox.Text = "";
            MemberIDTextBox.Text = "";
            LoanDatePicker.Text = DateTime.Now.ToString();
            DueDatePicker.Text = DateTime.Now.ToString();
        }
    }
}
