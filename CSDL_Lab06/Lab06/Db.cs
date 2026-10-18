using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lab06
{
    /// <summary>
    /// Lop ho tro ket noi CSDL SQL Server dung chung cho tat ca cac form.
    /// Moi ham deu dung SqlConnection + SqlCommand (ExecuteNonQuery / ExecuteScalar / ExecuteReader)
    /// va dung THAM SO (SqlParameter) thay cho noi chuoi de tranh loi SQL Injection.
    /// </summary>
    public static class Db
    {
        // ====== SINH VIEN SUA CHO PHU HOP MAY CUA MINH ======
        // Ten server: "." hoac "(local)" hoac ".\\SQLEXPRESS" hoac "TENMAY\\SQLEXPRESS"
        public const string Server = ".\\SQLEXPRESS";

        // Cach 1: Windows Authentication (Integrated Security = True)
        // Cach 2: SQL Server Authentication -> dat UseSqlAuth = true va nhap User/Password
        public const bool UseSqlAuth = false;
        public const string User = "sa";
        public const string Password = "123456";

        /// <summary>Tao doi tuong SqlConnection toi CSDL (mac dinh QLSinhVien).</summary>
        public static SqlConnection Conn(string database = "QLSinhVien")
        {
            string cs = UseSqlAuth
                ? "Data Source=" + Server + ";Initial Catalog=" + database + ";User ID=" + User + ";Password=" + Password
                : "Data Source=" + Server + ";Initial Catalog=" + database + ";Integrated Security=True";
            return new SqlConnection(cs);
        }

        /// <summary>Tao tham so; gia tri null duoc doi thanh DBNull.</summary>
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        // Mo ket noi neu dang dong; tra ve true neu ham nay la noi mo (de ham nay dong lai sau khi dung)
        private static bool OpenIfClosed(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed) { conn.Open(); return true; }
            return false;
        }

        private static void CloseIf(SqlConnection conn, bool opened)
        {
            if (opened && conn.State == ConnectionState.Open) conn.Close();
        }

        /// <summary>ExecuteNonQuery: Insert / Update / Delete. Tra ve so dong bi anh huong.</summary>
        public static int NonQuery(SqlConnection conn, string sql, params SqlParameter[] ps)
        {
            bool opened = OpenIfClosed(conn);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(ps);
                    return cmd.ExecuteNonQuery();
                }
            }
            finally { CloseIf(conn, opened); }
        }

        /// <summary>ExecuteScalar: lay 1 gia tri (cot dau tien, dong dau tien).</summary>
        public static object Scalar(SqlConnection conn, string sql, params SqlParameter[] ps)
        {
            bool opened = OpenIfClosed(conn);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(ps);
                    return cmd.ExecuteScalar();
                }
            }
            finally { CloseIf(conn, opened); }
        }

        /// <summary>
        /// Kiem tra ton tai dong du lieu bang SqlDataReader.HasRows
        /// (dung de kiem tra khoa chinh / khoa ngoai).
        /// </summary>
        public static bool Exists(SqlConnection conn, string sql, params SqlParameter[] ps)
        {
            bool opened = OpenIfClosed(conn);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(ps);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        return rd.HasRows;
                    }
                }
            }
            finally { CloseIf(conn, opened); }
        }

        /// <summary>Doc cot dau tien cua ket qua truy van thanh danh sach chuoi (dung do du lieu len ComboBox).</summary>
        public static List<string> Column(SqlConnection conn, string sql, params SqlParameter[] ps)
        {
            List<string> list = new List<string>();
            bool opened = OpenIfClosed(conn);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(ps);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read()) list.Add(rd[0].ToString());
                    }
                }
            }
            finally { CloseIf(conn, opened); }
            return list;
        }

        // ---------- Giao dich (transaction) ----------

        /// <summary>Chay nhieu lenh trong 1 transaction: loi thi Rollback, thanh cong thi Commit.</summary>
        public static void InTransaction(SqlConnection conn, Action<SqlTransaction> work)
        {
            bool opened = OpenIfClosed(conn);
            try
            {
                using (SqlTransaction tr = conn.BeginTransaction())
                {
                    try { work(tr); tr.Commit(); }
                    catch { tr.Rollback(); throw; }
                }
            }
            finally { CloseIf(conn, opened); }
        }

        public static int NonQueryTr(SqlConnection conn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tr))
            {
                cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ScalarTr(SqlConnection conn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn, tr))
            {
                cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }
    }
}
