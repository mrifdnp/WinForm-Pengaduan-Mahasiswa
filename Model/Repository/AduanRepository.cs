using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Model.Context;
using UAS.Model.Entity;

namespace UAS.Model.Repository
{
    public class AduanRepository
    {
        private SQLiteConnection _conn;
        public AduanRepository(DbContext context)
        {
            _conn = context.Conn;
        }
       
      
        public List<Pengaduan> ReadAllAduan()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Pengaduan> list = new List<Pengaduan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select idPengaduan, tglAdu, tglSelesai, deskAdu, nim, idAdmin, idLampiran
                               from pengaduan
                               order by idPengaduan";

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
                           Pengaduan adu = new Pengaduan();
                            adu.idPengaduan = dtr["idPengaduan"].ToString();
                            adu.tglAdu = dtr["tglAdu"].ToString();
                            adu.tglSelesai = dtr["tglSelesai"].ToString();
                            adu.deskAdu = dtr["deskAdu"].ToString();
                            adu.nim = dtr["nim"].ToString();
                            adu.idAdmin = dtr["idAdmin"].ToString();
                            adu.idLampiran = dtr["idLampiran"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(adu);
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
        public List<Pengaduan> ReadById(string idPengaduan)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Pengaduan> list = new List<Pengaduan>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select idPengaduan, tglAdu, tglSelesai, deskAdu, nim, idAdmin, idLampiran
                               from pengaduan where idPengaduan like @idPengaduan
                               order by idPengaduan";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@idPengaduan", "%" + idPengaduan + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Pengaduan adu = new Pengaduan();
                            adu.idPengaduan = dtr["idPengaduan"].ToString();
                            adu.tglAdu = dtr["tglAdu"].ToString();
                            adu.tglSelesai = dtr["tglSelesai"].ToString();
                            adu.deskAdu = dtr["deskAdu"].ToString();
                            adu.nim = dtr["nim"].ToString();
                            adu.idAdmin = dtr["idAdmin"].ToString();
                            adu.idLampiran = dtr["idLampiran"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(adu);
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

        public int CreateAduan(Pengaduan adu)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into pengaduan (idPengaduan, tglAdu, tglSelesai,deskAdu,nim,idAdmin,idLampiran)
 values (@idPengaduan, @tglAdu, @tglSelesai, @deskAdu, @nim, @idAdmin, @idLampiran)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idPengaduan", adu.idPengaduan);
                cmd.Parameters.AddWithValue("@tglAdu", adu.tglAdu);
                cmd.Parameters.AddWithValue("@tglSelesai", adu.tglSelesai);
                cmd.Parameters.AddWithValue("@deskAdu", adu.deskAdu);
                cmd.Parameters.AddWithValue("@nim", adu.nim);
                cmd.Parameters.AddWithValue("@idAdmin", adu.idAdmin);
                cmd.Parameters.AddWithValue("@idLampiran", adu.idLampiran);
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

        public int UpdateAduan(Pengaduan adu)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"update pengaduan set tglAdu = @tglAdu, tglSelesai = @tglSelesai, deskAdu = @deskAdu,nim = @nim, idAdmin = @idAdmin ,idLampiran = @idLampiran where idPengaduan = @idPengaduan";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idPengaduan", adu.idPengaduan);
                cmd.Parameters.AddWithValue("@tglAdu", adu.tglAdu);
                cmd.Parameters.AddWithValue("@tglSelesai", adu.tglSelesai);
                cmd.Parameters.AddWithValue("@deskAdu", adu.deskAdu);
                cmd.Parameters.AddWithValue("@nim", adu.nim);
                cmd.Parameters.AddWithValue("@idAdmin", adu.idAdmin);
                cmd.Parameters.AddWithValue("@idLampiran", adu.idLampiran);
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
        public int DeleteAduan(Pengaduan adu)
        {
            {
                int result = 0;
                string sql = @"delete from pengaduan where idPengaduan = @idPengaduan";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@idPengaduan", adu.idPengaduan);

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
        }
        public int TotalAdu()
        {
            int result = 0;
            string sql = @"select count(*) from pengaduan";

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
    }
}
