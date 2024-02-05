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
    public partial class EntryLampiran : Form
    {
        public delegate void CreateUpdateEventHandler(Lampiran lam);
        List<Lampiran> lamList=new List<Lampiran>();
        List<Pengaduan> List = new List<Pengaduan>();

        public event CreateUpdateEventHandler OnCreate;

        public event CreateUpdateEventHandler OnUpdate;
        
        private LampiranController controllerLam;
        private AduanController controller;

        private bool isNewData = true;

        
        private Lampiran lam;
        
        public EntryLampiran()
        {
            controllerLam = new LampiranController();
            controller = new AduanController();
            InitializeComponent();
            cmbLam();
        }
        private void cmbLam()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            List = controller.ReadAllAduan();
            foreach (var lam in List)
            {
                comboBox1.Items.Add(lam.idLampiran);
            }
          
        }
        public EntryLampiran(string title, LampiranController controller)
       : this()
        {
            this.Text = title;
            this.controllerLam = controller;
        }
        public EntryLampiran(string title, Lampiran obj, LampiranController controller)
          : this()
        {
            this.Text = title;
            this.controllerLam = controller;

            isNewData = false;
            lam = obj;

            comboBox1.Text = lam.idLampiran;
            textBox2.Text = lam.linkLampiran;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isNewData) lam = new Lampiran();


             lam.idLampiran = comboBox1.Text ;
             lam.linkLampiran= textBox2.Text ;

            int result = 0;
            if (isNewData)
            {

                result = controllerLam.CreateLampiran(lam);
                if (result > 0)
                {
                    OnCreate(lam);
                    comboBox1.ResetText();
                    textBox2.Clear();

                    comboBox1.Focus();
                }
            }
            else
            {
                result = controllerLam.UpdateLampiran(lam);
                if (result > 0)
                {
                    OnUpdate(lam);
                    this.Close();
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
