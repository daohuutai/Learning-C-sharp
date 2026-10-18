using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab06
{
    /// <summary>Phan tu cua ComboBox: luu gia tri (ma) va chu hien thi.</summary>
    public class ComboItem
    {
        public string Value;
        public string Text;
        public ComboItem(string value, string text) { Value = value; Text = text; }
        public override string ToString() { return Text; }
    }

    /// <summary>Ham ho tro tao control bang code (khong can Designer) va kiem tra rang buoc giao dien.</summary>
    public static class UI
    {
        public static void Config(Form f, string title, int w, int h)
        {
            f.Text = title;
            f.ClientSize = new Size(w, h);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.MaximizeBox = false;
            f.Font = new Font("Segoe UI", 9F);
        }

        public static Label Lbl(Control p, string text, int x, int y)
        {
            Label l = new Label { Text = text, Left = x, Top = y + 3, AutoSize = true };
            p.Controls.Add(l);
            return l;
        }

        public static TextBox Txt(Control p, int x, int y, int w = 220)
        {
            TextBox t = new TextBox { Left = x, Top = y, Width = w };
            p.Controls.Add(t);
            return t;
        }

        /// <summary>O nhap ngay sinh dang __/__/____ (dd/MM/yyyy).</summary>
        public static MaskedTextBox DateBox(Control p, int x, int y, int w = 120)
        {
            MaskedTextBox m = new MaskedTextBox
            {
                Mask = "00/00/0000",
                Left = x,
                Top = y,
                Width = w,
                TextMaskFormat = MaskFormat.ExcludePromptAndLiterals // .Text chi chua cac chu so da nhap
            };
            p.Controls.Add(m);
            return m;
        }

        public static ComboBox Cbo(Control p, int x, int y, int w = 220)
        {
            ComboBox c = new ComboBox { Left = x, Top = y, Width = w, DropDownStyle = ComboBoxStyle.DropDownList };
            p.Controls.Add(c);
            return c;
        }

        public static Button Btn(Control p, string text, int x, int y, EventHandler click, int w = 80)
        {
            Button b = new Button { Text = text, Left = x, Top = y, Width = w, Height = 28 };
            b.Click += click;
            p.Controls.Add(b);
            return b;
        }

        public static void Info(string msg) { MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        public static void Warn(string msg) { MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        public static void Error(string msg) { MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        /// <summary>Kiem tra control khong duoc rong. Neu rong: bao loi, dat con tro vao control, tra ve false.</summary>
        public static bool Require(Control c, string tenTruong)
        {
            if (c.Text.Trim() == string.Empty)
            {
                Warn("Bạn phải nhập " + tenTruong);
                c.Focus();
                return false;
            }
            return true;
        }

        /// <summary>Doc ngay sinh tu MaskedTextBox (ddMMyyyy). Sai dinh dang -> false.</summary>
        public static bool TryDate(MaskedTextBox m, out DateTime d)
        {
            return DateTime.TryParseExact(m.Text, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
        }

        /// <summary>Doc diem (chap nhan dau , hoac .). Chi cho phep so.</summary>
        public static bool TryDiem(string s, out double diem)
        {
            return double.TryParse(s.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out diem);
        }

        /// <summary>Do danh sach len ComboBox.</summary>
        public static void Fill(ComboBox cbo, System.Collections.Generic.List<string> items)
        {
            cbo.Items.Clear();
            foreach (string s in items) cbo.Items.Add(s);
        }
    }
}
