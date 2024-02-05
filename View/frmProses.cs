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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UAS.View
{
    public partial class frmProses : Form
    {
        private List<Pengaduan> listAduan = new List<Pengaduan>();

        private AduanController controllerAdu;
        public frmProses()
        {
            InitializeComponent();
            controllerAdu = new AduanController();
            IlvAduan();
            LoadDataAduan();
        }

        private void LoadDataAduan()
        {

            // kosongkan listview
            lvAduan.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listAduan = controllerAdu.ReadAllAduan();
            // ekstrak objek mhs dari collection
            foreach (var adu in listAduan)
            {
                var noUrut = lvAduan.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(adu.idPengaduan);
                item.SubItems.Add(adu.tglAdu);
                item.SubItems.Add(adu.tglSelesai);
                item.SubItems.Add(adu.deskAdu);
                item.SubItems.Add(adu.nim);
                item.SubItems.Add(adu.idAdmin);
                item.SubItems.Add(adu.idLampiran);

                // tampilkan data mhs ke listview
                lvAduan.Items.Add(item);

            }

        }
        private void IlvAduan()
        {
            lvAduan.View = System.Windows.Forms.View.Details;
            lvAduan.FullRowSelect = true;
            lvAduan.GridLines = true;
            lvAduan.Columns.Add("No", 35, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Id Pengaduan", 80, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Tanggal Aduan", 150, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Tanggal Selesai", 140, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Deskripsi Aduan", 150, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Pengadu", 150, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Admin", 150, HorizontalAlignment.Center);
            lvAduan.Columns.Add("Lampiran", 150, HorizontalAlignment.Center);

        }

        private void lvAduan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            lvAduan.Items.Clear();
            button7.Show();

            listAduan = controllerAdu.ReadById(cariadu.Text);

            foreach (var adu in listAduan)
            {
                var noUrut = lvAduan.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(adu.idPengaduan);
                item.SubItems.Add(adu.tglAdu);
                item.SubItems.Add(adu.tglSelesai);
                item.SubItems.Add(adu.deskAdu);
                item.SubItems.Add(adu.nim);
                item.SubItems.Add(adu.idAdmin);
                item.SubItems.Add(adu.idLampiran);

                // tampilkan data mhs ke listview
                lvAduan.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadDataAduan();
            button7.Hide();
            cariadu.Text = "";
        }

        private void OnCreateEventHandler(Pengaduan adu)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listAduan.Add(adu);
            int noUrut = lvAduan.Items.Count + 1;
            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(adu.idPengaduan);
            item.SubItems.Add(adu.tglAdu);
            item.SubItems.Add(adu.tglSelesai);
            item.SubItems.Add(adu.deskAdu);
            item.SubItems.Add(adu.nim);
            item.SubItems.Add(adu.idAdmin);
            item.SubItems.Add(adu.idLampiran);
            // tampilkan data mhs ke listview
            lvAduan.Items.Add(item);

        }
        private void OnUpdateEventHandler(Pengaduan adu)
        {
            // ambil index data mhs yang edit
            int index = lvAduan.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lvAduan.Items[index];
            itemRow.SubItems[1].Text = adu.idPengaduan;
            itemRow.SubItems[2].Text = adu.tglAdu;
            itemRow.SubItems[3].Text = adu.tglSelesai;
            itemRow.SubItems[4].Text = adu.deskAdu;
            itemRow.SubItems[5].Text = adu.nim;
            itemRow.SubItems[6].Text = adu.idAdmin;
            itemRow.SubItems[7].Text = adu.idLampiran;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            EntryAduan entryAdu = new EntryAduan("Buat Aduan",controllerAdu);
            entryAdu.OnCreate += OnCreateEventHandler;
            entryAdu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvAduan.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Pengaduan adu = listAduan[lvAduan.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                EntryAduan entryAdu = new EntryAduan("Edit Data Aduan", adu, controllerAdu);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                entryAdu.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                entryAdu.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvAduan.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data aduan ingin dihapus ? ", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Pengaduan adu= listAduan[lvAduan.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = controllerAdu.DeleteAduan(adu);
                    if (result > 0) LoadDataAduan();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data aduan belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
