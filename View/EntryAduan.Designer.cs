namespace UAS.View
{
    partial class EntryAduan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdAdu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t = new System.Windows.Forms.Label();
            this.txtLamp = new System.Windows.Forms.TextBox();
            this.txtDesk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboNim = new System.Windows.Forms.ComboBox();
            this.dateAduan = new System.Windows.Forms.DateTimePicker();
            this.dateSelesai = new System.Windows.Forms.DateTimePicker();
            this.comboAdmin = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(550, 393);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(97, 27);
            this.btnSimpan.TabIndex = 25;
            this.btnSimpan.Text = "Kirim";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.Location = new System.Drawing.Point(678, 393);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(75, 27);
            this.btnSelesai.TabIndex = 24;
            this.btnSelesai.Text = "Selesai";
            this.btnSelesai.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "ID Lampiran";
            // 
            // txtIdAdu
            // 
            this.txtIdAdu.Location = new System.Drawing.Point(198, 47);
            this.txtIdAdu.Name = "txtIdAdu";
            this.txtIdAdu.Size = new System.Drawing.Size(200, 26);
            this.txtIdAdu.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "ID Admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "ID Pengaduan";
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Location = new System.Drawing.Point(39, 217);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(38, 20);
            this.t.TabIndex = 19;
            this.t.Text = "NIM";
            // 
            // txtLamp
            // 
            this.txtLamp.Location = new System.Drawing.Point(550, 263);
            this.txtLamp.Name = "txtLamp";
            this.txtLamp.Size = new System.Drawing.Size(203, 26);
            this.txtLamp.TabIndex = 17;
            // 
            // txtDesk
            // 
            this.txtDesk.Location = new System.Drawing.Point(429, 81);
            this.txtDesk.Multiline = true;
            this.txtDesk.Name = "txtDesk";
            this.txtDesk.Size = new System.Drawing.Size(324, 156);
            this.txtDesk.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Deskripsi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tanggal Aduan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Tanggal Selesai";
            // 
            // comboNim
            // 
            this.comboNim.FormattingEnabled = true;
            this.comboNim.Location = new System.Drawing.Point(198, 217);
            this.comboNim.Name = "comboNim";
            this.comboNim.Size = new System.Drawing.Size(200, 28);
            this.comboNim.TabIndex = 34;
            // 
            // dateAduan
            // 
            this.dateAduan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateAduan.Location = new System.Drawing.Point(198, 108);
            this.dateAduan.Name = "dateAduan";
            this.dateAduan.Size = new System.Drawing.Size(200, 26);
            this.dateAduan.TabIndex = 35;
            // 
            // dateSelesai
            // 
            this.dateSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateSelesai.Location = new System.Drawing.Point(198, 159);
            this.dateSelesai.Name = "dateSelesai";
            this.dateSelesai.Size = new System.Drawing.Size(200, 26);
            this.dateSelesai.TabIndex = 36;
            // 
            // comboAdmin
            // 
            this.comboAdmin.FormattingEnabled = true;
            this.comboAdmin.Location = new System.Drawing.Point(198, 272);
            this.comboAdmin.Name = "comboAdmin";
            this.comboAdmin.Size = new System.Drawing.Size(200, 28);
            this.comboAdmin.TabIndex = 37;
            // 
            // EntryAduan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboAdmin);
            this.Controls.Add(this.dateSelesai);
            this.Controls.Add(this.dateAduan);
            this.Controls.Add(this.comboNim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesk);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnSelesai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdAdu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t);
            this.Controls.Add(this.txtLamp);
            this.Name = "EntryAduan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntryAduan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnSelesai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdAdu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.TextBox txtLamp;
        private System.Windows.Forms.TextBox txtDesk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboNim;
        private System.Windows.Forms.DateTimePicker dateAduan;
        private System.Windows.Forms.DateTimePicker dateSelesai;
        private System.Windows.Forms.ComboBox comboAdmin;
    }
}