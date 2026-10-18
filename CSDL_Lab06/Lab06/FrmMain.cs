using System;
using System.Windows.Forms;

namespace Lab06
{
    /// <summary>Form menu: bam nut de mo tung bai thuc hanh.</summary>
    public class FrmMain : Form
    {
        public FrmMain()
        {
            UI.Config(this, "Lab06 - Tương tác CSDL (SqlConnection / SqlCommand / SqlDataReader)", 560, 370);

            GroupBox g6a = new GroupBox { Text = "Thực hành 06a", Left = 15, Top = 10, Width = 255, Height = 345 };
            GroupBox g6b = new GroupBox { Text = "Thực hành 06b", Left = 285, Top = 10, Width = 260, Height = 345 };
            Controls.Add(g6a);
            Controls.Add(g6b);

            int y = 25;
            Add(g6a, ref y, "Bài mẫu - Quản lý Khoa", () => new FrmKhoa6a());
            Add(g6a, ref y, "Tại lớp 1 - Quản lý Môn học", () => new FrmMonHoc6a());
            Add(g6a, ref y, "Nâng cao 1 - Quản lý Sinh viên", () => new FrmSinhVien6a());
            Add(g6a, ref y, "Nâng cao 2 - Quản lý Điểm", () => new FrmDiem6a());
            Add(g6a, ref y, "Về nhà 1 - Quản lý Lớp", () => new FrmLop6a());

            y = 25;
            Add(g6b, ref y, "Bài mẫu 1 - Quản lý Khoa", () => new FrmKhoa6b());
            Add(g6b, ref y, "Bài mẫu 2 - Quản lý Lớp", () => new FrmLop6b());
            Add(g6b, ref y, "Tại lớp 1 - Sinh viên", () => new FrmSinhVien6b());
            Add(g6b, ref y, "Tại lớp 2 - Điểm", () => new FrmDiem6b());
            Add(g6b, ref y, "Nâng cao 1 - ListView Lớp", () => new FrmDanhSachLop());
            Add(g6b, ref y, "Nâng cao 2 - ListView Điểm", () => new FrmDanhSachDiem());
            Add(g6b, ref y, "Về nhà 1 - Quản lý cửa hàng", () => new FrmCuaHang());
        }

        // Tao 1 nut mo form tuong ung
        private void Add(GroupBox g, ref int y, string text, Func<Form> tao)
        {
            Button b = new Button { Text = text, Left = 15, Top = y, Width = g.Width - 30, Height = 36 };
            b.Click += delegate
            {
                using (Form f = tao()) { f.ShowDialog(this); }
            };
            g.Controls.Add(b);
            y += 44;
        }
    }
}
