// =====================================================================
// THUC HANH 06b - SqlCommand, SqlDataReader, kiem tra khoa chinh / khoa ngoai
//   Bai mau   - 1 : FrmKhoa6b         (kiem tra trung Ma khoa bang ExecuteScalar)
//   Bai mau   - 2 : FrmLop6b          (ComboBox khoa ngoai + kiem tra khoa chinh bang SqlDataReader)
//   Tai lop   - 1 : FrmSinhVien6b
//   Tai lop   - 2 : FrmDiem6b
//   Nang cao  - 1 : FrmDanhSachLop    (ListView)
//   Nang cao  - 2 : FrmDanhSachDiem   (ListView + loc theo mon hoc + tong diem)
// =====================================================================
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06
{
    // ------------------------------------------------------------------
    // BAI MAU 1: Quan ly Khoa - kiem tra khoa chinh bang ExecuteScalar (count)
    // ------------------------------------------------------------------
    public class FrmKhoa6b : Form
    {
        SqlConnection connsql = Db.Conn();
        TextBox txtMaKhoa, txtTenKhoa;

        public FrmKhoa6b()
        {
            UI.Config(this, "Quản lý Khoa", 330, 130);
            UI.Lbl(this, "Mã khoa", 15, 15);  txtMaKhoa = UI.Txt(this, 90, 15, 210);
            UI.Lbl(this, "Tên khoa", 15, 45); txtTenKhoa = UI.Txt(this, 90, 45, 210);
            UI.Btn(this, "Thêm", 40, 85, btnThem_Click);
            UI.Btn(this, "Xóa", 125, 85, btnXoa_Click);
            UI.Btn(this, "Sửa", 210, 85, btnSua_Click);
        }

        // Kiem tra trung Ma khoa. Tra ve true neu CHUA ton tai (duoc phep them), false neu da co.
        bool KT_MaKhoa(string ma)
        {
            try
            {
                // select count(*) -> ExecuteScalar
                int count = (int)Db.Scalar(connsql, "SELECT COUNT(*) FROM Khoa WHERE MaKhoa = @ma", Db.P("@ma", ma));
                if (count >= 1) return false;
                return true;
            }
            catch (Exception) { return false; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa") || !UI.Require(txtTenKhoa, "Tên khoa")) return;
            try
            {
                if (KT_MaKhoa(txtMaKhoa.Text.Trim()) == true)
                {
                    Db.NonQuery(connsql, "INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES(@ma, @ten)",
                        Db.P("@ma", txtMaKhoa.Text.Trim()), Db.P("@ten", txtTenKhoa.Text.Trim()));
                    UI.Info("Thành công");
                }
                else UI.Warn("Trùng mã khoa");
            }
            catch (Exception ex) { UI.Error("Thất bại: " + ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa")) return;
            try
            {
                // Rang buoc khoa ngoai: khoa dang co lop thi khong duoc xoa
                if (Db.Exists(connsql, "SELECT 1 FROM Lop WHERE MaKhoa = @ma", Db.P("@ma", txtMaKhoa.Text.Trim())))
                { UI.Warn("Khoa này đang có lớp, không thể xóa"); return; }

                int kq = Db.NonQuery(connsql, "DELETE FROM Khoa WHERE MaKhoa = @ma", Db.P("@ma", txtMaKhoa.Text.Trim()));
                if (kq > 0) UI.Info("Xóa thành công");
                else UI.Warn("Không tìm thấy mã khoa cần xóa");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaKhoa, "Mã khoa") || !UI.Require(txtTenKhoa, "Tên khoa")) return;
            try
            {
                int kq = Db.NonQuery(connsql, "UPDATE Khoa SET TenKhoa = @ten WHERE MaKhoa = @ma",
                    Db.P("@ten", txtTenKhoa.Text.Trim()), Db.P("@ma", txtMaKhoa.Text.Trim()));
                if (kq > 0) UI.Info("Sửa thành công");
                else UI.Warn("Không tìm thấy mã khoa cần sửa");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // BAI MAU 2: Quan ly Lop - ComboBox Khoa (khoa ngoai) + SqlDataReader
    // ------------------------------------------------------------------
    public class FrmLop6b : Form
    {
        SqlConnection connsql = Db.Conn();
        ComboBox cboKhoa;
        TextBox txtMaLop, txtTenLop;

        public FrmLop6b()
        {
            UI.Config(this, "Quản lý Lớp", 330, 170);
            UI.Lbl(this, "Mã khoa", 15, 15); cboKhoa = UI.Cbo(this, 85, 15, 220);
            UI.Lbl(this, "Mã lớp", 15, 45);  txtMaLop = UI.Txt(this, 85, 45, 220);
            UI.Lbl(this, "Tên lớp", 15, 75); txtTenLop = UI.Txt(this, 85, 75, 220);
            UI.Btn(this, "Thêm", 30, 120, btnThem_Click);
            UI.Btn(this, "Xóa", 120, 120, btnXoa_Click);
            UI.Btn(this, "Sửa", 210, 120, btnSua_Click);
            Load += frmLop_Load;
        }

        private void frmLop_Load(object sender, EventArgs e) { LoadKhoa_ComboBox(); }

        // Cong viec 1: dung SqlDataReader hien thi khoa ngoai len ComboBox
        private void LoadKhoa_ComboBox()
        {
            try
            {
                connsql.Open();                                           // Mo ket noi
                SqlCommand cmd = new SqlCommand("SELECT * FROM Khoa", connsql);
                SqlDataReader rd = cmd.ExecuteReader();                   // Truy van dang hien thi du lieu
                cboKhoa.Items.Clear();
                while (rd.Read())
                {
                    cboKhoa.Items.Add(rd["MaKhoa"].ToString());
                }
                rd.Close();
            }
            catch (Exception ex) { UI.Error("Không tải được danh sách khoa: " + ex.Message); }
            finally { if (connsql.State == System.Data.ConnectionState.Open) connsql.Close(); }
        }

        // Cong viec 2: kiem tra khoa chinh bang SqlDataReader.
        // true  = ma lop CHUA ton tai (them duoc); false = da ton tai (trung khoa chinh)
        public bool KT_KhoaChinh(string pMa)
        {
            return !Db.Exists(connsql, "SELECT * FROM Lop WHERE MaLop = @ma", Db.P("@ma", pMa));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Rang buoc giao dien: khong cho rong
            if (!UI.Require(cboKhoa, "Mã khoa") || !UI.Require(txtMaLop, "Mã lớp") || !UI.Require(txtTenLop, "Tên lớp")) return;
            try
            {
                if (KT_KhoaChinh(txtMaLop.Text.Trim()) == true)
                {
                    Db.NonQuery(connsql, "INSERT INTO Lop(MaLop, TenLop, MaKhoa) VALUES(@lop, @ten, @khoa)",
                        Db.P("@lop", txtMaLop.Text.Trim()), Db.P("@ten", txtTenLop.Text.Trim()),
                        Db.P("@khoa", cboKhoa.SelectedItem.ToString()));
                    UI.Info("Thành công");
                }
                else UI.Warn("Trùng mã lớp");
            }
            catch (Exception ex) { UI.Error("Thất bại: " + ex.Message); }
        }

        // Cong viec 3: kiem tra khoa chinh / khoa ngoai truoc khi Xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaLop, "Mã lớp")) return;
            string ma = txtMaLop.Text.Trim();
            try
            {
                if (KT_KhoaChinh(ma)) { UI.Warn("Mã lớp không tồn tại"); return; }                  // khoa chinh phai co
                if (Db.Exists(connsql, "SELECT 1 FROM SinhVien WHERE MaLop = @ma", Db.P("@ma", ma)))  // khoa ngoai: con SV thuoc lop
                { UI.Warn("Lớp đang có sinh viên, không thể xóa"); return; }

                Db.NonQuery(connsql, "DELETE FROM Lop WHERE MaLop = @ma", Db.P("@ma", ma));
                UI.Info("Xóa thành công");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // Sua: kiem tra khoa chinh (ma lop phai ton tai); Ma khoa lay tu ComboBox nen luon la khoa ngoai hop le
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaLop, "Mã lớp") || !UI.Require(cboKhoa, "Mã khoa") || !UI.Require(txtTenLop, "Tên lớp")) return;
            string ma = txtMaLop.Text.Trim();
            try
            {
                if (KT_KhoaChinh(ma)) { UI.Warn("Mã lớp không tồn tại"); return; }
                Db.NonQuery(connsql, "UPDATE Lop SET TenLop = @ten, MaKhoa = @khoa WHERE MaLop = @ma",
                    Db.P("@ten", txtTenLop.Text.Trim()), Db.P("@khoa", cboKhoa.SelectedItem.ToString()), Db.P("@ma", ma));
                UI.Info("Sửa thành công");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // TAI LOP - BAI 1: Quan ly Sinh vien
    // ------------------------------------------------------------------
    public class FrmSinhVien6b : Form
    {
        SqlConnection connsql = Db.Conn();
        ComboBox cboLop;
        TextBox txtMaSV, txtHoTen;
        MaskedTextBox mskNgaySinh;

        public FrmSinhVien6b()
        {
            UI.Config(this, "Quản lý sinh viên", 340, 190);
            UI.Lbl(this, "Mã lớp", 15, 15);     cboLop = UI.Cbo(this, 90, 15, 220);
            UI.Lbl(this, "Mã sv", 15, 45);      txtMaSV = UI.Txt(this, 90, 45, 220);
            UI.Lbl(this, "Họ tên", 15, 75);     txtHoTen = UI.Txt(this, 90, 75, 220);
            UI.Lbl(this, "Ngày sinh", 15, 105); mskNgaySinh = UI.DateBox(this, 90, 105);
            UI.Btn(this, "Thêm", 40, 145, btnThem_Click);
            UI.Btn(this, "Xóa", 130, 145, btnXoa_Click);
            UI.Btn(this, "Sửa", 220, 145, btnSua_Click);
            Load += delegate { UI.Fill(cboLop, Db.Column(connsql, "SELECT MaLop FROM Lop")); };   // hien thi ma lop len ComboBox
        }

        // true = ma sinh vien CHUA ton tai
        bool KT_KhoaChinh(string ma)
        {
            return !Db.Exists(connsql, "SELECT * FROM SinhVien WHERE MaSinhVien = @ma", Db.P("@ma", ma));
        }

        // THEM
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Tat ca thong tin phai duoc nhap
            if (!UI.Require(cboLop, "Mã lớp") || !UI.Require(txtMaSV, "Mã sinh viên")
                || !UI.Require(txtHoTen, "Tên sinh viên") || !UI.Require(mskNgaySinh, "Ngày sinh")) return;

            DateTime ns;
            if (!UI.TryDate(mskNgaySinh, out ns)) { UI.Warn("Ngày sinh không hợp lệ (dd/MM/yyyy)"); mskNgaySinh.Focus(); return; }

            // Sinh vien phai tu 17 tuoi tro len (chi tinh theo nam sinh)
            if (DateTime.Now.Year - ns.Year < 17)
            {
                UI.Warn("Sinh viên phải từ 17 tuổi trở lên");
                mskNgaySinh.Focus();
                return;
            }

            try
            {
                // Kiem tra trung khoa chinh
                if (!KT_KhoaChinh(txtMaSV.Text.Trim())) { UI.Warn("Trùng mã sinh viên"); txtMaSV.Focus(); return; }

                Db.NonQuery(connsql, "INSERT INTO SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) VALUES(@ma, @ten, @ns, @lop)",
                    Db.P("@ma", txtMaSV.Text.Trim()), Db.P("@ten", txtHoTen.Text.Trim()),
                    Db.P("@ns", ns), Db.P("@lop", cboLop.SelectedItem.ToString()));
                UI.Info("Thêm thành công");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // XOA: kiem tra khoa chinh (SV phai ton tai) + khoa ngoai (SV chua co diem)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên")) return;
            string ma = txtMaSV.Text.Trim();
            try
            {
                if (KT_KhoaChinh(ma)) { UI.Warn("Mã sinh viên không tồn tại"); return; }
                if (Db.Exists(connsql, "SELECT 1 FROM Diem WHERE MaSinhVien = @ma", Db.P("@ma", ma)))
                { UI.Warn("Sinh viên đã có điểm, không thể xóa"); return; }

                Db.NonQuery(connsql, "DELETE FROM SinhVien WHERE MaSinhVien = @ma", Db.P("@ma", ma));
                UI.Info("Xóa thành công");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // SUA: kiem tra khoa chinh (SV phai ton tai) + khoa ngoai (Ma lop phai ton tai trong bang Lop)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtMaSV, "Mã sinh viên") || !UI.Require(cboLop, "Mã lớp")
                || !UI.Require(txtHoTen, "Tên sinh viên") || !UI.Require(mskNgaySinh, "Ngày sinh")) return;
            DateTime ns;
            if (!UI.TryDate(mskNgaySinh, out ns)) { UI.Warn("Ngày sinh không hợp lệ (dd/MM/yyyy)"); mskNgaySinh.Focus(); return; }

            string ma = txtMaSV.Text.Trim(), lop = cboLop.SelectedItem.ToString();
            try
            {
                if (KT_KhoaChinh(ma)) { UI.Warn("Mã sinh viên không tồn tại"); return; }
                if (!Db.Exists(connsql, "SELECT 1 FROM Lop WHERE MaLop = @lop", Db.P("@lop", lop)))
                { UI.Warn("Mã lớp không tồn tại"); return; }

                Db.NonQuery(connsql, "UPDATE SinhVien SET HoTen = @ten, NgaySinh = @ns, MaLop = @lop WHERE MaSinhVien = @ma",
                    Db.P("@ten", txtHoTen.Text.Trim()), Db.P("@ns", ns), Db.P("@lop", lop), Db.P("@ma", ma));
                UI.Info("Sửa thành công");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // TAI LOP - BAI 2: Cap nhat bang Diem
    // ------------------------------------------------------------------
    public class FrmDiem6b : Form
    {
        SqlConnection connsql = Db.Conn();
        ComboBox cboSV, cboMH;
        TextBox txtDiem;

        public FrmDiem6b()
        {
            UI.Config(this, "Quản lý Điểm", 320, 170);
            UI.Lbl(this, "Sinh viên", 15, 15); cboSV = UI.Cbo(this, 90, 15, 200);
            UI.Lbl(this, "Môn học", 15, 45);   cboMH = UI.Cbo(this, 90, 45, 200);
            UI.Lbl(this, "Điểm", 15, 75);      txtDiem = UI.Txt(this, 90, 75, 200);
            UI.Btn(this, "Thêm", 25, 120, btnThem_Click);
            UI.Btn(this, "Xóa", 115, 120, btnXoa_Click);
            UI.Btn(this, "Sửa", 205, 120, btnSua_Click);
            Load += delegate
            {
                UI.Fill(cboSV, Db.Column(connsql, "SELECT MaSinhVien FROM SinhVien"));   // ma SV len ComboBox
                UI.Fill(cboMH, Db.Column(connsql, "SELECT MaMonHoc FROM MonHoc"));       // ma MH len ComboBox
            };
        }

        // Kiem tra dong Diem (MaSinhVien, MaMonHoc) da ton tai chua (khoa chinh)
        bool DiemTonTai(string sv, string mh)
        {
            return Db.Exists(connsql, "SELECT * FROM Diem WHERE MaSinhVien = @sv AND MaMonHoc = @mh",
                Db.P("@sv", sv), Db.P("@mh", mh));
        }

        // Doc va kiem tra Diem hop le: phai la so trong khoang 0 - 10
        bool DocDiem(out double diem)
        {
            if (!UI.TryDiem(txtDiem.Text, out diem)) { UI.Warn("Điểm chỉ được nhập số"); txtDiem.Focus(); return false; }
            if (diem < 0 || diem > 10) { UI.Warn("Điểm phải nằm trong khoảng 0 - 10"); txtDiem.Focus(); return false; }
            return true;
        }

        // THEM: SV, MH phai ton tai (khoa ngoai), khong trung khoa chinh, diem 0-10
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(cboSV, "Mã sinh viên") || !UI.Require(cboMH, "Mã môn học") || !UI.Require(txtDiem, "Điểm")) return;
            double diem;
            if (!DocDiem(out diem)) return;
            string sv = cboSV.SelectedItem.ToString(), mh = cboMH.SelectedItem.ToString();
            try
            {
                if (!Db.Exists(connsql, "SELECT 1 FROM SinhVien WHERE MaSinhVien = @sv", Db.P("@sv", sv))) { UI.Warn("Mã sinh viên không tồn tại"); return; }
                if (!Db.Exists(connsql, "SELECT 1 FROM MonHoc WHERE MaMonHoc = @mh", Db.P("@mh", mh))) { UI.Warn("Mã môn học không tồn tại"); return; }
                if (DiemTonTai(sv, mh)) { UI.Warn("Trùng khóa chính: sinh viên đã có điểm môn này"); return; }

                Db.NonQuery(connsql, "INSERT INTO Diem(MaSinhVien, MaMonHoc, Diem) VALUES(@sv, @mh, @d)",
                    Db.P("@sv", sv), Db.P("@mh", mh), Db.P("@d", diem));
                UI.Info("Thêm thành công");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // XOA: dong diem phai ton tai; Diem khong can nhap
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!UI.Require(cboSV, "Mã sinh viên") || !UI.Require(cboMH, "Mã môn học")) return;
            string sv = cboSV.SelectedItem.ToString(), mh = cboMH.SelectedItem.ToString();
            try
            {
                if (!DiemTonTai(sv, mh)) { UI.Warn("Sinh viên chưa có điểm môn học này"); return; }
                Db.NonQuery(connsql, "DELETE FROM Diem WHERE MaSinhVien = @sv AND MaMonHoc = @mh", Db.P("@sv", sv), Db.P("@mh", mh));
                UI.Info("Xóa thành công");
            }
            catch (Exception ex) { UI.Error("Xóa thất bại: " + ex.Message); }
        }

        // SUA: dong diem phai ton tai; diem 0-10
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!UI.Require(cboSV, "Mã sinh viên") || !UI.Require(cboMH, "Mã môn học") || !UI.Require(txtDiem, "Điểm")) return;
            double diem;
            if (!DocDiem(out diem)) return;
            string sv = cboSV.SelectedItem.ToString(), mh = cboMH.SelectedItem.ToString();
            try
            {
                if (!DiemTonTai(sv, mh)) { UI.Warn("Sinh viên chưa có điểm môn học này"); return; }
                Db.NonQuery(connsql, "UPDATE Diem SET Diem = @d WHERE MaSinhVien = @sv AND MaMonHoc = @mh",
                    Db.P("@d", diem), Db.P("@sv", sv), Db.P("@mh", mh));
                UI.Info("Sửa thành công");
            }
            catch (Exception ex) { UI.Error("Sửa thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // NANG CAO - BAI 1: Danh sach Lop tren ListView
    // ------------------------------------------------------------------
    public class FrmDanhSachLop : Form
    {
        SqlConnection connsql = Db.Conn();
        ListView lvLop;

        public FrmDanhSachLop()
        {
            UI.Config(this, "Danh sách Lớp", 520, 340);
            UI.Btn(this, "Hiển thị dữ liệu", 15, 12, btnHienThi_Click, 110);

            lvLop = new ListView { Left = 15, Top = 50, Width = 490, Height = 230, View = View.Details, FullRowSelect = true, GridLines = true };
            lvLop.Columns.Add("STT", 50);
            lvLop.Columns.Add("Mã lớp", 110);
            lvLop.Columns.Add("Tên lớp", 230);
            lvLop.Columns.Add("Mã khoa", 90);
            Controls.Add(lvLop);

            UI.Btn(this, "Thoát", 405, 295, delegate { Close(); }, 100);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                lvLop.Items.Clear();
                connsql.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaLop, TenLop, MaKhoa FROM Lop ORDER BY MaLop", connsql);
                SqlDataReader rd = cmd.ExecuteReader();
                int stt = 1;
                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(stt.ToString());   // cot 1: STT
                    item.SubItems.Add(rd["MaLop"].ToString());              // cot 2: Ma lop
                    item.SubItems.Add(rd["TenLop"].ToString());             // cot 3: Ten lop
                    item.SubItems.Add(rd["MaKhoa"].ToString());             // cot 4: Ma khoa
                    lvLop.Items.Add(item);
                    stt++;
                }
                rd.Close();
            }
            catch (Exception ex) { UI.Error("Lỗi: " + ex.Message); }
            finally { if (connsql.State == System.Data.ConnectionState.Open) connsql.Close(); }
        }
    }

    // ------------------------------------------------------------------
    // NANG CAO - BAI 2: Danh sach diem sinh vien theo mon hoc tren ListView
    // ------------------------------------------------------------------
    public class FrmDanhSachDiem : Form
    {
        SqlConnection connsql = Db.Conn();
        ComboBox cboMonHoc;
        ListView lvDiem;
        TextBox txtTongDiem;

        public FrmDanhSachDiem()
        {
            UI.Config(this, "Danh sách sinh viên", 560, 420);
            UI.Lbl(this, "Môn học", 20, 15);
            cboMonHoc = UI.Cbo(this, 90, 15, 200);
            UI.Btn(this, "Lọc dữ liệu", 330, 13, btnLoc_Click, 100);

            lvDiem = new ListView { Left = 15, Top = 55, Width = 530, Height = 280, View = View.Details, FullRowSelect = true, GridLines = true };
            lvDiem.Columns.Add("STT", 45);
            lvDiem.Columns.Add("Tên SV", 150);
            lvDiem.Columns.Add("Ngày sinh", 90);
            lvDiem.Columns.Add("Tên môn học", 170);
            lvDiem.Columns.Add("Điểm", 60);
            Controls.Add(lvDiem);

            UI.Lbl(this, "Tổng điểm", 330, 350);
            txtTongDiem = UI.Txt(this, 410, 350, 100);
            txtTongDiem.ReadOnly = true;

            Load += frmDanhSachDiem_Load;
        }

        // Su kien Load: do ma mon hoc (them 1 item khoang trang = tat ca), hien thi tat ca du lieu, tinh tong diem
        private void frmDanhSachDiem_Load(object sender, EventArgs e)
        {
            try
            {
                cboMonHoc.Items.Clear();
                cboMonHoc.Items.Add(" ");                                                      // khoang trang = tat ca mon hoc
                foreach (string ma in Db.Column(connsql, "SELECT MaMonHoc FROM MonHoc ORDER BY MaMonHoc")) cboMonHoc.Items.Add(ma);
                cboMonHoc.SelectedIndex = 0;
                HienThi("");
            }
            catch (Exception ex) { UI.Error("Lỗi: " + ex.Message); }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            HienThi(cboMonHoc.SelectedItem == null ? "" : cboMonHoc.SelectedItem.ToString().Trim());
        }

        // Hien thi diem len ListView; maMH rong = tat ca mon. Dong thoi cap nhat Tong diem theo ket qua dang hien thi.
        private void HienThi(string maMH)
        {
            try
            {
                lvDiem.Items.Clear();
                double tong = 0;
                connsql.Open();
                string sql = "SELECT sv.HoTen, sv.NgaySinh, mh.TenMonHoc, d.Diem " +
                             "FROM Diem d " +
                             "JOIN SinhVien sv ON sv.MaSinhVien = d.MaSinhVien " +
                             "JOIN MonHoc mh ON mh.MaMonHoc = d.MaMonHoc " +
                             "WHERE (@mh = '' OR d.MaMonHoc = @mh) " +
                             "ORDER BY sv.MaSinhVien, mh.MaMonHoc";
                SqlCommand cmd = new SqlCommand(sql, connsql);
                cmd.Parameters.AddWithValue("@mh", maMH);
                SqlDataReader rd = cmd.ExecuteReader();
                int stt = 1;
                while (rd.Read())
                {
                    double diem = Convert.ToDouble(rd["Diem"]);
                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(rd["HoTen"].ToString());
                    item.SubItems.Add(((DateTime)rd["NgaySinh"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(rd["TenMonHoc"].ToString());
                    item.SubItems.Add(diem.ToString());
                    lvDiem.Items.Add(item);
                    tong += diem;
                    stt++;
                }
                rd.Close();
                txtTongDiem.Text = tong.ToString();
            }
            catch (Exception ex) { UI.Error("Lỗi: " + ex.Message); }
            finally { if (connsql.State == System.Data.ConnectionState.Open) connsql.Close(); }
        }
    }
}
