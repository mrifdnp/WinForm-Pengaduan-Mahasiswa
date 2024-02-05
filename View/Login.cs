using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using UAS.Controller;
using UAS.View;
namespace UAS
{

    public partial class Login : Form
    {
        private string user = "adm";
        private string pass = "1";


        public Login()
        {
            InitializeComponent();
            textBox1.Text = "adm";
            textBox2.Text = "1";
        }

        AdminController adminController = new AdminController();

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

     
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
        }



        private void button1_Click(object sender, EventArgs e)
        {
           

            bool isValidUser = adminController.IsValidUser(textBox1.Text, textBox2.Text);
            if (isValidUser)
            {
                this.DialogResult = DialogResult.OK;

            Main main = new Main();
            main.Show();

            // Sembunyikan form login
            this.Hide();
        }
            

        }


        private bool userpassvalid(string username, string password)
        {
            return username == user && password == pass;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            button3.Show();
            button3.BringToFront(); 
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button3.Hide();
            button3.SendToBack();
            
            textBox2.UseSystemPasswordChar = true;
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
      

        }
    }

       
  }

