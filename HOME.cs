using System;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Loan loan = new Loan();
            loan.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}
