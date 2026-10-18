// =====================================================================
// THUC HANH 06a - TUONG TAC CSDL (SqlConnection, SqlCommand)
//   Bai mau      : FrmKhoa6a      (Quan ly Khoa)
//   Tai lop  - 1 : FrmMonHoc6a    (Quan ly Mon hoc)
//   Nang cao - 1 : FrmSinhVien6a  (Quan ly Sinh vien)
//   Nang cao - 2 : FrmDiem6a      (Quan ly Diem)
//   Ve nha   - 1 : FrmLop6a       (Quan ly Lop)
// Moi form co 3 chuc nang Them / Xoa / Sua dung SqlCommand.ExecuteNonQuery().
// =====================================================================
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06
{
    // ------------------------------------------------------------------
    // BAI MAU: Quan ly Khoa  (viet day du theo huong dan: mo/dong ket noi thu cong)
    // ------------------------------------------------------------------
    public class FrmKhoa6a : Form
    {
        SqlConnection connsql = Db.Conn();          // doi tuong ket noi
        TextBox txtMaKhoa, txtTenKhoa;

        public FrmKhoa6a()
        {
            UI.Config(this, "Quản lý Khoa", 330, 130);
            UI.Lbl(this, "Mã khoa", 15, 15);  txtMaKhoa = UI.Txt(this, 90, 15, 210);
            UI.Lbl(this, "Tên khoa", 15, 45); txtTenKhoa = UI.Txt(this, 90, 45, 210);
            UI.Btn(this, "Thêm", 40, 85, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 85, btnXoa_Click);
            UI.Btn(this, "Sửa", 210, 85, btnSua_Click);
        }

        // Ham dung chung: mo ket noi -> tao SqlCommand -> ExecuteNonQuery -> dong ket noi
        private void ThucThi(string sql, string thongBaoKhongTimThay)
        {
            try
            {
                // Kiem tra ket noi truoc khi mo
                if (connsql.State == System.Data.ConnectionState.Closed) connsql.Open();

                // Khai bao command moi
                SqlCommand cmd = new SqlCommand(sql, connsql);
                cmd.Parameters.AddWithValue("@ma", txtMaKhoa.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTenKhoa.Text.Trim());

                // Goi ExecuteNonQuery de gui command
                int kq = cmd.ExecuteNonQuery();

                if (kq > 0) UI.Info("Thành công");
                else UI.Warn(thongBaoKhongTimThay);
            }
            catch (Exception ex)
            {
                UI.Error("Thất bại: " + ex.Message);
            }
            finally
            {
                // Kiem tra ket noi truoc khi dong
                if (connsql.State == System.Data.ConnectionState.Open) connsql.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa") || !UI.Require(txtTenKhoa, "Tên khoa")) return;
            ThucThi("INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES(@ma, @ten)", "");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa")) return;
            ThucThi("DELETE FROM Khoa WHERE MaKhoa = @ma", "Không tìm thấy mã khoa cần xóa");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa") || !UI.Require(txtTenKhoa, "Tên khoa")) return;
            ThucThi("UPDATE Khoa SET TenKhoa = @ten WHERE MaKhoa = @ma", "Không tìm thấy mã khoa cần sửa");
        }
    }

    // ------------------------------------------------------------------
    // TAI LOP - BAI 1: Quan ly Mon hoc
    // ------------------------------------------------------------------
    public class FrmMonHoc6a : Form
    {
        SqlConnection connsql = Db.Conn();
        TextBox txtMaMH, txtTenMH;

        public FrmMonHoc6a()
        {
            UI.Config(this, "Quản lý môn học", 330, 130);
            UI.Lbl(this, "Mã mh", 15, 15);  txtMaMH = UI.Txt(this, 90, 15, 210);
            UI.Lbl(this, "Tên mh", 15, 45); txtTenMH = UI.Txt(this, 90, 45, 210);
            UI.Btn(this, "Thêm", 40, 85, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 85, btnXoa_Click);
            UI.Btn(this, "Sửa", 210, 85, btnSua_Click);
        }

        // THEM: Ma mon hoc, Ten mon hoc khong duoc de trong
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaMH, "Mã môn học") || !UI.Require(txtTenMH, "Tên môn học")) return;
            try
            {
                Db.NonQuery(connsql, "INSERT INTO MonHoc(MaMonHoc, TenMonHoc) VALUES(@ma, @ten)",
                    Db.P("@ma", txtMaMH.Text.Trim()), Db.P("@ten", txtTenMH.Text.Trim()));
                UI.Info("Thêm thành công");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // XOA: chi can Ma mon hoc (Ten mon hoc khong can nhap)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaMH, "Mã môn học")) return;
            try
            {
                int kq = Db.NonQuery(connsql, "DELETE FROM MonHoc WHERE MaMonHoc = @ma", Db.P("@ma", txtMaMH.Text.Trim()));
                if (kq > 0) UI.Info("Xóa thành công");
                else UI.Warn("Không tìm thấy mã môn học cần xóa");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // SUA: Ma mon hoc, Ten mon hoc khong duoc de trong
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaMH, "Mã môn học") || !UI.Require(txtTenMH, "Tên môn học")) return;
            try
            {
                int kq = Db.NonQuery(connsql, "UPDATE MonHoc SET TenMonHoc = @ten WHERE MaMonHoc = @ma",
                    Db.P("@ten", txtTenMH.Text.Trim()), Db.P("@ma", txtMaMH.Text.Trim()));
                if (kq > 0) UI.Info("Sửa thành công");
                else UI.Warn("Không tìm thấy mã môn học cần sửa");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // NANG CAO - BAI 1: Quan ly Sinh vien
    // ------------------------------------------------------------------
    public class FrmSinhVien6a : Form
    {
        SqlConnection connsql = Db.Conn();
        TextBox txtMaLop, txtMaSV, txtHoTen;
        MaskedTextBox mskNgaySinh;

        public FrmSinhVien6a()
        {
            UI.Config(this, "Quản lý sinh viên", 340, 190);
            UI.Lbl(this, "Mã lớp", 15, 15);     txtMaLop = UI.Txt(this, 90, 15, 220);
            UI.Lbl(this, "Mã sv", 15, 45);      txtMaSV = UI.Txt(this, 90, 45, 220);
            UI.Lbl(this, "Họ tên", 15, 75);     txtHoTen = UI.Txt(this, 90, 75, 220);
            UI.Lbl(this, "Ngày sinh", 15, 105); mskNgaySinh = UI.DateBox(this, 90, 105);
            UI.Btn(this, "Thêm", 40, 145, btnThem_Click);
            UI.Btn(this, "Xóa", 130, 145, btnXoa_Click);
            UI.Btn(this, "Sửa", 220, 145, btnSua_Click);
        }

        // THEM: Ma lop, Ma SV, Ten SV, Ngay sinh khong duoc de trong
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaLop, "Mã lớp") || !UI.Require(txtMaSV, "Mã sinh viên")
                || !UI.Require(txtHoTen, "Tên sinh viên") || !UI.Require(mskNgaySinh, "Ngày sinh")) return;
            DateTime ns;
            if (!UI.TryDate(mskNgaySinh, out ns)) { UI.Warn("Ngày sinh không hợp lệ (dd/MM/yyyy)"); mskNgaySinh.Focus(); return; }
            try
            {
                Db.NonQuery(connsql,
                    "INSERT INTO SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) VALUES(@ma, @ten, @ns, @lop)",
                    Db.P("@ma", txtMaSV.Text.Trim()), Db.P("@ten", txtHoTen.Text.Trim()),
                    Db.P("@ns", ns), Db.P("@lop", txtMaLop.Text.Trim()));
                UI.Info("Thêm thành công");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // XOA: Ma SV + Ten SV phai khop; Ma lop, Ngay sinh khong can nhap
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên") || !UI.Require(txtHoTen, "Tên sinh viên")) return;
            try
            {
                int kq = Db.NonQuery(connsql, "DELETE FROM SinhVien WHERE MaSinhVien = @ma AND HoTen = @ten",
                    Db.P("@ma", txtMaSV.Text.Trim()), Db.P("@ten", txtHoTen.Text.Trim()));
                if (kq > 0) UI.Info("Xóa thành công");
                else UI.Warn("Không tìm thấy sinh viên có mã và tên trùng khớp");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // SUA: Ma SV bat buoc; Ma lop / Ten / Ngay sinh phai co it nhat 1 truong co du lieu.
        // Truong nao khong nhap thi khong thay doi -> xay dung cau UPDATE dong.
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên")) return;

            string lop = txtMaLop.Text.Trim(), ten = txtHoTen.Text.Trim();
            bool coNgay = mskNgaySinh.Text != string.Empty;
            if (lop == string.Empty && ten == string.Empty && !coNgay)
            {
                UI.Warn("Phải nhập ít nhất một trong các trường: Mã lớp, Tên sinh viên, Ngày sinh");
                txtMaLop.Focus();
                return;
            }

            List<string> sets = new List<string>();
            List<SqlParameter> ps = new List<SqlParameter> { Db.P("@ma", txtMaSV.Text.Trim()) };
            if (lop != string.Empty) { sets.Add("MaLop = @lop"); ps.Add(Db.P("@lop", lop)); }
            if (ten != string.Empty) { sets.Add("HoTen = @ten"); ps.Add(Db.P("@ten", ten)); }
            if (coNgay)
            {
                DateTime ns;
                if (!UI.TryDate(mskNgaySinh, out ns)) { UI.Warn("Ngày sinh không hợp lệ (dd/MM/yyyy)"); mskNgaySinh.Focus(); return; }
                sets.Add("NgaySinh = @ns"); ps.Add(Db.P("@ns", ns));
            }

            try
            {
                string sql = "UPDATE SinhVien SET " + string.Join(", ", sets) + " WHERE MaSinhVien = @ma";
                int kq = Db.NonQuery(connsql, sql, ps.ToArray());
                if (kq > 0) UI.Info("Sửa thành công");
                else UI.Warn("Không tìm thấy mã sinh viên cần sửa");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // NANG CAO - BAI 2: Quan ly Diem
    // ------------------------------------------------------------------
    public class FrmDiem6a : Form
    {
        SqlConnection connsql = Db.Conn();
        TextBox txtMaSV, txtMaMH, txtDiem;

        public FrmDiem6a()
        {
            UI.Config(this, "Quản lý Điểm", 320, 170);
            UI.Lbl(this, "Mã sv", 15, 15); txtMaSV = UI.Txt(this, 70, 15, 220);
            UI.Lbl(this, "Mã mh", 15, 45); txtMaMH = UI.Txt(this, 70, 45, 220);
            UI.Lbl(this, "Điểm", 15, 75);  txtDiem = UI.Txt(this, 70, 75, 220);
            UI.Btn(this, "Thêm", 25, 120, btnThem_Click);
            UI.Btn(this, "Xóa", 115, 120, btnXoa_Click);
            UI.Btn(this, "Sửa", 205, 120, btnSua_Click);
        }

        // THEM: Ma SV, Ma MH, Diem khong duoc de trong (Diem phai la so)
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên") || !UI.Require(txtMaMH, "Mã môn học") || !UI.Require(txtDiem, "Điểm")) return;
            double diem;
            if (!UI.TryDiem(txtDiem.Text, out diem)) { UI.Warn("Điểm chỉ được nhập số"); txtDiem.Focus(); return; }
            try
            {
                Db.NonQuery(connsql, "INSERT INTO Diem(MaSinhVien, MaMonHoc, Diem) VALUES(@sv, @mh, @d)",
                    Db.P("@sv", txtMaSV.Text.Trim()), Db.P("@mh", txtMaMH.Text.Trim()), Db.P("@d", diem));
                UI.Info("Thêm thành công");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // XOA: Ma SV, Ma MH khong duoc de trong; Diem khong can nhap
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên") || !UI.Require(txtMaMH, "Mã môn học")) return;
            try
            {
                int kq = Db.NonQuery(connsql, "DELETE FROM Diem WHERE MaSinhVien = @sv AND MaMonHoc = @mh",
                    Db.P("@sv", txtMaSV.Text.Trim()), Db.P("@mh", txtMaMH.Text.Trim()));
                if (kq > 0) UI.Info("Xóa thành công");
                else UI.Warn("Không tìm thấy điểm của sinh viên theo môn học này");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // SUA: Ma SV, Ma MH bat buoc; Diem bat buoc va chi duoc nhap so
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên") || !UI.Require(txtMaMH, "Mã môn học") || !UI.Require(txtDiem, "Điểm")) return;
            double diem;
            if (!UI.TryDiem(txtDiem.Text, out diem)) { UI.Warn("Điểm chỉ được nhập số"); txtDiem.Focus(); return; }
            try
            {
                int kq = Db.NonQuery(connsql, "UPDATE Diem SET Diem = @d WHERE MaSinhVien = @sv AND MaMonHoc = @mh",
                    Db.P("@d", diem), Db.P("@sv", txtMaSV.Text.Trim()), Db.P("@mh", txtMaMH.Text.Trim()));
                if (kq > 0) UI.Info("Sửa thành công");
                else UI.Warn("Không tìm thấy điểm của sinh viên theo môn học này");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // VE NHA - BAI 1: Quan ly Lop
    // ------------------------------------------------------------------
    public class FrmLop6a : Form
    {
        SqlConnection connsql = Db.Conn();
        TextBox txtMaKhoa, txtMaLop, txtTenLop;

        public FrmLop6a()
        {
            UI.Config(this, "Quản lý Lớp", 330, 170);
            UI.Lbl(this, "Mã khoa", 15, 15); txtMaKhoa = UI.Txt(this, 85, 15, 220);
            UI.Lbl(this, "Mã lớp", 15, 45);  txtMaLop = UI.Txt(this, 85, 45, 220);
            UI.Lbl(this, "Tên lớp", 15, 75); txtTenLop = UI.Txt(this, 85, 75, 220);
            UI.Btn(this, "Thêm", 30, 120, btnThem_Click);
            UI.Btn(this, "Xóa", 120, 120, btnXoa_Click);
            UI.Btn(this, "Sửa", 210, 120, btnSua_Click);
        }

        // THEM: Ma khoa, Ma lop, Ten lop khong duoc de trong
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa") || !UI.Require(txtMaLop, "Mã lớp") || !UI.Require(txtTenLop, "Tên lớp")) return;
            try
            {
                Db.NonQuery(connsql, "INSERT INTO Lop(MaLop, TenLop, MaKhoa) VALUES(@lop, @ten, @khoa)",
                    Db.P("@lop", txtMaLop.Text.Trim()), Db.P("@ten", txtTenLop.Text.Trim()), Db.P("@khoa", txtMaKhoa.Text.Trim()));
                UI.Info("Thêm thành công");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // XOA: chi can Ma lop
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaLop, "Mã lớp")) return;
            try
            {
                int kq = Db.NonQuery(connsql, "DELETE FROM Lop WHERE MaLop = @lop", Db.P("@lop", txtMaLop.Text.Trim()));
                if (kq > 0) UI.Info("Xóa thành công");
                else UI.Warn("Không tìm thấy mã lớp cần xóa");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // SUA: Ma lop bat buoc; Ma khoa / Ten lop phai co it nhat 1 truong co du lieu
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaLop, "Mã lớp")) return;
            string khoa = txtMaKhoa.Text.Trim(), ten = txtTenLop.Text.Trim();
            if (khoa == string.Empty && ten == string.Empty)
            {
                UI.Warn("Phải nhập ít nhất một trong các trường: Mã khoa, Tên lớp");
                txtMaKhoa.Focus();
                return;
            }

            List<string> sets = new List<string>();
            List<SqlParameter> ps = new List<SqlParameter> { Db.P("@lop", txtMaLop.Text.Trim()) };
            if (khoa != string.Empty) { sets.Add("MaKhoa = @khoa"); ps.Add(Db.P("@khoa", khoa)); }
            if (ten != string.Empty) { sets.Add("TenLop = @ten"); ps.Add(Db.P("@ten", ten)); }

            try
            {
                int kq = Db.NonQuery(connsql, "UPDATE Lop SET " + string.Join(", ", sets) + " WHERE MaLop = @lop", ps.ToArray());
                if (kq > 0) UI.Info("Sửa thành công");
                else UI.Warn("Không tìm thấy mã lớp cần sửa");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }
}
