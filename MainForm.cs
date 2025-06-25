using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace librarysystem2
{
    public partial class MainForm : Form
    {
        private static List<CartItem> Cart = new List<CartItem>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => CheckAndAddToCart(button1.Text, (int)numericUpDown1.Value);
        private void button4_Click(object sender, EventArgs e) => CheckAndAddToCart(button4.Text, (int)numericUpDown2.Value);
        private void button5_Click(object sender, EventArgs e) => CheckAndAddToCart(button5.Text, (int)numericUpDown3.Value);
        private void button6_Click(object sender, EventArgs e) => CheckAndAddToCart(button6.Text, (int)numericUpDown4.Value);
        private void button7_Click(object sender, EventArgs e) => CheckAndAddToCart(button7.Text, (int)numericUpDown5.Value);
        private void button8_Click(object sender, EventArgs e) => CheckAndAddToCart(button8.Text, (int)numericUpDown6.Value);
        private void button9_Click(object sender, EventArgs e) => CheckAndAddToCart(button9.Text, (int)numericUpDown8.Value);
        private void button10_Click(object sender, EventArgs e) => CheckAndAddToCart(button10.Text, (int)numericUpDown9.Value);

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => AddToCart(button1.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) => AddToCart(button4.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown3_ValueChanged(object sender, EventArgs e) => AddToCart(button5.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown4_ValueChanged(object sender, EventArgs e) => AddToCart(button6.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown5_ValueChanged(object sender, EventArgs e) => AddToCart(button7.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown6_ValueChanged(object sender, EventArgs e) => AddToCart(button8.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown8_ValueChanged(object sender, EventArgs e) => AddToCart(button9.Text, (int)((NumericUpDown)sender).Value);
        private void numericUpDown9_ValueChanged(object sender, EventArgs e) => AddToCart(button10.Text, (int)((NumericUpDown)sender).Value);

        private void CheckAndAddToCart(string itemName, int qty)
        {
            if (qty > 1)
            {
                AddToCart(itemName, qty, redirect: true);
            }
            else
            {
                MessageBox.Show("Please select more than 1 item to proceed to checkout.", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart(string itemName, int qty, bool redirect = false)
        {
            if (qty <= 0)
            {
                MessageBox.Show("Please select at least one item before adding to cart.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cart.Add(new CartItem(itemName, qty));

            MessageBox.Show($"{qty} × \"{itemName}\" added to cart successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (redirect)
            {
                var checkout = new LastPage();
                checkout.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Placeholder
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var checkout = new LastPage();
            checkout.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME hOME = new HOME();
            hOME.Show();
            this.Hide();
        }
    }

    public class CartItem
    {
        public string Item { get; }
        public int Quantity { get; }

        public CartItem(string item, int qty)
        {
            Item = item;
            Quantity = qty;
        }
    }
}
