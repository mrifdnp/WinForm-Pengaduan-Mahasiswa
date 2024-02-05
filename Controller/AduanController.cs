using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAS.Model.Context;
using UAS.Model.Entity;
using UAS.Model.Repository;

namespace UAS.Controller
{
    public class AduanController
    {
        private AduanRepository _repository;
        public List<Pengaduan> ReadAllAduan()
        {
            // membuat objek collection
            List<Pengaduan> list = new List<Pengaduan>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AduanRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAllAduan();
            }

            return list;
        }
        public List<Pengaduan> ReadById(string idPengaduan)
        {
            // membuat objek collection
            List<Pengaduan> list = new List<Pengaduan>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AduanRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadById(idPengaduan);
            }

            return list;
        }

        public int CreateAduan(Pengaduan adu)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.idPengaduan))
            {
                MessageBox.Show("Id Pengaduan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.tglAdu))
            {
                MessageBox.Show("Tanggal Aduan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.tglSelesai))
            {
                MessageBox.Show("Tanggal Selesai harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            DateTime tglAduan, tglSelesai;
            if (!DateTime.TryParse(adu.tglAdu, out tglAduan) ||
                !DateTime.TryParse(adu.tglSelesai, out tglSelesai) ||
                tglSelesai < tglAduan)
            {
                MessageBox.Show("Tanggal Selesai harus diisi dan lebih besar atau sama dengan tanggal Aduan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }


            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.deskAdu))
            {
                MessageBox.Show("Deskripsi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
           
            if (string.IsNullOrEmpty(adu.nim))
            {
                MessageBox.Show("NIM harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.idAdmin))
            {
                MessageBox.Show("idAdmin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.idLampiran))
            {
                MessageBox.Show("idLampiran harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AduanRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.CreateAduan(adu);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Aduan berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Aduan gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int UpdateAduan(Pengaduan adu)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.idPengaduan))
            {
                MessageBox.Show("Id Pengaduan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            DateTime tglAduan, tglSelesai;
            if (!DateTime.TryParse(adu.tglAdu, out tglAduan) ||
                !DateTime.TryParse(adu.tglSelesai, out tglSelesai) ||
                tglSelesai < tglAduan)
            {
                MessageBox.Show("Tanggal Selesai harus diisi dan lebih besar atau sama dengan tanggal Aduan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.tglAdu))
            {
                MessageBox.Show("Tanggal Aduan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.tglSelesai))
            {
                MessageBox.Show("Tanggal Selesai harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.deskAdu))
            {
                MessageBox.Show("Deskripsi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.nim))
            {
                MessageBox.Show("NIM harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.idAdmin))
            {
                MessageBox.Show("idAdmin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adu.idLampiran))
            {
                MessageBox.Show("idLampiran harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AduanRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.UpdateAduan(adu);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Aduan berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Aduan gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int DeleteAduan(Pengaduan adu)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adu.idPengaduan))
            {
                MessageBox.Show("ID harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AduanRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.DeleteAduan(adu);
            }

            if (result > 0)
            {
                MessageBox.Show("Data aduan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data aduan gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int TotalAdu()
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AduanRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.TotalAdu();
            }

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;

        }
    }
}
