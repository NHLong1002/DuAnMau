create database DUAN_QLBH
USE DUAN_QLBH
Go
drop table KHACHHANG
drop table HANG
drop table NHANVIEN
-- Tạo bảng
create table NHANVIEN(
	ID INT IDENTITY(1,1) NOT NULL,
	MANV VARCHAR(5) PRIMARY KEY,
	HOTEN NVARCHAR(30) NOT NULL,
	EMAIL VARCHAR(50) NOT NULL,
	VAITRO BIT NOT NULL DEFAULT 0, -- 0 LÀ NHÂN VIÊN , 1 LÀ QUẢN TRỊ VIÊN
	TINHTRANG BIT NOT NULL DEFAULT 0, -- 0 LÀ KO HOẠT ĐỘNG , 1 LÀ ĐANG HOẠT ĐỘNG
	MATKHAU VARCHAR(50) default 123
);

CREATE TABLE HANG(
	MAHANG int PRIMARY KEY identity(1,1),
	TENHANG NVARCHAR(30) NOT NULL,
	SOLUONG INT NOT NULL, -- Số lượng nhập 
	DONGIANHAP FLOAT NOT NULL,
	DONGIABAN FLOAT NOT NULL,
	HINHANH VARCHAR(20) NOT NULL,
	GHICHU NVARCHAR(255),
	MANV VARCHAR(5)NOT NULL,
	CONSTRAINT FK_HANG_NHANVIEN FOREIGN KEY (MANV)
    REFERENCES NHANVIEN(MANV)
);
create table KHACHHANG(
	DIENTHOAI VARCHAR(10) PRIMARY KEY,
	HOTEN NVARCHAR(30) NOT NULL,
	DIACHI VARCHAR(50) NOT NULL,
	PHAI BIT NOT NULL, -- 0 LÀ NAM , 1 LÀ NỮ
	MANV VARCHAR(5)NOT NULL,
	CONSTRAINT FK_KHACHHANG_NHANVIEN FOREIGN KEY (MANV)
    REFERENCES NHANVIEN(MANV)
);
SELECT * FROM NHANVIEN
SELECT * FROM KHACHHANG
SELECT * FROM HANG
-- Nhập dữ liệu
	-- bảng nhân viên
	insert into NHANVIEN values ('')

-- Tạo Procedure
	-- 1: proc Đăng nhập
create  proc sp_DangNhap @email varchar(50) , @matkhau varchar(50)
as
	declare @status int
begin
	if exists (select * from NHANVIEN where EMAIL = @email and MATKHAU = @matkhau)
	set @status = 1
	else
	set @status = 0
	select @status
end
exec sP_DangNhap 'haha', '213'

	-- 2: proc Nhập nhân viên

create proc sP_NhapNV @hoten nvarchar(30), @email varchar(50), @vaitro bit
as
	declare @maxID int;
begin
	select @maxID = max(id) from NHANVIEN
	if(@vaitro = 0)
	begin
		insert into Nhanvien(MANV,HOTEN,EMAIL,VAITRO,TINHTRANG,MATKHAU) 
		values ('NV'+ CAST((@maxID + 1) as varchar),@hoten,@email,@vaitro,default,'3244185981728979115075721453575112')
	end
	if(@vaitro = 1)
	begin
		insert into Nhanvien(MANV,HOTEN,EMAIL,VAITRO,TINHTRANG,MATKHAU) 
		values ('QT'+ CAST((@maxID + 1) as varchar),@hoten,@email,@vaitro,default,'3244185981728979115075721453575112')
	end
end

exec P_NhapNV N'Lê Quang Hữu','Huu@gmail.com',0
delete NHANVIEN where ID = 3
select * from NHANVIEN
	declare @maxID int;

	select @maxID = max(id) from NHANVIEN
	select  cast(@maxID as varchar) + 'he'

	
-- 3: proc QuenMatKhau

create proc sp_QuenMatKhau @email varchar(50)
as
	declare @status int
begin
	if exists (select * from nhanvien where email = @email)
	set @status = 1
	else
	set @status = 0;
	select @status
end
exec sp_QuenMatKhau 'Minh@gmail.com','999'
select * from NHANVIEN

-- 4: proc Danh sách nhân viên
create proc sp_DanhSachNV
as
select * from NHANVIEN

exec sp_DanhSachNV

-- 5: Danh sách hàng hóa
create proc sp_DanhSachHH
as
select * from HANG

-- 6: Danh sách thống kê

create  proc sp_thongke 
as
select TENHANG,sum(SOLUONG) as 'Số lượng'  from HANG  group by TENHANG

exec sp_thongke

-- 7: Tạo lại mật khẩu mới
create  proc sp_TaoMatKhauMoi @email varchar(50) , @matkhau varchar(50)
as
begin
	update NHANVIEN set MATKHAU = @matkhau where EMAIL = @email
end

select * from NHANVIEN

exec  sp_taomatkhaumoi 'Tuan@gmail.com' , '3244185981728979115075721453575112'