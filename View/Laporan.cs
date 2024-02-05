using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAS.Controller;
using UAS.Model.Entity;

namespace UAS.View
{
    public partial class Laporan : Form
    {
        private List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();
        private AdminController controllerAdm;
        private AduanController controllerAdu;

        private MahasiswaController controller;
        public Laporan()
        {
            controller = new MahasiswaController();
            controllerAdm = new AdminController();
            controllerAdu = new AduanController();
            InitializeComponent();
            TotalMhs();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TotalMhs()
        {
            var total = controller.ReadAll();
            label1.Text= total.Count.ToString();
            
            var total1 = controllerAdm.ReadAllAdmin();
            var total2 = controllerAdu.ReadAllAduan();
           
            label3.Text = total1.Count.ToString();
            label2.Text = total2.Count.ToString();
        }

        private void Laporan_Load(object sender, EventArgs e)
        {

           
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
