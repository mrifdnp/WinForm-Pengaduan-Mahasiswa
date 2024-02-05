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
using UAS.Model.Repository;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UAS.View;

namespace UAS
{
    public partial class Main : Form
    {
       private List<Mahasiswa>  listMahasiswa = new List<Mahasiswa>();

       private MahasiswaController controller;

        FrmAdmin frmAdmin = new FrmAdmin();
        FrmAduan frmAduan = new FrmAduan();


        public Main()
        {
            InitializeComponent();
            controller = new MahasiswaController();
            InisialisasiListView();
         
            LoadData();
         
            HideX();
        }
        private void InisialisasiListView()
        {
            lvMahasiswa.View = System.Windows.Forms.View.Details;
            lvMahasiswa.FullRowSelect = true;
            lvMahasiswa.GridLines = true;
            lvMahasiswa.Columns.Add("No", 35, HorizontalAlignment.Center);
            lvMahasiswa.Columns.Add("NIM", 100, HorizontalAlignment.Center);
            lvMahasiswa.Columns.Add("Nama", 300, HorizontalAlignment.Center);
            lvMahasiswa.Columns.Add("No Telepon", 140, HorizontalAlignment.Center);
            lvMahasiswa.Columns.Add("Program Studi", 150, HorizontalAlignment.Center);
        }

        private void HideX()
        {
            btnRefresh.Hide();
            
        }
        private void LoadData()
        {
            // kosongkan listview
            lvMahasiswa.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listMahasiswa = controller.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var mhs in listMahasiswa)
            {
                var noUrut = lvMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.nim);
                item.SubItems.Add(mhs.nama);
                item.SubItems.Add(mhs.no_telp);
                item.SubItems.Add(mhs.prodi);

                // tampilkan data mhs ke listview
                lvMahasiswa.Items.Add(item);

            }
        }

        private void OnCreateEventHandler(Mahasiswa mhs)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listMahasiswa.Add(mhs);
            int noUrut = lvMahasiswa.Items.Count + 1;
            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mhs.nim);
            item.SubItems.Add(mhs.nama);
            item.SubItems.Add(mhs.no_telp);
            item.SubItems.Add(mhs.prodi);
            // tampilkan data mhs ke listview
            lvMahasiswa.Items.Add(item);

        }
        private void OnUpdateEventHandler(Mahasiswa mhs)
        {
            // ambil index data mhs yang edit
            int index = lvMahasiswa.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lvMahasiswa.Items[index];
            itemRow.SubItems[1].Text = mhs.nim;
            itemRow.SubItems[2].Text = mhs.nama;
            itemRow.SubItems[3].Text = mhs.no_telp;
            itemRow.SubItems[4].Text = mhs.prodi;


        }

        //Button Home
        private void btnHome_Click(object sender, EventArgs e)
        {     
            frmMahasiswa.Hide();
        }




        private void btnProfile_Click(object sender, EventArgs e)
        {

            frmMahasiswa.Hide();
           
        }




        private void btnReport_Click(object sender, EventArgs e)
        {
            frmAdmin.Hide();
            frmMahasiswa.Show();
        }


        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmMahasiswa.Hide();
        }



        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry("Tambah", controller);
            entry.OnCreate += OnCreateEventHandler;
            entry.ShowDialog();
        }


        public Point mouseLocation;


        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvMahasiswa.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Mahasiswa mhs = listMahasiswa[lvMahasiswa.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                Entry entry = new Entry("Edit Data Aduan", mhs, controller);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                entry.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                entry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvMahasiswa.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Mahasiswa mhs = listMahasiswa[lvMahasiswa.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = controller.DeleteMahasiswa(mhs);
                    if (result > 0) LoadData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lvMahasiswa.Items.Clear();
            btnRefresh.Show();

            listMahasiswa = controller.ReadByNama(txtCari.Text);

            foreach (var mhs in listMahasiswa)
            {
                var noUrut = lvMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.nim);
                item.SubItems.Add(mhs.nama);
                item.SubItems.Add(mhs.no_telp);
                item.SubItems.Add(mhs.prodi);

                // tampilkan data mhs ke listview
                lvMahasiswa.Items.Add(item);
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            btnRefresh.Hide();
            txtCari.Text = "";
            
        }
       
        

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            button5.Hide();
            button6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button6.Hide();
            button5.Show();
        }

        private void aduanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }
        /////////
        /////
        ////
        ///
        //
        //


        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void sdaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolLampiran_Click(object sender, EventArgs e)
        {

        }

       

        private void lampiranToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }
     //HIDE SHOW TABEL
         private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            frmProses frmproses = new frmProses();
            frmproses.Show();
            frmAdmin.Hide();
            frmMahasiswa.Hide();
            frmAduan.Hide();
        }
        private void aduanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAdmin.Hide();
            frmMahasiswa.Hide();
            frmAduan.Show();
            frmProses frmproses = new frmProses();
            frmproses.Hide();

        }
        private void lampiranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAduan.Hide();
            frmAdmin.Show();
            frmMahasiswa.Hide();
            frmProses frmproses = new frmProses();
            frmproses.Hide();

        }
        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            frmAdmin.Hide();
            frmMahasiswa.Show();
            frmAduan.Hide();
            frmProses frmproses = new frmProses();
            frmproses.Hide();



        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lampiranToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           Laporan Lapfrm = new Laporan();
            Lapfrm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ingin Logout","LogOut Message",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            FrmLampiran frm = new FrmLampiran();
            frm.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }
    }
    
}
