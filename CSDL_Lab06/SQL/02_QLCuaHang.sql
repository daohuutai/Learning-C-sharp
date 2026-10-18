-- =====================================================================
-- CSDL QLCuaHang (dung cho Thuc hanh 06b - Bai tap ve nha)
-- =====================================================================
IF DB_ID('QLCuaHang') IS NOT NULL
BEGIN
    ALTER DATABASE QLCuaHang SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLCuaHang;
END
GO
CREATE DATABASE QLCuaHang;
GO
USE QLCuaHang;
GO

CREATE TABLE SANPHAM (
    MaSP  INT IDENTITY(1,1) PRIMARY KEY,          -- tu dong tang
    TenSP NVARCHAR(100) NOT NULL
);

CREATE TABLE TONKHO (
    MaSP    INT  NOT NULL REFERENCES SANPHAM(MaSP),
    NgayTon DATE NOT NULL,
    SLDau   INT  NOT NULL DEFAULT 0,
    SLNhap  INT  NOT NULL DEFAULT 0,
    SLBan   INT  NOT NULL DEFAULT 0,
    PRIMARY KEY (MaSP, NgayTon)
);

CREATE TABLE HOADON (
    MaHD  INT IDENTITY(1,1) PRIMARY KEY,          -- tu dong tang
    NgayTao DATE NOT NULL,
    TinhTrangThanhToan BIT NOT NULL DEFAULT 0     -- 0: chua thanh toan, 1: da thanh toan
);

CREATE TABLE CHITIET_HOADON (
    MaHD    INT NOT NULL REFERENCES HOADON(MaHD),
    MaSP    INT NOT NULL REFERENCES SANPHAM(MaSP),
    SoLuong INT NOT NULL,
    PRIMARY KEY (MaHD, MaSP)
);
GO

-- Du lieu mau (SLDau/SLNhap tuy chon; dung chuc nang "Tao ton kho" cua chuong trinh de tao ton kho tung ngay)
INSERT INTO SANPHAM(TenSP) VALUES (N'Bút bi'), (N'Tập 200 trang'), (N'Thước kẻ'), (N'Gôm tẩy'), (N'Bìa hồ sơ');

-- Ton kho cua ngay hom qua de thu chuc nang "Tao ton kho" (SLDau = SLDau + SLNhap - SLBan cua hom qua)
INSERT INTO TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan)
SELECT MaSP, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), 50, 20, 10 FROM SANPHAM;
GO
