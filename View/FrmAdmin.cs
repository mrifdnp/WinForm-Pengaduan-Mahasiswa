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
    public partial class FrmAdmin : Form
    {
        private List<Admin> listAdmin = new List<Admin>();

        private AdminController controllerAdm;
        public FrmAdmin()
        {
            InitializeComponent();
            controllerAdm = new AdminController();
            IlvAdmin();

            LoadDataAdmin();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadDataAdmin()
        {
            // kosongkan listview
            lvAdmin.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listAdmin = controllerAdm.ReadAllAdmin();
            // ekstrak objek mhs dari collection
            foreach (var adm in listAdmin)
            {
                var noUrut = lvAdmin.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(adm.idAdmin);
                item.SubItems.Add(adm.namaAdmin);
                item.SubItems.Add(adm.username);
                item.SubItems.Add(adm.password);

                // tampilkan data mhs ke listview
                lvAdmin.Items.Add(item);

            }
        }
        private void IlvAdmin()
        {
            lvAdmin.View = System.Windows.Forms.View.Details;
            lvAdmin.FullRowSelect = true;
            lvAdmin.GridLines = true;
            lvAdmin.Columns.Add("No", 35, HorizontalAlignment.Center);
            lvAdmin.Columns.Add("ID Admin", 100, HorizontalAlignment.Center);
            lvAdmin.Columns.Add("Nama", 300, HorizontalAlignment.Center);
            lvAdmin.Columns.Add("Username", 140, HorizontalAlignment.Center);
            lvAdmin.Columns.Add("Password", 150, HorizontalAlignment.Center);
        }
        private void OnCreateEventHandler(Admin adm)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listAdmin.Add(adm);
            int noUrut = lvAdmin.Items.Count + 1;
            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(adm.idAdmin);
            item.SubItems.Add(adm.namaAdmin);
            item.SubItems.Add(adm.username);
            item.SubItems.Add(adm.password);
            // tampilkan data mhs ke listview
            lvAdmin.Items.Add(item);

        }
        private void OnUpdateEventHandler(Admin adm)
        {
            // ambil index data mhs yang edit
            int index = lvAdmin.SelectedIndices[0];
            // update informasi mhs di listview
            ListViewItem itemRow = lvAdmin.Items[index];
            itemRow.SubItems[1].Text = adm.idAdmin;
            itemRow.SubItems[2].Text = adm.namaAdmin;
            itemRow.SubItems[3].Text = adm.username;
            itemRow.SubItems[4].Text = adm.password;


        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            EntryAdmin entryadm = new EntryAdmin("Tambah", controllerAdm);
            entryadm.OnCreate += OnCreateEventHandler;
            entryadm.ShowDialog();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lvAdmin.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Admin mhs = listAdmin[lvAdmin.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                EntryAdmin entryadm = new EntryAdmin("Edit Data Admin", mhs, controllerAdm);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                entryadm.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                entryadm.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (lvAdmin.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Admin adm = listAdmin[lvAdmin.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = controllerAdm.DeleteAdmin(adm);
                    if (result > 0) LoadDataAdmin();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lvAdmin.Items.Clear();
            button7.Show();

            listAdmin = controllerAdm.ReadByNamaAdmin(textBox1.Text);

            foreach (var adm in listAdmin)
            {
                var noUrut = lvAdmin.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(adm.idAdmin);
                item.SubItems.Add(adm.namaAdmin);
                item.SubItems.Add(adm.username);
                item.SubItems.Add(adm.password);

                // tampilkan data mhs ke listview
                lvAdmin.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadDataAdmin();
            button7.Hide();
            textBox1.Text = "";
        }
    }

}
