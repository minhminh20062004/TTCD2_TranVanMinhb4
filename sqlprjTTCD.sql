create database K22CNT2_TVM_cuahangsach
go
use K22CNT2_TVM_cuahangsach
go
CREATE TABLE QUAN_TRI (
    Tai_khoan VARCHAR(50) NOT NULL PRIMARY KEY,
    Mat_khau VARCHAR(32) NOT NULL,
    Trang_thai TINYINT ,
);

CREATE TABLE KHACH_HANG (
    MaKH INT PRIMARY KEY IDENTITY,
    Ho_ten NVARCHAR(100),
    Tai_khoan VARCHAR(50) NOT NULL UNIQUE,
    Mat_khau VARCHAR(32) NOT NULL,
    Dia_chi NVARCHAR(200),
    Dien_thoai VARCHAR(30),
    Email VARCHAR(50) NOT NULL,
    Ngay_sinh DATETIME,
    Gioi_tinh Tinyint not null, 
	Trang_thai TINYINT DEFAULT 1,
	
);

CREATE TABLE SAN_PHAM (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) ,
    Image NVARCHAR(255),
    Price float,
    Quantity INT ,
    Status tinyint,
);

CREATE TABLE DON_HANG (
    ID INT  PRIMARY KEY IDENTITY,
    MaDH VARCHAR(50),
    MaKH INT NOT NULL,
	Ten_Nguoi_Nhan NVARCHAR(100),
	Dia_Chi_Nhan NVARCHAR(255),
	Dien_Thoai_Nhan VARCHAR(50),
    Ngay_dat DATETIME ,
    Tong_tien DECIMAL(10,2),
    Trang_thai TINYINT ,
    FOREIGN KEY (MaKH) REFERENCES KHACH_HANG(MaKH) ON DELETE CASCADE
);

CREATE TABLE CHI_TIET_DON_HANG (
    ID INT  PRIMARY KEY IDENTITY,
    ID_DH INT NOT NULL,
    ID_SP INT NOT NULL,
    So_luong INT NOT NULL,
    Don_Gia float,
    
);