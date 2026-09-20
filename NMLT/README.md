# Nhập môn lập trình C#

## Nhật ký học tập

| Ngày | Nội dung đã làm |
|---|---|
| 13/09/2026 | Khởi tạo repository và README ban đầu. |
| 16/09/2026 | Đổi tên project/repository thành `Nhapmon_C-`. |
| 18/09/2026 | Hoàn thiện và sắp xếp các bài Buổi 1-4; đổi tên file theo nội dung bài; thiết lập project .NET 8 và cập nhật `Program.cs`. |
| 18/09/2026 | Tinh gọn `Program.cs` và cập nhật các file build sau khi chạy project. |
| 19/09/2026 | Hoàn thiện các bài Buổi 5-12, bổ sung nhiều bài về vòng lặp, số học, hàm, mảng một chiều và mảng hai chiều; mở rộng `Program.cs` để chạy bài. |

## Phương pháp luận chung

Quy trình giải mỗi bài được thống nhất như sau:

1. Đọc đề, xác định dữ liệu vào, dữ liệu ra và các trường hợp biên.
2. Viết công thức hoặc thuật toán trên giấy trước khi code.
3. Chọn cấu trúc điều khiển phù hợp: `if/switch` cho phân loại, `for/while` cho lặp, hàm cho phần dùng lại, mảng cho dữ liệu nhiều phần tử.
4. Tách các bước nhập, xử lý và xuất để dễ kiểm tra.
5. Thử với dữ liệu thông thường, giá trị biên và trường hợp đặc biệt như số 0, năm nhuận, mảng rỗng hoặc nhiều phần tử bằng nhau.

## Nội dung theo buổi

### Buổi 1 - Nhập xuất và công thức cơ bản

- [In chuỗi](Buoi1/baimau%28in%20chuoi%29.cs): dùng `Console.WriteLine` để xuất chuỗi ra màn hình.
- [Biểu thức tính toán](Buoi1/baimau%28bieuthuctinhtoan%29.cs): thực hành cộng, trừ, nhân, chia nguyên, chia thực và chia lấy dư.
- [Diện tích tam giác](Buoi1/DienTichTamGiac.cs): dùng công thức Heron, trước hết tính nửa chu vi rồi suy ra diện tích.
- [Hình tròn](Buoi1/HinhTron.cs): áp dụng công thức chu vi và diện tích theo bán kính.
- [Đổi sang giây](Buoi1/DoiSangGiay.cs): quy đổi giờ và phút về giây bằng phép nhân rồi cộng dồn.
- [In nhãn](Buoi1/InNhan.cs): luyện xuất nhiều dòng và tạo khung bằng ký tự.

**Trọng tâm:** kiểu dữ liệu, phép toán, nhập xuất cơ bản và cách chuyển đề bài thành công thức.

### Buổi 2 - Biến đổi biểu thức và tính nhanh

- [Biểu thức nhanh](Buoi2/BieuThucNhanh.cs): biến đổi biểu thức về dạng Horner để giảm số phép nhân.
- [Tổng số nguyên đầu](Buoi2/baimau%28tongsonguyendau%29.cs): dùng công thức `1 + 2 + ... + n = n(n + 1) / 2` thay cho vòng lặp.
- [Lũy thừa nhanh](Buoi2/LuyThuaNhanh.cs): tính các lũy thừa trung gian bằng cách bình phương liên tiếp.
- [Tổng đoạn](Buoi2/TongDoan.cs): dùng tổng tiền tố và hiệu hai tổng để tính nhanh tổng trên đoạn `[a,b]`.

**Trọng tâm:** biến đổi công thức trước khi lập trình và giảm số phép tính không cần thiết.

### Buổi 3 - Rẽ nhánh và bài toán số học

- [Giá trị lớn nhất, nhỏ nhất của 5 số](Buoi3/MaxMin5So.cs): duyệt từng giá trị và cập nhật cực đại, cực tiểu bằng so sánh.
- [Giá trị hàm số 1](Buoi3/GiaTriHamSo1.cs): xác định khoảng của `x`, sau đó chọn biểu thức bằng `if/else`.
- [Giá trị hàm số 2](Buoi3/GiaTriHamSo2.cs): xử lý nhiều khoảng giá trị theo thứ tự điều kiện.
- [Đọc ký số](Buoi3/DocKySo.cs): tách chữ số bằng chia nguyên và chia dư, rồi ánh xạ chữ số sang chữ bằng `switch`.
- [Chữ số lớn nhất](Buoi3/ChuSoLonNhat.cs): tách các chữ số và so sánh tuần tự để tìm giá trị lớn nhất.
- [Phương trình bậc hai](Buoi3/PhuongTrinhBac2.cs): xét trường hợp suy biến, sau đó biện luận theo delta `b^2 - 4ac`.
- [Tháng tiếng Anh](Buoi3/ThangTiengAnh.cs): ánh xạ số tháng sang tên tiếng Anh bằng `switch`.
- [Thứ tự ngày trong năm](Buoi3/ThuTuNgayNam.cs): kiểm tra năm nhuận và cộng số ngày của các tháng trước đó.
- [Phương trình trùng phương](Buoi3/PhuongTrinhTrungPhuong.cs): đặt `t = x^2`, giải phương trình bậc hai theo `t`, rồi suy ra nghiệm `x`.

