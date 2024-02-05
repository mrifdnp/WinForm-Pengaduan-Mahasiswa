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
    public partial class FrmLampiran : Form
    {
        private List<Lampiran> listLam = new List<Lampiran>();

        private LampiranController controllerLam;
        public FrmLampiran()
        {
            InitializeComponent();
            controllerLam = new LampiranController();
            ilvLampiran();
            LoadData();
        }
        public void ilvLampiran()
        {
            lvLampiran.View = System.Windows.Forms.View.Details;
            lvLampiran.FullRowSelect = true;
            lvLampiran.GridLines = true;
            lvLampiran.Columns.Add("No", 35, HorizontalAlignment.Center);
            lvLampiran.Columns.Add("Id Lampiran", 80, HorizontalAlignment.Center);
            lvLampiran.Columns.Add("Link Lampiran", 450, HorizontalAlignment.Center);
        }

        public void LoadData()
        {
            lvLampiran.Items.Clear();
            listLam = controllerLam.ReadAllLampiran();

            foreach (var lam in listLam)
            {
                var noUrut = lvLampiran.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(lam.idLampiran);
                item.SubItems.Add(lam.linkLampiran);


                // tampilkan data mhs ke listview
                lvLampiran.Items.Add(item);

            }
        }

        private void OnCreateEventHandler(Lampiran lam)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listLam.Add(lam);
            int noUrut = lvLampiran.Items.Count + 1;
            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(lam.idLampiran);
            item.SubItems.Add(lam.linkLampiran);

            // tampilkan data mhs ke listview
            lvLampiran.Items.Add(item);

        }
        private void OnUpdateEventHandler(Lampiran lam)
        {
            // ambil index data mhs yang edit
            int index = lvLampiran.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lvLampiran.Items[index];
            itemRow.SubItems[1].Text = lam.idLampiran;
            itemRow.SubItems[2].Text = lam.linkLampiran;



        }

        private void button11_Click(object sender, EventArgs e)
        {
            EntryLampiran entryLampiran = new EntryLampiran("Kirim Lampiran", controllerLam);
            entryLampiran.OnCreate += OnCreateEventHandler;
            entryLampiran.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lvLampiran.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Lampiran lam = listLam[lvLampiran.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                EntryLampiran entryLampiran = new EntryLampiran("Edit Data Lampiran", lam, controllerLam);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                entryLampiran.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                entryLampiran.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (lvLampiran.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data lampiran ingin dihapus ? ", "Konfirmasi",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Lampiran lam = listLam[lvLampiran.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = controllerLam.DeleteLampiran(lam);
                    if (result > 0) LoadData();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data lampiran belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}