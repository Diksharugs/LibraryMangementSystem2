using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class LastPage : Form
    {
        public LastPage()
        {
            InitializeComponent();
        }

        private void BookIDTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BookTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MemberIDTextBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            
            MainForm home = new MainForm();
            home.Show();
            this.Close(); 
        }

        private void PayCashAtCounterbtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(BookIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(BookTitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(MemberIDTextBox.Text))
            {
                MessageBox.Show("Please fill in all the fields before proceeding.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Checkout confirmed! Please pay cash at the counter with your member id.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            BookIDTextBox.Clear();
            BookTitleTextBox.Clear();
            MemberIDTextBox.Clear();
        }
    }
}
