using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAS.Model.Entity;
using UAS.Controller;


namespace UAS
{
    public partial class Entry : Form
    {
        public delegate void CreateUpdateEventHandler(Mahasiswa mhs);
        

        public  event CreateUpdateEventHandler OnCreate;

        public event CreateUpdateEventHandler OnUpdate;

        private MahasiswaController controller;
       
        private bool isNewData = true;
        
        private Mahasiswa mhs;
        public Entry()
        {
            InitializeComponent();
        }

        public Entry(string title, MahasiswaController controller)
            :this()
        {
            this.Text = title;
            this.controller = controller;
        }

        public Entry(string title, Mahasiswa obj, MahasiswaController controller)
            : this()
        {
            this.Text = title;
            this.controller = controller;

            isNewData = false;
            mhs = obj;

            txtnim.Text = mhs.nim;
            txtNama.Text = mhs.nama;
            txtTelp.Text = mhs.no_telp;
            

            txtProdi.Text = mhs.prodi;
        
        }



        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (isNewData) mhs = new Mahasiswa();


           mhs.nim= txtnim.Text ;
            mhs.nama = txtNama.Text;
            mhs.no_telp =txtTelp.Text;
           mhs.prodi = txtProdi.Text ;

            int result = 0;
            if (isNewData)
            {
               
                result = controller.CreateMahasiswa(mhs);
                if (result >0)
                {
                    OnCreate(mhs);
                    txtnim.Clear();
                    txtNama.Clear();
                    txtTelp.Clear();
                    
                    txtProdi.Clear();
                    txtnim.Focus();
                }
            }
            else
            {
               result = controller.UpdateMahasiswa(mhs);
                if (result > 0)
                {
                    OnUpdate(mhs);
                    this.Close();
                }

            }

        }

   
      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
