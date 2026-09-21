# Lab02 - Thực hành 1 (Ngôn ngữ lập trình C# cơ bản)

Họ tên: Trần Lê Gia Bảo
Mã SV: `<điền mã số sinh viên của bạn>`
Môn: Ngôn ngữ lập trình C#

> File đề bài dùng để làm: **NNLTCS - Thực Hành 01 - Ngôn ngữ lập trình C#.pdf**
> (đây là file 17 bài tập I/O, tham số ref/out, mảng, chuỗi — không phải file hướng dẫn Class Library/xUnit,
> và cũng chưa phải file Thực hành 02 - OOP).

## 1. Cấu trúc project

```
Lab02_ThucHanh/
├── Lab02_ThucHanh.csproj
├── Program.cs                 # Menu chính (chọn Thực hành 1 / Thực hành 2)
├── README.md
└── ThucHanh1/
    ├── MenuThucHanh1.cs        # Menu con, liệt kê 17 bài
    ├── Bai1.cs  ... Bai17.cs   # Mỗi bài một file, có hàm Run()
```

Menu được tách 2 tầng để sau này thêm Thực hành 2 (OOP) chỉ cần tạo thư mục
`ThucHanh2/` + `MenuThucHanh2.cs` rồi nối vào lựa chọn "2" trong `Program.cs`,
không phải sửa lại cấu trúc đã có.

## 2. Cách chạy

```bash
cd Lab02_ThucHanh
dotnet run
```

Chọn `1` để vào Thực hành 1, sau đó chọn số bài (1–17) để chạy, chọn `0` để quay lại,
chọn `0` ở menu chính để thoát chương trình.

**Lưu ý:** môi trường mình dùng để viết code không có sẵn .NET SDK nên chưa
`dotnet build`/`dotnet run` được để kiểm tra trực tiếp — code được viết và rà soát
thủ công theo đúng cú pháp C#/.NET 8. Bạn chạy thử ở máy có SDK, nếu gặp lỗi
biên dịch nào thì báo lại để mình sửa ngay.

## 3. Nhật ký làm việc (changelog)

- Đọc 3 file đính kèm trong bài tập trên Classroom (ảnh chụp màn hình) để xác định
  đúng file nào là "Thực hành 1": có 2 file tên gần giống nhau, một file là bài
  tập I/O cơ bản (đúng cái cần làm), một file là hướng dẫn có sẵn lời giải về
  Class Library + ProjectReference + xUnit (không phải bài cần làm bây giờ).
  → Đã hỏi lại và xác nhận dùng file bài tập I/O cơ bản.
- Xác nhận lại yêu cầu "không ghi chú" — vì đề bài chụp màn hình yêu cầu ngược lại
  ("nộp code có ghi chú rõ ràng"), nên giữ comment đầy đủ trong code thay vì bỏ.
- Thiết kế menu 2 tầng (menu chính → menu Thực hành 1) thay vì gộp thẳng 17 bài
  vào 1 menu, để đúng yêu cầu "menu chạy được cả thực hành 1 và 2" nhưng thực hành 2
  chưa cài đặt gì cả — chỉ để sẵn chỗ nối vào.
- Tách mỗi bài thành 1 class `static` riêng (`Bai1` … `Bai17`), mỗi class có hàm
  `Run()` để menu gọi, và các hàm xử lý logic (`Max3`, `LaSoNguyenTo`, `HoanVi`,
  `MaxMin`, `DaoNguoc`, ...) tách riêng khỏi `Run()` để dễ test/tái sử dụng —
  ví dụ Bài 15 gọi lại `Bai7.LaSoNguyenTo()` để lọc số nguyên tố trong mảng,
  không viết lại logic kiểm tra số nguyên tố lần 2.
- Bài 1 trong đề có 3 bước (B1 nhập/xuất họ tên, B2 dùng ildasm.exe xem MSIL,
  B3 dùng ilasm.exe biên dịch ngược lại) — B2, B3 là thao tác thủ công trên
  Developer Command Prompt/Visual Studio, không phải code, nên chỉ cài đặt phần
  B1 bằng code, còn B2/B3 ghi chú lại trong file `Bai1.cs` để bạn tự thao tác
  tay khi nộp bài (file .dll build ra nằm ở `bin/Debug/net8.0/`).
