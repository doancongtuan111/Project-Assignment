Create database QLBH2
use QLBH2

create table tbl_KhachHang (
							MAKH int identity not null primary key,
							TENKH nvarchar(100) not null,
							GIOITINH bit null,
							DIACHI nvarchar(200) not null,
							SDT char(12) not null,
							EMAIL varchar(100) not null,
							HideKH bit default 'false')
							
		
create table tbl_LoaiSanPham(
							MALOAI int identity not null primary key,
							TENLOAI nvarchar(100) not null,
							MOTALOAI nvarchar(200) null,
							HideLSP bit default 'false')
							
create table tbl_SanPham (
							MASANPHAM int identity not null primary key,
							TENSANPHAM nvarchar(100) not null,
							LOAISANPHAM int not null, ---Khóa ngoại của loại sp---
							DONGIA int not null,
							MOTA nvarchar(200) null,
							HideSP bit default 'false',
							Constraint SanPham_Loai Foreign key (LOAISANPHAM) References tbl_LoaiSanPham(MALOAI)
							)

create table tbl_NhanVien (
							MANV int identity not null primary key,
							TENNV nvarchar(50) not null,
							GIOITINH bit not null,
							NAMSINH date not null,
							EMAIL nchar(50) not null,
							PASSWORDS nchar(20) not null,
							HideHD bit default 'false',
							)							
							
							
create table tbl_HoaDon (
							MAHD int identity not null primary key,
							MAKH int not null, ---Khóa ngoại của Khách hàng---
							MANV int not null,
							NGAYLAP date not null,
							MOTA nvarchar(200)null,
							HideHD bit default 'false',
							Constraint HD_KH Foreign key (MAKH) References tbl_KhachHang(MAKH),
							Constraint HD_NV Foreign key (MANV) References tbl_NhanVien(MANV)
							)
							
create table tbl_CTHD (
							MACTHD int identity not null primary key,
							MAHDON int not null,  ---Khóa ngoại của Hóa đơn---
							MASANPHAMM int not null,  ---Khóa ngoại của SanPham---
							SOLUONG int not null,
							DONGIAs int not null,
							HideCTHD bit default 'false',
							Constraint HD_CTHD Foreign key (MAHDON) References tbl_HoaDon(MAHD),
							Constraint SP_CTHD Foreign key (MASANPHAMM) References tbl_SanPham(MASANPHAM)
							)


							