**Trọng tâm:** rẽ nhánh nhiều trường hợp, xử lý dữ liệu không hợp lệ và biện luận nghiệm.

### Buổi 4 - Hàm từng đoạn, ngày tháng và vòng lặp

- [Tính chất số 1](Buoi4/TinhChatSo1.cs): dùng `while` để đếm chữ số, tính tổng và lấy chữ số đầu/cuối.
- [Tính chất số](Buoi4/TinhChatSo.cs): chuyển số thành chuỗi để kiểm tra đối xứng và các chữ số trùng/lạ.
- [Tiền nước](Buoi4/TienNuoc.cs): tính tiền theo biểu giá lũy tiến, xử lý lần lượt từng bậc bằng `if/else`.
- [Phương trình bậc ba](Buoi4/PhuongTrinhBac3.cs): chuẩn hóa phương trình và biện luận nghiệm theo biệt thức của công thức Cardano.
- [Phân loại tam giác](Buoi4/PhanLoaiTamGiac.cs): kiểm tra bất đẳng thức tam giác, rồi phân loại đều, cân hoặc thường.
- [Ngày sau](Buoi4/NgaySau.cs): tăng ngày, xử lý ngày cuối tháng và chuyển sang tháng/năm mới.
- [Kiểm tra ngày hợp lệ](Buoi4/KiemTraNgayHopLe.cs): lấy số ngày của tháng bằng `switch`, có xét năm nhuận.
- [Hệ phương trình](Buoi4/HePhuongTrinh.cs): dùng quy tắc Cramer và định thức để phân biệt vô nghiệm, duy nhất nghiệm hoặc vô số nghiệm.
- [Giá trị hàm số đồ thị](Buoi4/GiaTriHamSoDoThi.cs): chọn công thức theo các mốc của hàm từng đoạn.
- [Điểm trung bình](Buoi4/DiemTrungBinh.cs): dùng vòng `for` cộng điểm rồi chia cho số lượng.

**Trọng tâm:** gom xử lý lặp lại thành điều kiện rõ ràng và bao quát các trường hợp biên của ngày tháng.

### Buổi 5 - Vòng lặp và chương trình menu

- [Giai thừa](Buoi5/GiaiThua.cs): nhân tích lũy các số từ `1` đến `n`.
- [Thực đơn](Buoi5/ThucDon.cs): tạo menu lặp bằng `do/while`, chọn chức năng bằng `switch` và cho phép thoát.
- [Giá trị biểu thức](Buoi5/GiaTriBieuThuc.cs): tính tổng điều hòa và tổng xen kẽ bằng vòng lặp.
- [Tìm bé nhất thỏa điều kiện](Buoi5/TimBeNhatThoa.cs): tăng dần `n` đến khi tổng `1 + 1/2 + ... + 1/n` vượt ngưỡng.

**Trọng tâm:** chọn đúng loại vòng lặp, điều kiện dừng và tránh lặp vô hạn.

### Buổi 6 - Chữ số, thừa số nguyên tố và số hoàn hảo

- [Xử lý chữ số](Buoi6/XuLyChuSo1.cs): duyệt các chữ số để lấy vị trí `k`, tổng chữ số lẻ và min/max chữ số lẻ.
- [Phân tích thừa số](Buoi6/PhanTichThuaSo1.cs): thử các ước từ 2, chia lặp để xác định thừa số nguyên tố và số mũ.
- [Liệt kê số hoàn hảo](Buoi6/LietKeSoHoanHao.cs): duyệt một đoạn số, cộng các ước thực sự rồi kiểm tra tổng.
- [Kiểm tra số hoàn hảo](Buoi6/KiemTraSoHoanHao.cs): tính tổng các ước nhỏ hơn số đã cho và so sánh với chính số đó.

**Trọng tâm:** tách chữ số bằng `% 10` và `/ 10`, đồng thời hiểu quan hệ giữa ước số và số nguyên tố.

### Buổi 7 - Hàm, xấp xỉ và vòng lặp lồng nhau

- [Tính số Pi](Buoi7/TinhSoPi.cs): dùng chuỗi Gregory-Leibniz và dừng khi sai số đạt yêu cầu.
- [Ngày trước](Buoi7/NgayTruoc.cs): dùng hàm kiểm tra năm nhuận/số ngày tháng, sau đó giảm một ngày.
- [Kiểm tra số hoàn hảo](Buoi7/KiemTraSoHoanHao.cs): tách hàm tính tổng ước và hàm kiểm tra để tái sử dụng.
- [In hình tam giác và vuông](Buoi7/InHinhTamGiacVaVuong.cs): dùng vòng lặp lồng nhau để in khoảng trắng và dấu `*` theo từng dòng.

**Trọng tâm:** thiết kế hàm nhỏ, có nhiệm vụ rõ ràng; dùng sai số và vòng lặp lồng nhau đúng cách.

### Buổi 8 - Hàm số học và phân số

