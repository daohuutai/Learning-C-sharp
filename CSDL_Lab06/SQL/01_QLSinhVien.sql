-- =====================================================================
-- CSDL QLSinhVien (dung cho Thuc hanh 06a, 06b)
-- Chay file nay trong SQL Server Management Studio truoc khi chay chuong trinh
-- =====================================================================
IF DB_ID('QLSinhVien') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVien;
END
GO
CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO

CREATE TABLE Khoa (
    MaKhoa  VARCHAR(10)   NOT NULL PRIMARY KEY,
    TenKhoa NVARCHAR(50)  NOT NULL
);

CREATE TABLE Lop (
    MaLop   VARCHAR(10)   NOT NULL PRIMARY KEY,
    TenLop  NVARCHAR(50)  NOT NULL,
    MaKhoa  VARCHAR(10)   NOT NULL REFERENCES Khoa(MaKhoa)
);

CREATE TABLE SinhVien (
    MaSinhVien VARCHAR(10)  NOT NULL PRIMARY KEY,
    HoTen      NVARCHAR(50) NOT NULL,
    NgaySinh   DATE         NOT NULL,
    MaLop      VARCHAR(10)  NOT NULL REFERENCES Lop(MaLop)
);

CREATE TABLE MonHoc (
    MaMonHoc  VARCHAR(10)  NOT NULL PRIMARY KEY,
    TenMonHoc NVARCHAR(50) NOT NULL
);

CREATE TABLE Diem (
    MaSinhVien VARCHAR(10) NOT NULL REFERENCES SinhVien(MaSinhVien),
    MaMonHoc   VARCHAR(10) NOT NULL REFERENCES MonHoc(MaMonHoc),
    Diem       FLOAT       NOT NULL,
    PRIMARY KEY (MaSinhVien, MaMonHoc)
);
GO

-- ---------------- Du lieu mau (moi bang >= 5 mau tin) ----------------
INSERT INTO Khoa VALUES ('CNTT', N'Công nghệ thông tin'), ('KT', N'Kế toán'), ('HH', N'Hóa học'),
                        ('NN', N'Ngoại ngữ'), ('QT', N'Quản trị kinh doanh');

INSERT INTO Lop VALUES
 ('05DHKT2', N'Kế toán ngân hàng khóa 05', 'KT'),
 ('05DHTH1', N'Công nghệ phần mềm khóa 05', 'CNTT'),
 ('05DHTH2', N'Lập trình mạng khóa 05', 'CNTT'),
 ('06DHHH1', N'Hóa phân tích khóa 06', 'HH'),
 ('06DHKT1', N'Thuế doanh nghiệp khóa 06', 'KT'),
 ('06DHTH1', N'Công nghệ phần mềm khóa 06', 'CNTT');

INSERT INTO SinhVien VALUES
 ('SV001', N'Trần Thanh Tùng',   '1993-10-12', '05DHTH1'),
 ('SV002', N'Nguyễn Thanh Bình', '1993-04-02', '05DHTH1'),
 ('SV003', N'Nguyễn Đạt Nhân',   '1992-03-15', '05DHTH2'),
 ('SV004', N'Nguyễn Gia Bảo',    '1993-05-11', '06DHTH1'),
 ('SV005', N'Nguyễn Thanh Lan',  '1993-06-12', '05DHKT2'),
 ('SV006', N'Lâm Văn Tuấn',      '1993-08-03', '06DHKT1');

INSERT INTO MonHoc VALUES ('1', N'Toán Cao cấp'), ('2', N'Mác - Lênin'), ('3', N'Tin học đại cương'),
                          ('4', N'Cơ sở dữ liệu'), ('5', N'Lập trình C#');

INSERT INTO Diem VALUES
 ('SV001','1',4), ('SV001','2',7),
 ('SV002','1',6), ('SV002','2',3), ('SV002','3',5),
 ('SV003','1',9), ('SV003','2',10), ('SV003','3',9),
 ('SV004','1',3), ('SV004','2',6),
 ('SV005','1',5), ('SV005','3',7),
 ('SV006','2',8), ('SV006','3',8);
GO
