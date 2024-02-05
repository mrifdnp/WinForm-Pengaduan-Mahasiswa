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
    public class LampiranController
    {
        private LampiranRepository _repository;
        public List<Lampiran> ReadAllLampiran()
        {
            // membuat objek collection
            List<Lampiran> list = new List<Lampiran>();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new LampiranRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAllLampiran();
            }

            return list;
        }

        public int CreateLampiran(Lampiran lam)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(lam.idLampiran))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(lam.linkLampiran))
            {
                MessageBox.Show("Link harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new LampiranRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.CreateLampiran(lam);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Lampiran berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Lampiran gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int UpdateLampiran(Lampiran lam)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(lam.idLampiran))
            {
                MessageBox.Show("Id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(lam.linkLampiran))
            {
                MessageBox.Show("Link harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }



            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new LampiranRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.UpdateLampiran(lam);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Lampiran berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Lampiran gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
        public int DeleteLampiran(Lampiran lam)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(lam.idLampiran))
            {
                MessageBox.Show("id harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new LampiranRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.DeleteLampiran(lam);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Lampiran berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Lampiran gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }

}
