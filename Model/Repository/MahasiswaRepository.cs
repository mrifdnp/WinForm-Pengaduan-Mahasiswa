using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using UAS.Model.Entity;
using UAS.Model.Context;
using System.Runtime.Remoting.Contexts;
namespace UAS.Model.Repository
{
    public class MahasiswaRepository
    {
        private SQLiteConnection _conn;
        public MahasiswaRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int CreateMahasiswa(Mahasiswa mhs)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into mahasiswa (nim, nama, no_telp,prodi)
 values (@nim, @nama, @no_telp,@prodi)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nim", mhs.nim);
                cmd.Parameters.AddWithValue("@nama", mhs.nama);
                cmd.Parameters.AddWithValue("@no_telp", mhs.no_telp);
                cmd.Parameters.AddWithValue("@prodi", mhs.prodi);
                try
                {

                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int UpdateMahasiswa(Mahasiswa mhs)
        {
            int result = 0;
            string sql = @"update mahasiswa set nama = @nama, no_telp = @no_telp, prodi = @prodi where nim = @nim";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nim", mhs.nim);
                cmd.Parameters.AddWithValue("@nama", mhs.nama);
                cmd.Parameters.AddWithValue("@no_telp", mhs.no_telp);
                cmd.Parameters.AddWithValue("@prodi", mhs.prodi);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }
     

        public int TotalMhs()
        {
            int result = 0;
            string sql = @"select count(*) from mahasiswa";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int DeleteMahasiswa(Mahasiswa mhs)
        {
            int result = 0;
            string sql = @"delete from mahasiswa where nim = @nim";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nim", mhs.nim);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }
            return result;
        }
        public List<Mahasiswa> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Mahasiswa> list = new List<Mahasiswa>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select nim, nama, no_telp,prodi 
                               from mahasiswa 
                               order by nama";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.nim = dtr["nim"].ToString();
                            mhs.nama = dtr["nama"].ToString();
                            mhs.no_telp = dtr["no_telp"].ToString();
                            mhs.prodi = dtr["prodi"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }
        public List<Mahasiswa> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Mahasiswa> list = new List<Mahasiswa>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select nim, nama, no_telp, prodi 
                               from mahasiswa where nama like @nama
                               order by nama";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama", "%" + nama + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.nim = dtr["nim"].ToString();
                            mhs.nama = dtr["nama"].ToString();
                            mhs.no_telp = dtr["no_telp"].ToString();
                            mhs.prodi = dtr["prodi"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }
        
    }
}