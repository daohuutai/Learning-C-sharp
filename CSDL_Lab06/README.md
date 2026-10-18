# Lab06 - Tuong tac CSDL (SQL Server + ADO.NET)

## Cach chay
1. Mo SQL Server Management Studio, chay lan luot `SQL/01_QLSinhVien.sql` va `SQL/02_QLCuaHang.sql`.
2. Mo `Lab06/Lab06.csproj` bang Visual Studio 2019/2022 (can workload ".NET desktop development").
3. Sua thong tin ket noi trong `Lab06/Db.cs` (Server, UseSqlAuth/User/Password) cho dung may cua ban.
4. Nhan F5 -> form menu cho phep mo tung bai.

## Cau truc code
| File | Noi dung |
|---|---|
| `Db.cs` | Ket noi SqlConnection + ham ExecuteNonQuery / ExecuteScalar / SqlDataReader dung chung |
| `UI.cs` | Ham tao control, kiem tra rang buoc giao dien (khong de rong, dinh dang ngay, diem) |
| `Bai6a.cs` | 6a: Khoa (mau), MonHoc, SinhVien, Diem, Lop |
| `Bai6b.cs` | 6b: Khoa (mau), Lop (mau), SinhVien, Diem, ListView Lop, ListView Diem |
| `CuaHang.cs` | 6b ve nha: QLCuaHang (menu, ton kho, them SP, ban hang) |
| `FrmMain.cs` | Form menu mo cac bai |
