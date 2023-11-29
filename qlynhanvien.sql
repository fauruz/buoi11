CREATE DATABASE QL_THUVIEN
GO

USE QL_THUVIEN
GO

CREATE TABLE NHANVIEN(
	MANV VARCHAR(50) PRIMARY KEY,
	HOTENNV NVARCHAR(50),
	NGAYSINH DATE,
	GIOITINH NVARCHAR(50)
)
SET DATEFORMAT DMY
INSERT INTO NHANVIEN 
VALUES	(N'NV01', N'Nguyễn Vũ Quang', '16/05/2002', N'Nam'),
		(N'NV02', N'Nguyễn Khánh Tâm', '16/10/2002', N'Nữ'),
		(N'NV03', N'Vỏ Thành Nam', '30/06/2001', N'Nam'),
		(N'NV04', N'Đỗ Thị Mai', '12/03/1992', N'Nữ'),
		(N'NV05', N'Huỳnh Kim Châu', '12/03/1992', N'Nữ'),
		(N'NV06', N'Ngô Thanh Sương', '12/03/1992', N'Nam'),
		(N'NV07', N'Phan Văn Hùng', '10/12/1991', N'Nam'),
		(N'NV08', N'Phùng Văn Hoài', '10/12/1990', N'Nam')