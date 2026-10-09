# Lab 04 – Lập trình Windows Forms cơ bản (C# / .NET 8)

Bộ bài thực hành **Thực hành 4c** và **4d** về WinForm, gom vào một ứng dụng duy nhất có menu chọn bài. Bấm vào bài nào thì form của bài đó mở ra; đóng form thì quay lại menu.

## Yêu cầu

- Windows (WinForms chỉ chạy trên Windows)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) hoặc Visual Studio 2022 trở lên
- Dùng .NET khác (net6.0, net9.0…) thì sửa `TargetFramework` trong `BaiThucHanhWinForm.csproj`, ví dụ `net9.0-windows`.

## Cách chạy

```bash
cd Winform_Lab04
dotnet run
```

Hoặc mở `BaiThucHanhWinForm.csproj` bằng Visual Studio rồi nhấn **F5**. Cũng có thể chạy thẳng bản đã build: `bin/Debug/net8.0-windows/BaiThucHanhWinForm.exe`.

## Cấu trúc thư mục

```
Winform_Lab04/
├── Program.cs                  # Điểm vào, mở FormMenu
├── FormMenu.cs                 # Menu chọn bài (4c + 4d)
├── UiHelper.cs                 # Hàm dựng nhanh Button, GroupBox... dùng chung
├── BaiThucHanhWinForm.csproj   # File project (net8.0-windows, UseWindowsForms)
├── TH4c/                       # Thực hành 4c – WinForm Basic 1
├── TH4d/                       # Thực hành 4d – WinForm Basic 2
├── bin/, obj/                  # File build (sinh tự động, có thể xóa)
```

## Danh sách bài

### Thực hành 4c – WinForm Basic 1 (`TH4c/`)

| # | Bài | File | Nội dung |
|---|-----|------|----------|
| 1 | Bài mẫu | `Bai4c_Mau.cs` | My Name Project: nhập tên + năm sinh, hiện tên và tuổi; dùng `ErrorProvider` |
| 2 | Tại lớp 1 | `Bai4c_TL1_PhepTinh.cs` | Cộng, trừ, nhân, chia hai số; báo lỗi bằng `ErrorProvider` / `MessageBox` |
| 3 | Tại lớp 2 | `Bai4c_TL2_DangKy.cs` | Form đăng ký tài khoản: kiểm tra email, ô bắt buộc, xác nhận khi đóng |
| 4 | Tại lớp 3 | `Bai4c_TL3_UCLN_BCNN.cs` | Tìm UCLN và BCNN của hai số nguyên dương |
| 5 | Tại lớp 4 | `Bai4c_TL4_DaySo.cs` | Nhập dãy số, tính tổng, tổng chẵn, tổng lẻ |
| 6 | Tại lớp 5 | `Bai4c_TL5_DocSo.cs` | Đọc số từ 1 đến 999 thành chữ |
| 7 | Nâng cao 1 | `Bai4c_NC1_RapPhim.cs` | Bán vé rạp chiếu phim: 15 ghế, 3 lô giá 1000 / 1500 / 2000 |
| 8 | Về nhà 1 | `Bai4c_VN1_MayTinh.cs` | Máy tính bỏ túi đơn giản |

### Thực hành 4d – WinForm Basic 2 (`TH4d/`)

| # | Bài | File | Nội dung |
|---|-----|------|----------|
| 1 | Mẫu 1 | `Bai4d_Mau1_Radio.cs` | Cộng trừ nhân chia bằng `RadioButton`, dùng class `TinhToan` |
| 2 | Mẫu 2 | `Bai4d_Mau2_Format.cs` | Định dạng Font Style (`CheckBox`) và Color (`RadioButton`) cho `Label` |
| 3 | Tại lớp 1 | `Bai4d_TL1_PhuongTrinh.cs` | Giải phương trình bậc 1 và bậc 2, dùng class `PhuongTrinhBacHai` |
| 4 | Tại lớp 2 | `Bai4d_TL2_Mang.cs` | Các thao tác trên mảng một chiều số nguyên, dùng class `MangSoNguyen` |
| 5 | Nâng cao 1 | `Bai4d_NC1_CafeSinhVien.cs` | Tính tiền quán Cafe Sinh Viên, giảm 20% cho sinh viên |
| 6 | Về nhà 1 | `Bai4d_VN1_KhachSan.cs` | Thanh toán tiền phòng Khách sạn Thanh Thanh |

### Các class hỗ trợ (`TH4d/`)

- `TinhToan.cs`: lưu hai số a, b, có property get/set, hai constructor và các phép tính.
- `PhuongTrinhBacHai.cs`: lưu hệ số a, b, c và giải phương trình bậc 1 (`ax + b = 0`), bậc 2 (`ax² + bx + c = 0`).
- `MangSoNguyen.cs`: lưu và xử lý mảng một chiều số nguyên (index tính từ 0).

## Kiến thức được luyện

- Control cơ bản: `TextBox`, `Button`, `Label`, `RadioButton`, `CheckBox`, `GroupBox`, `ListBox`/`ComboBox`
- Xử lý sự kiện: `Click`, `KeyPress`, `Leave`, `CheckedChanged`, `FormClosing`
- Kiểm tra dữ liệu nhập và báo lỗi: `ErrorProvider`, `MessageBox`
- Tách logic ra class riêng (`TinhToan`, `PhuongTrinhBacHai`, `MangSoNguyen`) thay vì viết hết trong form

## Ghi chú

- Giao diện được dựng hoàn toàn bằng code, không dùng Designer.
- Thư mục `bin/` và `obj/` là file build, có thể xóa; `dotnet build` sẽ tạo lại.
