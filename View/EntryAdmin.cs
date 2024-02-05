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
    public partial class EntryAdmin : Form
    {
        public delegate void CreateUpdateEventHandler(Admin adm);


        public event CreateUpdateEventHandler OnCreate;

        public event CreateUpdateEventHandler OnUpdate;

        private AdminController controllerAdm;

        private bool isNewData = true;

        private Admin adm;
        public EntryAdmin()
        {
            InitializeComponent();
        }
        public EntryAdmin(string title, AdminController controller)
          : this()
        {
            this.Text = title;
            this.controllerAdm = controller;
        }

        public EntryAdmin(string title, Admin obj, AdminController controller)
           : this()
        {
            this.Text = title;
            this.controllerAdm = controller;

            isNewData = false;
            adm = obj;

            txtnim.Text = adm.idAdmin;
            txtNama.Text = adm.namaAdmin;
            txtTelp.Text = adm.username;


            txtProdi.Text = adm.password;

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (isNewData) adm= new Admin();


            adm.idAdmin = txtnim.Text;
            adm.namaAdmin = txtNama.Text;
            adm.username = txtTelp.Text;
            adm.password = txtProdi.Text;

            int result = 0;
            if (isNewData)
            {

                result = controllerAdm.CreateAdmin(adm);
                if (result > 0)
                {
                    OnCreate(adm);
                    txtnim.Clear();
                    txtNama.Clear();
                    txtTelp.Clear();

                    txtProdi.Clear();
                    txtnim.Focus();
                }
            }
            else
            {
                result = controllerAdm.UpdateAdmin(adm);
                if (result > 0)
                {
                    OnUpdate(adm);
                    this.Close();
                }

            }
        }
    }
}
