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
    public partial class EntryAduan : Form
    {
        private List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();
        private List<Admin> listAdmin = new List<Admin>();
        private MahasiswaController mahasiswaController;
        private AdminController AdminController;
        public delegate void CreateUpdateEventHandler(Pengaduan adu);



        public event CreateUpdateEventHandler OnCreate;

        public event CreateUpdateEventHandler OnUpdate;

        private AduanController controllerAdu;
        private bool isNewData = true;
        private Pengaduan adu;
        public EntryAduan()
        {
            mahasiswaController = new MahasiswaController();
            AdminController = new AdminController();
            InitializeComponent();
            cmbNim();
            
        }

        private void cmbNim()
        {
            comboNim.DropDownStyle = ComboBoxStyle.DropDownList;
            listMahasiswa = mahasiswaController.ReadAll();
            foreach(var mhs in listMahasiswa)
            {
                comboNim.Items.Add(mhs.nim);
            }
            comboAdmin.DropDownStyle = ComboBoxStyle.DropDownList;
            listAdmin = AdminController.ReadAllAdmin();
            foreach (var adu in listAdmin)
            {
                comboAdmin.Items.Add(adu.idAdmin);
            }
        }
        public EntryAduan(string title, AduanController controller)
         : this()
        {
            this.Text = title;
            this.controllerAdu = controller;
        }
        public EntryAduan(string title, Pengaduan obj, AduanController controller)
          : this()
        {
            this.Text = title;
            this.controllerAdu = controller;

            isNewData = false;
            adu = obj;
                
            txtIdAdu.Text = adu.idPengaduan;
            dateAduan.Text = adu.tglAdu;
            dateSelesai.Text = adu.tglSelesai;
            txtDesk.Text = adu.deskAdu;
            comboNim.Text = adu.nim;
            comboAdmin.Text = adu.idAdmin;
            txtLamp.Text = adu.idLampiran;
       

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) adu = new Pengaduan();

            adu.idPengaduan =txtIdAdu.Text;
            adu.tglAdu= dateAduan.Text;
            adu.tglSelesai = dateSelesai.Text;
            adu.deskAdu = txtDesk.Text;
            adu.nim = comboNim.Text;
            adu.idAdmin = comboAdmin.Text;
            adu.idLampiran = txtLamp.Text;

            int result = 0;
            if (isNewData)
            {

                result = controllerAdu.CreateAduan(adu);
                if (result > 0)
                {
                    OnCreate(adu);
                    comboNim.ResetText();
                    txtIdAdu.Clear();
              
                    comboAdmin.ResetText();
                    txtDesk.Clear() ;
                    txtLamp.Clear();

                    txtIdAdu.Focus();
                }
            }
            else
            {
                result = controllerAdu.UpdateAduan(adu);
                if (result > 0)
                {
                    OnUpdate(adu);
                    this.Close();
                }

            }
        }
    }
}
