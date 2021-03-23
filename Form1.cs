using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinformSecurity
{
    public partial class Form1 : Form
    {
        string pass = "0606";
        string path = @"C:\Users\ACER\source\repos\TinhTien\Password\Security.txt";
        public Form1()
        {
            InitializeComponent();
            ShowOK();
            OK.Focus();
        }
        private void getNumber(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 4)
                textBox1.Text += ((Button)sender).Text;
            OK.Focus();
        }
        private void getKeyNumber(object sender, KeyPressEventArgs e)
        {
            if (textBox1.TextLength < 4 && e.KeyChar >= '0' && e.KeyChar <= '9')
                textBox1.Text += e.KeyChar.ToString();
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) EnterPress();
        }
        private void EnterPress()
        {
            if (textBox1.Text == pass)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    DateTime d = DateTime.Now;
                    sw.WriteLine(d + " Đăng nhập thành công");
                    sw.Dispose();
                }
                MessageBox.Show("Đăng nhập thành công", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    DateTime d = DateTime.Now;
                    sw.WriteLine(d + " Đăng nhập thất bại");
                    sw.Dispose();
                }
                MessageBox.Show("Đăng nhập thất bại", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowOK();

            textBox1.Text = "";
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            OK.Focus();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            EnterPress();
        }
        private void ShowOK()
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                listBox1.Items.Add(line);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
