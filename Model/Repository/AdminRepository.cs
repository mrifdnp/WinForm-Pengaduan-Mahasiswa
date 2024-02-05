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
    public class AdminRepository
    {
        private SQLiteConnection _conn;
        public AdminRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int CreateAdmin(Admin adm)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into admin (idAdmin, namaAdmin, username,password)
 values (@idAdmin, @namaAdmin, @username,@password)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idAdmin", adm.idAdmin);
                cmd.Parameters.AddWithValue("@namaAdmin", adm.namaAdmin);
                cmd.Parameters.AddWithValue("@username", adm.username);
                cmd.Parameters.AddWithValue("@password", adm.password);
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
        public int UpdateAdmin(Admin adm)
        {
            int result = 0;
            string sql = @"update admin set namaAdmin = @namaAdmin, username = @username, password = @password where idAdmin = @idAdmin";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@idAdmin", adm.idAdmin);
                cmd.Parameters.AddWithValue("@namaAdmin", adm.namaAdmin);
                cmd.Parameters.AddWithValue("@username", adm.username);
                cmd.Parameters.AddWithValue("@password", adm.password);

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

        public int DeleteAdmin(Admin adm)
        {
            int result = 0;
            string sql = @"delete from admin where idAdmin = @idAdmin";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@idAdmin", adm.idAdmin);

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
        public List<Admin> ReadAllAdmin()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Admin> list = new List<Admin>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select idAdmin, namaAdmin, username,password
                               from admin
                               order by namaAdmin";

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
                           Admin adm = new Admin();
                             adm.idAdmin= dtr["idAdmin"].ToString();
                            adm.namaAdmin = dtr["namaAdmin"].ToString();
                            adm.username= dtr["username"].ToString();
                            adm.password = dtr["password"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(adm);
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
        public List<Admin> ReadByNamaAdmin(string namaAdmin)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Admin> list = new List<Admin>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select idAdmin, namaAdmin, username, password
                               from admin where namaAdmin like @namaAdmin
                               order by namaAdmin";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@namaAdmin", "%" + namaAdmin + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Admin adm = new Admin();
                            adm.idAdmin = dtr["idAdmin"].ToString();
                            adm.namaAdmin = dtr["namaAdmin"].ToString();
                            adm.username = dtr["username"].ToString();
                            adm.password = dtr["password"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(adm);
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
        public bool IsValidUser(string username, string password)
        {
            bool result = false;

            string sql = @"select count(*) as row_count
                           from Admin
                           where username = @username and password = @password";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari result set
                    if (dtr.Read())
                    {
                        result = Convert.ToInt32(dtr["row_count"]) > 0;
                    }
                }
            }

            return result;
        }
        public int TotalAdm()
        {
            int result = 0;
            string sql = @"select count(*) from admin";

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
