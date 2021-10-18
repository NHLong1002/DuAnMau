use master
go
drop database DUAN_QLBH
go
create database DUAN_QLBH
go
USE DUAN_QLBH
Go

-- Tạo bảng
--ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = off

go
create table NHANVIEN(
	ID INT IDENTITY(1,1) NOT NULL,
	MANV VARCHAR(7) PRIMARY KEY,
	HOTEN NVARCHAR(50) NOT NULL,
	EMAIL VARCHAR(50) NOT NULL,
	DIACHI NVARCHAR(50) NOT NULL,
	VAITRO BIT NOT NULL DEFAULT 0, -- 0 LÀ NHÂN VIÊN , 1 LÀ QUẢN TRỊ VIÊN
	TINHTRANG BIT NOT NULL DEFAULT 1, -- 0 LÀ KO HOẠT ĐỘNG , 1 LÀ ĐANG HOẠT ĐỘNG
	MATKHAU VARCHAR(50) default '3244185981728979115075721453575112'
);
go

CREATE TABLE HANG(
	MAHANG int PRIMARY KEY identity(1,1),
	TENHANG NVARCHAR(30) NOT NULL,
	SOLUONG INT NOT NULL, -- Số lượng nhập 
	DONGIANHAP FLOAT NOT NULL,
	DONGIABAN FLOAT NOT NULL,
	HINHANH VARCHAR(20) NOT NULL,
	GHICHU NVARCHAR(255),
	MANV VARCHAR(7)NOT NULL,
	CONSTRAINT FK_HANG_NHANVIEN FOREIGN KEY (MANV)
    REFERENCES NHANVIEN(MANV)
);
go
create table KHACHHANG(
	DIENTHOAI VARCHAR(10) PRIMARY KEY,
	HOTEN NVARCHAR(30) NOT NULL,
	DIACHI NVARCHAR(50) NOT NULL,
	PHAI BIT NOT NULL, -- 0 LÀ NAM , 1 LÀ NỮ
	MANV VARCHAR(7)NOT NULL,
	CONSTRAINT FK_KHACHHANG_NHANVIEN FOREIGN KEY (MANV)
    REFERENCES NHANVIEN(MANV)
);

go
-- Tạo Procedure
go
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
	-- 2: proc Nhập nhân viên
go

create proc sP_NhapNV @hoten nvarchar(30), @email varchar(50),@diachi nvarchar(50), @vaitro bit
as
begin
	DECLARE @Manv VARCHAR(20);
 DECLARE 
@Id
 INT;
 SELECT @Id = ISNULL(MAX(ID),0) + 1 FROM NHANVIEN
 SELECT @Manv = 'NV' + RIGHT('0000' + CAST(@Id AS VARCHAR(4)), 4)
  INSERT INTO NHANVIEN(Manv,email,hoten, diaChi,vaiTro,tinhTrang,matkhau) 
 VALUES (@Manv, @email, @hoten, @diachi,@vaiTro,1,default) 
end

exec sP_NhapNV N'Tuấn Minh' , 'Tuan@gmail.com',N'Quận 1',1

-- 3: proc QuenMatKhau
go
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
-- 4: proc Danh sách nhân viên
go
create proc sp_DanhSachNV
as
select MANV,HOTEN,EMAIL,DIACHI,VAITRO,TINHTRANG from NHANVIEN

-- 5: Danh sách hàng hóa
go
create proc sp_DanhSachHH
as
select * from HANG

-- 6: Danh sách thống kê
go
create  proc sp_thongke 
as
select TENHANG,sum(SOLUONG) as 'Số lượng'  from HANG  group by TENHANG
-- 7: Tạo lại mật khẩu mới
go
create proc sp_TaoMatKhauMoi @email varchar(50) , @matkhaucu varchar(50) , @matkhaumoi varchar(50)
as
declare @matkhaugoc varchar(50)
select @matkhaugoc = matkhau from NHANVIEN where EMAIL = @email	
begin
	if(@matkhaugoc = @matkhaucu)
	begin
		update NHANVIEN set MATKHAU = @matkhaumoi where EMAIL = @email
		return 1
	end
	else
		return -1
end

-- 8  Check Vai trò
go

create proc sp_VaiTro @email varchar(50)
as
begin
	select vaitro from nhanvien where EMAIL = @email
end

-- 9 proc Update nhân viên
go
create proc sp_CapnhatNV @email nvarchar(50),@hoten nvarchar(30),@diachi nvarchar(50),
@vaitro bit, @tinhtrang bit
as
begin 
	update nhanvien set HOTEN =@hoten , DIACHI = @diachi , VAITRO= @vaitro,TINHTRANG = @tinhtrang
	where EMAIL = @email
end
-- 10 proc Delete nhân viên
go
create proc sp_XoaNV @emai varchar(50)
as
begin
	delete NHANVIEN where EMAIL = @emai
