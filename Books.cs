using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace librarysystem2
{
    // Upon pressing the books button, users can navigate the books available to loan or buy.
    public partial class Books : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Documents\\LIBRARY MANAGEMENT SYSTEM.mdf\";Integrated Security=True;Connect Timeout=30");

        public Books()
        {
            InitializeComponent();
            this.Load += Books_Load;
            button1.Click += button1_Click; // Add
            button2.Click += button2_Click; // Update
            button3.Click += button3_Click; // Reset
            button4.Click += button4_Click; // Delete
            button5.Click += button5_Click; // Home
        }

        private void Books_Load(object sender, EventArgs e)
        {
            DisplayBooks();
        }

        private void DisplayBooks()
        {
            try
            {
                if (Con.State != ConnectionState.Open)
                    Con.Open();

                string query = "SELECT * FROM Bookstbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BookIDtextBox.Text == "" || BookTitletextbox.Text == "" || Authortextbox.Text == "" || Genretextbox.Text == "" || Yeartextbox.Text == "")
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                Con.Open();
                string query = "INSERT INTO Bookstbl (BookID, [Book Title], Author, Genre, Year) VALUES (@BookID, @BookTitle, @Author, @Genre, @Year)";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@BookID", BookIDtextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@BookTitle", BookTitletextbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Author", Authortextbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Genre", Genretextbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Year", Yeartextbox.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Added Successfully");
                DisplayBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding book: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BookIDtextBox.Text == "")
            {
                MessageBox.Show("Enter Book ID to update");
                return;
            }

            try
            {
                Con.Open();
                string query = "UPDATE Bookstbl SET [Book Title]=@BookTitle, Author=@Author, Genre=@Genre, Year=@Year WHERE BookID=@BookID";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@BookID", BookIDtextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@BookTitle", BookTitletextbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Author", Authortextbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Genre", Genretextbox.Text.Trim());
                cmd.Parameters.AddWithValue("@Year", Yeartextbox.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Updated Successfully");
                DisplayBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BookIDtextBox.Text == "")
            {
                MessageBox.Show("Enter Book ID to delete");
                return;
            }

            try
            {
                Con.Open();
                string query = "DELETE FROM Bookstbl WHERE BookID=@BookID";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@BookID", BookIDtextBox.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Deleted Successfully");
                DisplayBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookIDtextBox.Clear();
            BookTitletextbox.Clear();
            Authortextbox.Clear();
            Genretextbox.Clear();
            Yeartextbox.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
