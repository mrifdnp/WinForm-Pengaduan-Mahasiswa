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
    public partial class FrmAduan : Form
    {
        private List<Pengaduan> listAduan = new List<Pengaduan>();

        private AduanController controllerAdu;
        public FrmAduan()
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

        private void lvAduan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }


