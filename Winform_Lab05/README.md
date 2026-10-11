# Lab05 – Lập trình Windows Form nâng cao

**Môn:** Ngôn ngữ lập trình trong C# (NNLTCS) – Trường Đại học Sài Gòn, Khoa Công nghệ Thông tin
**Sinh viên:** Đào Hữu Tài – MSSV 3124411261 – Lớp DCT12C3
**Nội dung:** Thực hành 05 – Bài tập 5c và 5d

Ứng dụng Windows Forms gom toàn bộ bài tập của Lab05 vào một form chính. Chọn bài ở thanh menu, form tương ứng sẽ được mở.

## Yêu cầu

- Windows (project dùng Windows Forms)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) hoặc Visual Studio 2022 trở lên có workload *.NET desktop development*

## Chạy chương trình

```bash
cd Lab05_WinFormAdv
dotnet run
```

Hoặc mở project `Lab05_WinFormAdv.csproj` bằng Visual Studio rồi nhấn **F5**.

## Cấu trúc

```
Lab05_WinFormAdv/
├── Program.cs        # Điểm vào, chạy FrmMain
├── FrmMain.cs        # Form chính: MenuStrip "Bài 5c", "Bài 5d", "Thoát"
├── Helper.cs         # Hàm dùng chung: tạo Label/TextBox/Button, XacNhanDong, InputBox
├── Bai5c/            # ListBox, ComboBox, TreeView, TabControl
└── Bai5d/            # Timer, ListView, Menu, Dialog
```

Mỗi bài là **một file `.cs` độc lập** (một class form). Giao diện được dựng hoàn toàn bằng code trong constructor, không dùng Designer.

## Danh sách bài tập

### Bài 5c – ListBox / ComboBox / TreeView

| Loại | Bài | File | Class |
|---|---|---|---|
| Mẫu 1 | Chuyển phần tử giữa hai ListBox | `C_Mau1_ListBox.cs` | `FrmListBoxMau` |
| Mẫu 2 | ComboBox dân tộc | `C_Mau2_ComboBox.cs` | `FrmCboDanToc` |
| Mẫu 3 | TreeView phòng ban – nhân viên | `C_Mau3_TreeView.cs` | `FrmTreeView` |
| Tại lớp 1 | Ước số (tổng, ước chẵn, ước nguyên tố) | `C_TL1_UocSo.cs` | `FrmUocSo` |
| Tại lớp 2 | Quản lý sinh viên theo lớp (TreeView) | `C_TL2_QuanLySV.cs` | `FrmQuanLySV` |
| Nâng cao 1 | Xử lý chuỗi trên ListBox (50 tên ngẫu nhiên) | `C_NC1_XuLyChuoi.cs` | `FrmXuLyChuoi` |
| Về nhà 1 | Từ điển Anh – Việt / Việt – Anh (TabControl) | `C_VN1_TuDien.cs` | `FrmTuDien` |
| Về nhà 2 | ListBox số tự nhiên (chọn nhiều dòng) | `C_VN2_ListBoxSo.cs` | `FrmListBoxSo` |
| Về nhà 3 | Danh bạ (TreeView A–Z) | `C_VN3_DanhBa.cs` | `FrmDanhBa` |

### Bài 5d – Timer / ListView / Menu / Dialog

| Loại | Bài | File | Class |
|---|---|---|---|
| Mẫu 1 | Đồng hồ dùng Timer | `D_Mau1_Timer.cs` | `FrmTimer` |
| Mẫu 2 | ListView với Thêm / Xóa / Sửa | `D_Mau2_ListView.cs` | `FrmListViewMau` |
| Mẫu 3 | Lưu / mở file `.txt` (Save/Open FileDialog) | `D_Mau3_Dialog.cs` | `FrmFileDialog` |
| Tại lớp 1 | Quản lý thông tin sinh viên (ListView) | `D_TL1_ThongTinSV.cs` | `FrmThongTinSV` |
| Tại lớp 2 | Quản lý tài khoản ngân hàng | `D_TL2_TaiKhoan.cs` | `FrmTaiKhoan` |
| Nâng cao 1 | Quản lý học viên (MenuStrip + 2 ListBox) | `D_NC1_QuanLyHocVien.cs` | `FrmQuanLyHocVien` |
| Về nhà 1 | Đồng hồ đếm ngược | `D_VN1_DemNguoc.cs` | `FrmDemNguoc` |

Form chính `FrmMain` chính là **Bài về nhà 2 của 5d** (menu gắn tất cả bài tập).

## Kiến thức sử dụng

- **Control:** TextBox, Label, Button, ListBox, ComboBox, TreeView, TabControl, ListView, MenuStrip, ContextMenuStrip, Timer, RichTextBox
- **Hộp thoại:** SaveFileDialog, OpenFileDialog, MessageBox, InputBox tự viết (`Helper.InputBox`)
- **Xử lý sự kiện:** `Load`, `Click`, `SelectedIndexChanged`, `FormClosing`, `Tick`
- **Kiểm tra dữ liệu:** rỗng, trùng, sai định dạng (`int.TryParse`), xác nhận trước khi xóa / đóng form

## Báo cáo

Báo cáo chi tiết (yêu cầu, cách thực hiện, kết quả từng bài): `Lab05_BaoCao_DaoHuuTai_3124411261.docx`.