end
delete nhanvien where EMAIL = 'minhnhua@gmail.com'
-- 11 proc search nhân viên
go
create proc sp_timNV @tennv nvarchar(50)
as
begin
	select MANV,HOTEN,EMAIL,DIACHI,VAITRO,TINHTRANG from nhanvien where hoten like '%' + @tennv + '%'
end
-- 12 proc thêm khách hàng
go
create proc sp_ThemKH @dienthoai varchar(10) , @hoten nvarchar(50), @diachi nvarchar(50), @phai bit, @manv varchar(5)
as
begin
	insert into KHACHHANG values (@dienthoai,@hoten,@diachi,@phai,@manv)
end
-- 13 proc cập nhật khách hàng
go
create proc sp_CapnhatKH @dienthoai varchar(10) , @hoten nvarchar(50), @diachi nvarchar(50) , @phai bit
as
begin 
	update KHACHHANG set HOTEN = @hoten, DIACHI=@diachi , PHAI = @phai
	where DIENTHOAI = @dienthoai
end
-- 14 proc xóa khách hàng
go
create proc sp_XoaKH @dienthoai varchar(10)
as
begin
	delete KHACHHANG where DIENTHOAI = @dienthoai
end

-- 15 proc Danh sách khách hàng
go
create proc sp_DanhsachKH 
as
select HOTEN, DIENTHOAI,DIACHI,PHAI,MANV from KHACHHANG

-- 16 proc Nhập khách hàng
go
create proc sp_NhapKH @dienthoai varchar(10),@hoten nvarchar(30) , @diachi varchar(50) , @phai bit, @email varchar(50)
as
	declare @manv varchar(7)
	select @manv= MANV from NHANVIEN where EMAIL = @email
begin
	insert into KHACHHANG values (@dienthoai,@hoten,@diachi,@phai,@manv)
end

-- 17 proc kiểm tra nhập trùng tên
go
create proc sp_checkemail @email varchar(50)
as
begin
	select count(*) from NHANVIEN where email = @email
end

-- 18 proc tìm khách hàng
go
create proc sp_TimKh @sdt varchar(10)
as
begin
	select * from KHACHHANG where DIENTHOAI = @sdt
end
 
 -- 19 proc xuất danh sách hàng hóa
 go
 create proc sp_danhsachHangHoa
 as
 begin
	select  * from hang
 end
 -- 20 proc thêm hàng hóa
 go
 create proc sp_themHangHoa @tenhang nvarchar(30),@soluong int, @dongianhap float, @dongiaban float, @hinhanh varchar(20),@ghichu nvarchar(255), @email varchar(50)
 as
	declare @manv varchar(7)
	select @manv = MANV from NHANVIEN where EMAIL = @email
 begin
	insert into HANG values(@tenhang,@soluong,@dongianhap,@dongiaban,@hinhanh,@ghichu,@manv)
 end
 go

 -- 21 proc Sửa hàng hóa
 create   proc sp_capnhatHangHoa @tenhang nvarchar(30),@soluong int , @dongianhap float ,@dongiaban float, @hinhanh varchar(20),@ghichu nvarchar(255) , @email varchar(50), @mahang int
 as
	declare @manv varchar(7)
	select @manv = Manv from NHANVIEN where email = @email
 begin
	update hang set SOLUONG= @soluong , DONGIANHAP = @dongianhap , DONGIABAN = @dongiaban , HINHANH = @hinhanh ,  GHICHU = @ghichu , TENHANG = @tenhang , MANV = @manv
	where MAHANG = @mahang
 end
  exec sp_capnhatHangHoa 'Inox' , 123, '300' , '450','1.jpg',N'hello','Tuan@gmail.com',4
 -- 22 Xóa hàng hóa
 go
 create proc sp_xoaHangHoa @mahang int
 as
 begin
	delete HANG where MAHANG = @mahang
 end

 -- 23 Danh sách hàng hóa
 go
 create  proc sp_timHangHoa @tenhang nvarchar(30)
 as
 begin
	select  * from hang where TENHANG = @tenhang
 end
 -- 24 Thống kê kho
 go
 create proc sp_thongketonkho
 as
 begin
	select tenhang , sum(SOLUONG)from hang
	group by tenhang
 end

 -- 25 thống kê sản phẩm nhập
 go
 create  proc sp_thongkespnhap
 as
 begin
	select hang.MANV , NHANVIEN.HOTEN, HANG.TENHANG,COUNT(HANG.MAHANG) from NHANVIEN inner join HANG
	on NHANVIEN.MANV = hang.MANV
	group by hang.manv,nhanvien.hoten,TENHANG
 end
 


 select * from hang where TENHANG like '%bê%'
 select * from HANG
 select * from NHANVIEN
  exec sp_themHangHoa N'Inox Gương', 30, 500000,600000,'2.png',N'Khung thang máy','Minh@gmail.com'
 select * from HANG
 select * from NHANVIEN
 select * from KHACHHANG