- Bài 4 dùng `int.TryParse` thay vì `int.Parse` để không bị crash khi nhập sai
  kiểu, rồi in thông báo lỗi theo đúng yêu cầu đề.
- Bài 9, Bài 15, Bài 17 dùng tham số `out` để trả về nhiều giá trị cùng lúc
  (đúng yêu cầu đề dùng `ref`/`out`).
- Bài 17 dùng `List<int>` tạm để gom số chẵn/lẻ trong lúc duyệt mảng 2 chiều,
  sau đó `ToArray()` để trả đúng kiểu `int[]` như đề yêu cầu.

## 4. Tóm tắt từng bài và kết quả chạy thử

Các kết quả bên dưới là **kết quả suy ra bằng tay theo logic code** (trace thủ công),
không phải kết quả chạy thật do môi trường soạn code không có .NET SDK — bạn nên
tự chạy `dotnet run` và đối chiếu lại trước khi nộp.

| Bài | Nội dung | Ví dụ input | Output mong đợi |
|---|---|---|---|
| 1 | Nhập/xuất họ tên | `Tran Anh Minh` | `Ho ten ban vua nhap la: Tran Anh Minh` |
| 2 | Xuất/nhập chuỗi đúng định dạng đề | `Tran Anh Minh` | `Chao ban Tran Anh Minh!` |
| 3 | Nhập x, y nguyên, tính x^y | x=7, y=3 | `Ket qua 7 mu 3 la: 343` |
| 4 | Như bài 3, bắt lỗi nhập sai | x="abc" | `Loi: x va y phai la so nguyen!` |
| 5 | Menu tính x^y, căn bậc 2 | x=4, y=9 → chọn 3 | `Can bac 2 cua x = 2`, `Can bac 2 cua y = 3` |
| 6 | Max của 3 số nguyên | 5, 9, 2 | `Gia tri lon nhat la: 9` |
| 7 | Kiểm tra số nguyên tố | n=17 | `17 la so nguyen to.` |
| 8 | Hoán vị 2 số thực (ref) | a=1.5, b=2.5 | `a = 2.5, b = 1.5` |
| 9 | Max/Min 3 số thực (out) | 3.2, 1.1, 5.6 | `max=5.6, min=1.1` |
| 10 | Kiểm tra chuỗi đối xứng | `abcba` | `Chuoi doi xung.` |
| 11 | Đảo ngược chuỗi | `Xin chao` | `oahc niX` |
| 12 | Chuỗi thường/hoa + đếm từ | `Xin chao ban` | 3 từ, `xin chao ban`, `XIN CHAO BAN` |
| 13 | Nhập/xuất sinh viên | mã, tên, địa chỉ, năm | in lại đủ 4 trường |
| 14 | Lương nhân viên | lương=5.000.000, vắng=2 | `Luong thuc nhan: 4800000` |
| 15 | Mảng 1 chiều: in, max/min, lọc số nguyên tố | `2 3 4 7 9` | max=9, min=2, nguyên tố: `2 3 7` |
| 16 | Sắp xếp mảng họ tên tăng dần | `Binh, An, Chi` | `An, Binh, Chi` |
| 17 | Mảng 2 chiều ngẫu nhiên [10,100], tách chẵn/lẻ | n=2,m=2 | in mảng + 2 danh sách chẵn/lẻ (kết quả ngẫu nhiên mỗi lần chạy) |

## 5. Việc chưa làm / cần bổ sung sau

- Thực hành 2 (Lập trình hướng đối tượng): chưa cài đặt, chỉ mới để sẵn mục
  "2" trong menu chính báo "chưa cài đặt". Sẽ làm ở lượt sau theo yêu cầu của bạn.
- File báo cáo (.docx) có trang bìa (họ tên, mã SV), nội dung, kết quả, giải thích
  bài làm mà đề Classroom yêu cầu — README này là nhật ký kỹ thuật, chưa phải
  báo cáo nộp bài chính thức; nếu cần file Word riêng thì nói mình làm thêm.
- Điền mã số sinh viên vào đầu file này và vào trang bìa báo cáo trước khi nộp
  (`Lab02_HoTen_MaSV.zip` theo đúng quy định đề bài).