- [Rút gọn phân số](Buoi8/RutGonPhanSo.cs): tìm ước chung lớn nhất bằng thuật toán Euclid rồi chia cả tử và mẫu.
- [Liệt kê số hoàn hảo](Buoi8/LietKeSoHoanHao.cs): tái sử dụng hàm tính tổng ước và hàm kiểm tra.
- [Giai thừa](Buoi8/GiaiThua.cs): định nghĩa hàm giai thừa và áp dụng vào công thức tổ hợp `C(n,k)`.
- [Đếm chữ số](Buoi8/DemChuSo.cs): tách từng chữ số và dùng mảng đếm cho các chữ số từ 0 đến 9.

**Trọng tâm:** đóng gói logic thành hàm và sử dụng lại thay vì viết trùng thuật toán.

### Buổi 9 - Mảng một chiều và tìm kiếm

- [Nhập xuất mảng](Buoi9/NhapXuatMang.cs): viết hàm dùng chung để nhập và in mảng số nguyên/số thực.
- [Tìm kiếm](Buoi9/TimKiem.cs): duyệt tuyến tính, đếm số lần xuất hiện và lưu vị trí đầu/cuối.
- [Tìm kiếm giá trị chẵn](Buoi9/TimKiemGiaTriChan.cs): duyệt mảng để tìm phần tử chẵn đầu tiên và cuối cùng.
- [Liệt kê chẵn](Buoi9/LietKeChan.cs): duyệt từ cuối về đầu và in các phần tử chẵn.
- [Đếm dấu](Buoi9/DemDau.cs): phân loại từng phần tử thành dương, âm hoặc bằng không.

**Trọng tâm:** chuẩn hóa thao tác nhập/xuất bằng hàm và kiểm soát chỉ số mảng.

### Buổi 10 - Quan hệ giữa các phần tử kề nhau

- [Trung bình cộng cực trị](Buoi10/TrungBinhCongCucTri.cs): so sánh phần tử với hai phần tử lân cận để nhận diện cực trị rồi cộng tổng.
- [Kề nhau trái dấu](Buoi10/KeNhauTraiDau.cs): kiểm tra tích của hai phần tử liên tiếp có âm hay không.
- [Dãy đan dấu](Buoi10/DayDanDau.cs): dùng cờ Boolean để xác nhận mọi cặp liên tiếp đều trái dấu.
- [Đoạn dương dài nhất](Buoi10/DoanDuongDaiNhat.cs): quét mảng, đếm đoạn dương liên tiếp và lưu đoạn dài nhất.

**Trọng tâm:** duyệt một lần, giữ trạng thái của phần tử trước và xử lý đúng phần tử đầu/cuối.

### Buổi 11 - Biến đổi và sắp xếp mảng

- [Xóa chẵn](Buoi11/XoaChan.cs): đếm trước số phần tử lẻ, tạo mảng mới rồi chép các phần tử lẻ.
- [Trộn dãy](Buoi11/TronDay.cs): trộn hai mảng đã tăng dần bằng hai con trỏ.
- [Sắp chẵn lẻ](Buoi11/SapChanLe.cs): tách chẵn/lẻ, sắp chẵn tăng và lẻ giảm bằng Bubble Sort, rồi ghép lại.
- [Đảo dãy](Buoi11/DaoDay.cs): đổi chỗ đối xứng từ hai đầu mảng bằng hai chỉ số.

**Trọng tâm:** quản lý chỉ số, tạo mảng kết quả và bảo toàn thứ tự khi trộn.

### Buổi 12 - Mảng hai chiều

- [Nhập xuất mảng hai chiều](Buoi12/NhapXuatMang2C.cs): dùng hai vòng lặp để nhập và in từng dòng, từng cột.
- [Tổng chẵn lẻ mảng hai chiều](Buoi12/TongChanLeMang2C.cs): duyệt toàn bộ ma trận và cộng riêng số chẵn, số lẻ.
- [Ma trận toàn lẻ](Buoi12/MaTranToanLe.cs): kiểm tra từng phần tử và dừng sớm khi gặp phần tử chẵn.
- [Dòng tăng dần](Buoi12/DongTangDan.cs): kiểm tra các cặp phần tử liên tiếp trong từng dòng.
- [Cột tổng lớn nhất](Buoi12/CotTongLonNhat.cs): tính tổng từng cột, tìm tổng lớn nhất và liệt kê các cột cùng đạt kết quả.

**Trọng tâm:** phân biệt chỉ số dòng/cột, duyệt ma trận bằng vòng lặp lồng nhau và xử lý nhiều kết quả cùng cực trị.

## Cấu trúc project

```text
NMLT/
	Buoi1/ ... Buoi12/   Các bài tập theo buổi
Program.cs             Chương trình chạy/chọn bài
Nhapmon_C-.csproj      Project .NET 8
```

## Cách chạy

Yêu cầu .NET SDK 8.0 trở lên. Từ thư mục gốc project, chạy:

```bash
dotnet run
```

Khi muốn kiểm tra biên dịch mà không chạy chương trình:

```bash
dotnet build
```
