// =====================================================================
// THUC HANH 06b - VE NHA BAI 1: CSDL QLCuaHang
//   FrmCuaHang : form chinh co thanh menu (Tao ton kho / Them san pham / Ban hang)
//   FrmSanPham : them san pham moi (+ them dong ton kho SLDau = 0, SLNhap = 0, SLBan = 0)
//   FrmBanHang : tao hoa don, them chi tiet hoa don, huy, thanh toan
// CSDL: SANPHAM(MaSP, TenSP) - TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan)
//       HOADON(MaHD, NgayTao, TinhTrangThanhToan) - CHITIET_HOADON(MaHD, MaSP, SoLuong)
// =====================================================================
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab06
{
    // ------------------------------------------------------------------
    // FORM CHINH: thanh menu
    // ------------------------------------------------------------------
    public class FrmCuaHang : Form
    {
        public FrmCuaHang()
        {
            UI.Config(this, "Quản lý cửa hàng", 800, 500);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            IsMdiContainer = true;                       // form chinh chua cac form con

            MenuStrip menu = new MenuStrip();
            ToolStripMenuItem mnuTon = new ToolStripMenuItem("Tạo tồn kho");
            ToolStripMenuItem mnuSP = new ToolStripMenuItem("Thêm sản phẩm mới");
            ToolStripMenuItem mnuBan = new ToolStripMenuItem("Bán hàng");
            mnuTon.Click += mnuTaoTonKho_Click;
            mnuSP.Click += delegate { MoForm(new FrmSanPham()); };
            mnuBan.Click += delegate { MoForm(new FrmBanHang()); };
            menu.Items.AddRange(new ToolStripItem[] { mnuTon, mnuSP, mnuBan });
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        private void MoForm(Form f)
        {
            f.MdiParent = this;
            f.Show();
        }

        // Tao du lieu ton kho cho NGAY HIEN TAI (thuc hien 1 lan moi ngay, truoc khi ban/nhap hang):
        //   SLDau = SLDau(ngay truoc) + SLNhap(ngay truoc) - SLBan(ngay truoc)
        //   SLNhap = 0 ; SLBan = 0
        private void mnuTaoTonKho_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Db.Conn("QLCuaHang");
            try
            {
                string sql =
                    "INSERT INTO TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan) " +
                    "SELECT s.MaSP, @ngay, ISNULL(t.SLDau + t.SLNhap - t.SLBan, 0), 0, 0 " +
                    "FROM SANPHAM s " +
                    "OUTER APPLY (SELECT TOP 1 k.SLDau, k.SLNhap, k.SLBan FROM TONKHO k " +
                    "             WHERE k.MaSP = s.MaSP AND k.NgayTon < @ngay ORDER BY k.NgayTon DESC) t " +   // dong ton kho gan nhat truoc hom nay
                    "WHERE NOT EXISTS (SELECT 1 FROM TONKHO k WHERE k.MaSP = s.MaSP AND k.NgayTon = @ngay)";    // chua tao hom nay
                SqlParameter ngay = new SqlParameter("@ngay", SqlDbType.Date) { Value = DateTime.Today };
                int kq = Db.NonQuery(conn, sql, ngay);
                if (kq > 0) UI.Info("Đã tạo tồn kho cho " + kq + " sản phẩm (ngày " + DateTime.Today.ToString("dd/MM/yyyy") + ")");
                else UI.Warn("Tồn kho ngày hôm nay đã được tạo trước đó (hoặc chưa có sản phẩm)");
            }
            catch (Exception ex) { UI.Error("Tạo tồn kho thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // FORM THEM SAN PHAM
    // ------------------------------------------------------------------
    public class FrmSanPham : Form
    {
        SqlConnection conn = Db.Conn("QLCuaHang");
        TextBox txtMaSP, txtTenSP;

        public FrmSanPham()
        {
            UI.Config(this, "Sản phẩm", 330, 130);
            UI.Lbl(this, "Mã SP", 15, 15);  txtMaSP = UI.Txt(this, 90, 15, 210);
            txtMaSP.ReadOnly = true;                                  // MaSP tu dong tang
            UI.Lbl(this, "Tên SP", 15, 45); txtTenSP = UI.Txt(this, 90, 45, 210);
            UI.Btn(this, "Thêm", 125, 85, btnThem_Click);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(txtTenSP, "Tên sản phẩm")) return;
            try
            {
                int maSP = 0;
                // Thuc hien 2 lenh trong 1 transaction: them SANPHAM va them dong TONKHO ban dau (0, 0, 0)
                Db.InTransaction(conn, tr =>
                {
                    maSP = (int)Db.ScalarTr(conn, tr,
                        "INSERT INTO SANPHAM(TenSP) OUTPUT INSERTED.MaSP VALUES(@ten)",
                        Db.P("@ten", txtTenSP.Text.Trim()));

                    SqlParameter ngay = new SqlParameter("@ngay", SqlDbType.Date) { Value = DateTime.Today };
                    Db.NonQueryTr(conn, tr,
                        "INSERT INTO TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan) VALUES(@ma, @ngay, 0, 0, 0)",
                        Db.P("@ma", maSP), ngay);
                });
                txtMaSP.Text = maSP.ToString();
                UI.Info("Thêm sản phẩm thành công (mã " + maSP + ")");
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }
    }

    // ------------------------------------------------------------------
    // FORM BAN HANG
    // ------------------------------------------------------------------
    public class FrmBanHang : Form
    {
        SqlConnection conn = Db.Conn("QLCuaHang");
        GroupBox grpChiTiet;
        TextBox txtMaHD, txtSoLuong;
        ComboBox cboSP;
        Button btnThem, btnHuy, btnThanhToan;

        public FrmBanHang()
        {
            UI.Config(this, "Bán hàng", 400, 250);
            UI.Btn(this, "Tạo hóa đơn mới", 130, 12, btnTaoHD_Click, 130);

            grpChiTiet = new GroupBox { Text = "Chi tiết hóa đơn", Left = 15, Top = 50, Width = 365, Height = 180 };
            Controls.Add(grpChiTiet);
            UI.Lbl(grpChiTiet, "Mã hóa đơn", 15, 25); txtMaHD = UI.Txt(grpChiTiet, 110, 25, 230); txtMaHD.ReadOnly = true;
            UI.Lbl(grpChiTiet, "Sản phẩm", 15, 60);   cboSP = UI.Cbo(grpChiTiet, 110, 60, 230);
            UI.Lbl(grpChiTiet, "Số lượng", 15, 95);   txtSoLuong = UI.Txt(grpChiTiet, 110, 95, 230);
            btnThem = UI.Btn(grpChiTiet, "Thêm", 15, 135, btnThem_Click);
            btnHuy = UI.Btn(grpChiTiet, "Hủy", 130, 135, btnHuy_Click);
            btnThanhToan = UI.Btn(grpChiTiet, "Thanh toán", 245, 135, btnThanhToan_Click, 95);

            grpChiTiet.Enabled = false;              // ban dau cac control bi mo (disable)
            Load += delegate { LoadSanPham(); };
        }

        // Hien thi ma san pham (kem ten) len ComboBox
        private void LoadSanPham()
        {
            try
            {
                cboSP.Items.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaSP, TenSP FROM SANPHAM ORDER BY MaSP", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) cboSP.Items.Add(new ComboItem(rd["MaSP"].ToString(), rd["MaSP"] + " - " + rd["TenSP"]));
                rd.Close();
            }
            catch (Exception ex) { UI.Error("Không tải được sản phẩm: " + ex.Message); }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }

        // Tao hoa don moi: them vao HOADON (MaHD tu tang, ngay tao = hom nay, tinh trang = 0)
        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            try
            {
                object ma = Db.Scalar(conn,
                    "INSERT INTO HOADON(NgayTao, TinhTrangThanhToan) OUTPUT INSERTED.MaHD VALUES(@ngay, 0)",
                    Db.P("@ngay", DateTime.Today));
                txtMaHD.Text = ma.ToString();         // ghi ma hoa don vua tao vao textbox
                txtSoLuong.Clear();
                cboSP.SelectedIndex = -1;
                grpChiTiet.Enabled = true;            // hien thi cac control: san pham, so luong, Them, Huy, Thanh toan
            }
            catch (Exception ex) { UI.Error("Tạo hóa đơn thất bại: " + ex.Message); }
        }

        // THEM chi tiet hoa don
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!UI.Require(cboSP, "sản phẩm") || !UI.Require(txtSoLuong, "số lượng")) return;
            int sl;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out sl) || sl <= 0)
            { UI.Warn("Số lượng phải là số nguyên lớn hơn 0"); txtSoLuong.Focus(); return; }

            int maHD = int.Parse(txtMaHD.Text);
            int maSP = int.Parse(((ComboItem)cboSP.SelectedItem).Value);
            SqlParameter ngay = new SqlParameter("@ngay", SqlDbType.Date) { Value = DateTime.Today };

            try
            {
                // Kiem tra khoa ngoai: san pham, hoa don phai ton tai
                if (!Db.Exists(conn, "SELECT 1 FROM SANPHAM WHERE MaSP = @sp", Db.P("@sp", maSP))) { UI.Warn("Sản phẩm không tồn tại"); return; }
                if (!Db.Exists(conn, "SELECT 1 FROM HOADON WHERE MaHD = @hd", Db.P("@hd", maHD))) { UI.Warn("Hóa đơn không tồn tại"); return; }

                // Kiem tra khoa chinh (MaHD, MaSP) khong trung
                if (Db.Exists(conn, "SELECT 1 FROM CHITIET_HOADON WHERE MaHD = @hd AND MaSP = @sp", Db.P("@hd", maHD), Db.P("@sp", maSP)))
                { UI.Warn("Sản phẩm này đã có trong hóa đơn"); return; }

                // So luong ban phai > 0 va khong vuot qua so luong ton (SLDau + SLNhap - SLBan)
                object tonObj = Db.Scalar(conn, "SELECT SLDau + SLNhap - SLBan FROM TONKHO WHERE MaSP = @sp AND NgayTon = @ngay",
                    Db.P("@sp", maSP), ngay);
                if (tonObj == null) { UI.Warn("Chưa tạo tồn kho hôm nay cho sản phẩm này (menu Tạo tồn kho)"); return; }
                int ton = Convert.ToInt32(tonObj);
                if (sl > ton) { UI.Warn("Số lượng bán vượt quá số lượng tồn (" + ton + ")"); txtSoLuong.Focus(); return; }

                // Cach 1: dung SqlCommand Update de cap nhat tong SLBan trong TONKHO.
                // Them chi tiet + cap nhat ton kho nam trong 1 transaction.
                Db.InTransaction(conn, tr =>
                {
                    Db.NonQueryTr(conn, tr, "INSERT INTO CHITIET_HOADON(MaHD, MaSP, SoLuong) VALUES(@hd, @sp, @sl)",
                        Db.P("@hd", maHD), Db.P("@sp", maSP), Db.P("@sl", sl));
                    Db.NonQueryTr(conn, tr, "UPDATE TONKHO SET SLBan = SLBan + @sl WHERE MaSP = @sp AND NgayTon = @ngay",
                        Db.P("@sl", sl), Db.P("@sp", maSP), new SqlParameter("@ngay", SqlDbType.Date) { Value = DateTime.Today });
                });
                UI.Info("Thêm vào hóa đơn thành công");
                txtSoLuong.Clear();
                cboSP.SelectedIndex = -1;
            }
            catch (Exception ex) { UI.Error("Thêm thất bại: " + ex.Message); }
        }

        // HUY hoa don: tra lai SLBan trong TONKHO, xoa chi tiet va xoa hoa don
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            int maHD = int.Parse(txtMaHD.Text);
            try
            {
                Db.InTransaction(conn, tr =>
                {
                    // Hoan lai so luong ban cua tung san pham trong hoa don
                    Db.NonQueryTr(conn, tr,
                        "UPDATE t SET t.SLBan = t.SLBan - c.SoLuong " +
                        "FROM TONKHO t JOIN CHITIET_HOADON c ON c.MaSP = t.MaSP " +
                        "WHERE c.MaHD = @hd AND t.NgayTon = @ngay",
                        Db.P("@hd", maHD), new SqlParameter("@ngay", SqlDbType.Date) { Value = DateTime.Today });
                    Db.NonQueryTr(conn, tr, "DELETE FROM CHITIET_HOADON WHERE MaHD = @hd", Db.P("@hd", maHD));
                    Db.NonQueryTr(conn, tr, "DELETE FROM HOADON WHERE MaHD = @hd", Db.P("@hd", maHD));
                });
                UI.Info("Đã hủy hóa đơn");
                KetThucHoaDon();
            }
            catch (Exception ex) { UI.Error("Hủy thất bại: " + ex.Message); }
        }

        // THANH TOAN: cap nhat tinh trang hoa don = 1
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                int kq = Db.NonQuery(conn, "UPDATE HOADON SET TinhTrangThanhToan = 1 WHERE MaHD = @hd", Db.P("@hd", int.Parse(txtMaHD.Text)));
                if (kq > 0) UI.Info("Thanh toán thành công");
                KetThucHoaDon();
            }
            catch (Exception ex) { UI.Error("Thanh toán thất bại: " + ex.Message); }
        }

        // Ket thuc hoa don: lam mo lai cac control cho den khi tao hoa don moi
        private void KetThucHoaDon()
        {
            txtMaHD.Clear();
            txtSoLuong.Clear();
            cboSP.SelectedIndex = -1;
            grpChiTiet.Enabled = false;
        }
    }
}
