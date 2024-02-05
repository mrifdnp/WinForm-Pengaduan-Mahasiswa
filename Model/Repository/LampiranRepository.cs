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
    public class LampiranRepository
    {
        private SQLiteConnection _conn;
        public LampiranRepository(DbContext context)
        {
            _conn = context.Conn;
        }
        public int CreateLampiran(Lampiran lam)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into lampiran (idLampiran, linkLampiran)
 values (@idLampiran,@linkLampiran)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idLampiran", lam.idLampiran);
                cmd.Parameters.AddWithValue("@linkLampiran", lam.linkLampiran);
             
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
        public int UpdateLampiran(Lampiran lam)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"update lampiran set linkLampiran=@linkLampiran where idLampiran=@idLampiran";
 
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idLampiran", lam.idLampiran);
                cmd.Parameters.AddWithValue("@linkLampiran", lam.linkLampiran);

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

        public int DeleteLampiran(Lampiran lam)
        {
            int result = 0;
            string sql = @"delete from lampiran where idLampiran = @idLampiran";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@idLampiran",lam.idLampiran);

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
        public List<Lampiran> ReadAllLampiran()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Lampiran> list = new List<Lampiran>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select idLampiran, linkLampiran
                               from lampiran 
                               order by idLampiran";

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
                            Lampiran lam = new Lampiran();
                            lam.idLampiran = dtr["idLampiran"].ToString();
                            lam.linkLampiran = dtr["linkLampiran"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(lam);
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
    }
}
