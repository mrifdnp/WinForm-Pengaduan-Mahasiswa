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
    public class AdminController
    {
        private AdminRepository _repository;

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Admin> ReadByNamaAdmin(string namaAdmin)
        {
            // membuat objek collection
            List<Admin> list = new List<Admin>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AdminRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNamaAdmin(namaAdmin);
            }

            return list;
        }

        /// <summary>
        /// Method untuk menampilkan semua data mahasiswa
        /// </summary>
        /// <returns></returns>
        public List<Admin> ReadAllAdmin()
        {
            // membuat objek collection
            List<Admin> list = new List<Admin>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AdminRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAllAdmin();
            }

            return list;
        }

        public int CreateAdmin(Admin adm)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adm.idAdmin))
            {
                MessageBox.Show("NIM harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adm.namaAdmin))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adm.username))
            {
                MessageBox.Show("Nomor telepon harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adm.password))
            {
                MessageBox.Show("Nomor telepon harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.CreateAdmin(adm);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Admin berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Admin gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int UpdateAdmin(Admin adm)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adm.idAdmin))
            {
                MessageBox.Show("NIM harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adm.namaAdmin))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(adm.username))
            {
                MessageBox.Show("Nomor telepon harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(adm.password))
            {
                MessageBox.Show("Nomor telepon harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AdminRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.UpdateAdmin(adm);

                if (result > 0)
                {
                    MessageBox.Show("Data Admin berhasil diupdate !", "Informasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Data Admin gagal diupdate !!!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return result;
            }
        }
        public int DeleteAdmin(Admin adm)
        {
                int result = 0;

                // cek nilai npm yang diinputkan tidak boleh kosong
                if (string.IsNullOrEmpty(adm.idAdmin))
                {
                    MessageBox.Show("NIM harus diisi !!!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }

                // membuat objek context menggunakan blok using
                using (DbContext context = new DbContext())
                {
                    // membuat objek dari class repository
                    _repository = new AdminRepository(context);

                    // panggil method Delete class repository untuk menghapus data
                    result = _repository.DeleteAdmin(adm);
                }

                if (result > 0)
                {
                    MessageBox.Show("Data Admin berhasil dihapus !", "Informasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Data Admin gagal dihapus !!!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return result;
        }
        public bool IsValidUser(string username, string password)
        {
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("User name harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            bool isValidUser = false;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new AdminRepository(context);

                // panggil method Create class repository untuk menambahkan data
                isValidUser = _repository.IsValidUser(username, password);
            }

            if (!isValidUser)
            {
                MessageBox.Show("User name atau password salah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }
        public int TotalAdm()
        {
            int result = 0;
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new AdminRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.TotalAdm();
            }

            if (result > 0)
            {
                MessageBox.Show("Data Admin berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Admin gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;

        }
    }
}

