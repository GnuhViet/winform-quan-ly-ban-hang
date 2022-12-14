USE [QLBanGiay]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TinhTongTienTheoNhanVien]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_TinhTongTienTheoNhanVien](@HoTenNV nvarchar(255))
    returns money as
begin
    declare @TongTien money, @MaNV int
    select @MaNV = MaNV from NhanVien where HoTenNV = @HoTenNV
    select @TongTien = SUM(TongTien) from HoaDonBan where MaNV = @MaNV
    return @TongTien
end
GO
/****** Object:  Table [dbo].[ChiTietSP]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSP](
	[MaCTSP] [int] IDENTITY(1,1) NOT NULL,
	[MaS] [int] NOT NULL,
	[MaMS] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietSP] PRIMARY KEY CLUSTERED 
(
	[MaS] ASC,
	[MaMS] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHDB]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDB](
	[MaCTHDB] [int] IDENTITY(1,1) NOT NULL,
	[MaHDB] [int] NOT NULL,
	[MaCTSP] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [money] NULL,
	[DonGiaBan] [money] NULL,
 CONSTRAINT [PK_ChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaCTSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSac]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MauSac](
	[MaMS] [int] IDENTITY(1,1) NOT NULL,
	[TenMS] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_MauSac] PRIMARY KEY CLUSTERED 
(
	[MaMS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[MaS] [int] IDENTITY(1,1) NOT NULL,
	[TenS] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[MaS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTL] [int] IDENTITY(1,1) NOT NULL,
	[TenTL] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatLieu]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatLieu](
	[MaCL] [int] IDENTITY(1,1) NOT NULL,
	[TenCL] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ChatLieu] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuocGia]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuocGia](
	[MaQG] [int] IDENTITY(1,1) NOT NULL,
	[TenQG] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_QuocGia] PRIMARY KEY CLUSTERED 
(
	[MaQG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](255) NOT NULL,
	[DonGiaBan] [money] NOT NULL,
	[DonGiaNhap] [money] NOT NULL,
	[GioiTinh] [nvarchar](255) NOT NULL,
	[Anh] [nvarchar](255) NOT NULL,
	[MaTL] [int] NOT NULL,
	[MaCL] [int] NOT NULL,
	[MaQG] [int] NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[MaHDB] [int] IDENTITY(1,1) NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[TongTien] [money] NULL,
	[MaKH] [int] NULL,
	[MaNV] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SanPhamTonKho]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[SanPhamTonKho]
as
select SanPham.MaSP as [Mã],
       TenSP        as [Tên Sản Phẩm],
       DonGiaBan    as [Giá Bán],
       DonGiaNhap   as [Giá Nhập],
       GioiTinh     as [Giới Tính],
       TL.TenTL     as [Thể Loại],
       CL.TenCL     as [Chất Liệu],
       QG.TenQG     as [Quốc Gia],
       S.TenS       as [Size],
       MS.TenMS     as [Màu Sắc],
       SoLuong      as [Số Lượng]
from SanPham
         join TheLoai TL on TL.MaTL = SanPham.MaTL
         join ChatLieu CL on SanPham.MaCL = CL.MaCL
         join QuocGia QG on SanPham.MaQG = QG.MaQG
         join ChiTietSP C on SanPham.MaSP = C.MaSP
         join Size S on C.MaS = S.MaS
         join MauSac MS on C.MaMS = MS.MaMS
where SanPham.MaSP not in
      (select distinct SanPham.MaSP
       from SanPham
                join ChiTietSP CTS on SanPham.MaSP = CTS.MaSP
                join ChiTietHDB CTH on CTS.MaCTSP = CTH.MaCTSP
                join HoaDonBan HDB on CTH.MaHDB = HDB.MaHDB
       where YEAR(HDB.NgayBan) = YEAR(getdate())
         and MONTH(HDB.NgayBan) = MONTH(getdate()))
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[SoDT] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTenNV] [nvarchar](255) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[SoDT] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[MaCV] [int] NOT NULL,
	[GioiTinh] [nvarchar](255) NOT NULL,
	[TinhTrang] [nvarchar](255) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[MaHDN] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[MaSoThue] [nvarchar](255) NOT NULL,
	[TongTien] [money] NULL,
	[MaNCC] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_BaoCaoHoaDonNhapTheoQuyVaNam]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_BaoCaoHoaDonNhapTheoQuyVaNam](@monthStart int, @monthEnd int, @nam int)
    returns table
        as return
            (
                select MaHDN as [Mã],
                       NgayNhap as [Ngày Nhập],
                       MaSoThue as [Mã Số Thuế],
                       TenNCC as [Tên Nhà Cung Cấp],
                       HoTenNV as [Họ Tên Nhân Viên],
                       TongTien as [Tổng Tiền]
                from HoaDonNhap h
                         join NhaCungCap n1 on h.MaNCC = n1.MaNCC
                         join NhanVien n2 on h.MaNV = n2.MaNV
                where month(NgayNhap) between @monthStart and @monthEnd
                  and year(NgayNhap) = @nam
            )
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTenKH] [nvarchar](255) NOT NULL,
	[SoDT] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Top3KhachHang]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_Top3KhachHang](@monthStart int, @monthEnd int, @nam int)
    returns table as return
            (
                select top 3 with ties k.MaKH as [Mã],
                                       HoTenKH as [Họ Tên],
                                       SoDT [Số Điện Thoại],
                                       sum(TongTien) [Tổng Tiền Đã Tiêu]
                from KhachHang k
                         join HoaDonBan h on k.MaKH = h.MaKH
                where month(NgayBan) between @monthStart and @monthEnd
                  and year(NgayBan) = @nam
                group by k.MaKH, HoTenKH, SoDT
                order by [Tổng Tiền Đã Tiêu] DESC
            )
GO
/****** Object:  UserDefinedFunction [dbo].[fn_DanhSachHoaDonTheoNhanVien]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_DanhSachHoaDonTheoNhanVien](@HoTenNV nvarchar(255))
    returns table
        as
        return
            (
                select HoaDonBan.MaHDB, HoaDonBan.NgayBan, TongTien, HoTenNV, HoTenKH
                from HoaDonBan
                join NhanVien NV on HoaDonBan.MaNV = NV.MaNV
                left join KhachHang KH on HoaDonBan.MaKH = KH.MaKH
                where HoTenNV like concat(@HoTenNV, '%')
            )
GO
/****** Object:  Table [dbo].[ChiTietHDN]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDN](
	[MaCTHDN] [int] IDENTITY(1,1) NOT NULL,
	[MaHDN] [int] NOT NULL,
	[MaCTSP] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [money] NULL,
	[DonGiaNhap] [money] NOT NULL,
 CONSTRAINT [PK_ChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaCTSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 23/11/2022 8:20:33 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatLieu] ON 

INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (1, N'Da Bò')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (2, N'Vải Bò')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (3, N'Cao Su')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (4, N'Vàng')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (5, N'Kim Cương')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (8, N'Gỗ')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (9, N'Niken')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (10, N'Đồng')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (11, N'Bạc')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (12, N'Vải')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (13, N'Lụa')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (14, N'Brom')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (15, N'Sắt')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (16, N'Inox')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (17, N'Vải Mảnh')
SET IDENTITY_INSERT [dbo].[ChatLieu] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHDB] ON 

INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (13, 4, 1, 1, 27.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (12, 4, 4, 1, 44.0000, 44.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (9, 9, 1, 1, 27.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (11, 9, 4, 1, 44.0000, 44.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (10, 9, 6, 1, 27.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (14, 10, 1, 2, 54.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (17, 12, 1, 2, 54.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (18, 13, 14, 5, 500.0000, 100.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (19, 14, 18, 2, 200.0000, 100.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (20, 15, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (21, 16, 12, 1, 20.0000, 20.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (22, 17, 12, 1, 20.0000, 20.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (23, 18, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (24, 19, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (25, 20, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (26, 21, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (27, 22, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (28, 23, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (29, 24, 13, 1, 220000.0000, 220000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (30, 25, 1, 2, 270.0000, 135.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (31, 26, 1, 14, 1540000.0000, 110000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (32, 27, 6, 10, 1100000.0000, 110000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (33, 28, 10, 5, 55000.0000, 11000.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (34, 29, 24, 1, 780.0000, 780.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (35, 30, 6, 1, 11000.0000, 11000.0000)
SET IDENTITY_INSERT [dbo].[ChiTietHDB] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHDN] ON 

INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (1, 1, 12, 1, 30.0000, 30.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (2, 2, 13, 10, 2000000.0000, 200000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (3, 3, 13, 1, 200000.0000, 200000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (4, 4, 13, 3, 600000.0000, 200000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (6, 5, 1, 1, 123.0000, 123.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (5, 5, 4, 1, 1.0000, 1.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (7, 6, 1, 10, 200000.0000, 20000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (8, 7, 1, 1, 40000.0000, 40000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (9, 8, 1, 1, 188888.0000, 188888.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (10, 9, 1, 100, 10000000.0000, 100000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (11, 10, 1, 1, 10.0000, 10.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (12, 11, 21, 3, 420000.0000, 140000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (13, 12, 1, 1, 4.0000, 4.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (14, 13, 6, 20, 2000000.0000, 100000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (15, 14, 4, 1, 15000.0000, 15000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (16, 15, 6, 100, 1000000.0000, 10000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (17, 16, 10, 10, 100000.0000, 10000.0000)
INSERT [dbo].[ChiTietHDN] ([MaCTHDN], [MaHDN], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaNhap]) VALUES (18, 17, 12, 1, 40000.0000, 40000.0000)
SET IDENTITY_INSERT [dbo].[ChiTietHDN] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietSP] ON 

INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (1, 1, 1, 3, 102)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (6, 1, 2, 3, 111)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (12, 1, 2, 8, 10)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (15, 1, 2, 10, 10)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (21, 1, 2, 14, 8)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (14, 1, 3, 10, 5)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (22, 1, 3, 14, 5)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (10, 1, 4, 3, 6)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (17, 1, 4, 10, 10)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (4, 4, 4, 4, 4)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (13, 5, 7, 9, 11)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (9, 8, 5, 3, 6)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (24, 10, 2, 18, 0)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (18, 10, 4, 10, 8)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (19, 11, 3, 8, 4)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (20, 12, 4, 8, 12)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (23, 14, 4, 15, 777)
SET IDENTITY_INSERT [dbo].[ChiTietSP] OFF
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (1, N'Quản Lý')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (2, N'Giám Đốc')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (3, N'Nhân Viên')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (4, N'Lao Công')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (5, N'Bảo Vệ')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonBan] ON 

INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (4, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 71.0000, 2, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (9, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 98.0000, 3, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (10, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 54.0000, NULL, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (12, CAST(N'2022-10-23T00:00:00.000' AS DateTime), 54.0000, NULL, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (13, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 500.0000, 4, 3)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (14, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 200.0000, 5, 3)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (15, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 2, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (16, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 20.0000, 3, 3)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (17, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 20.0000, 4, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (18, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (19, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (20, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (21, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (22, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (23, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (24, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 220000.0000, 3, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (25, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 270.0000, 2, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (26, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 1540000.0000, NULL, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (27, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 1100000.0000, NULL, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (28, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 55000.0000, NULL, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (29, CAST(N'2022-11-23T00:00:00.000' AS DateTime), 780.0000, NULL, 4)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (30, CAST(N'2022-08-06T00:00:00.000' AS DateTime), 11000.0000, 7, 1)
SET IDENTITY_INSERT [dbo].[HoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonNhap] ON 

INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (1, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'123', 30.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (2, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'01239', 2000000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (3, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'123', 200000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (4, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'123', 600000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (5, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'3131', 124.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (6, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'777', 200000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (7, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'999', 40000.0000, 4, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (8, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'786987', 188888.0000, 2, 3)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (9, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'123', 10000000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (10, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'124', 10.0000, 4, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (11, CAST(N'2022-08-01T00:00:00.000' AS DateTime), N'123', 420000.0000, 4, 2)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (12, CAST(N'2022-08-01T00:00:00.000' AS DateTime), N'444', 4.0000, 4, 5)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (13, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'10000', 2000000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (14, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'777', 15000.0000, 2, 2)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (15, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'1000', 1000000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (16, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'1000', 100000.0000, 1, 1)
INSERT [dbo].[HoaDonNhap] ([MaHDN], [NgayNhap], [MaSoThue], [TongTien], [MaNCC], [MaNV]) VALUES (17, CAST(N'2022-11-23T00:00:00.000' AS DateTime), N'0980', 40000.0000, 1, 1)
SET IDENTITY_INSERT [dbo].[HoaDonNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (2, N'Pham Quang', N'012394124')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (3, N'Daxua', N'012394124')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (4, N'Nhat Anh', N'054988123')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (5, N'Hoang Lam', N'012317292')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (7, N'Trần Lập', N'012349912')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[MauSac] ON 

INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (1, N'Đỏ')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (2, N'Cam')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (3, N'Vàng')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (4, N'Lục')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (5, N'Hồng')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (6, N'Trắng')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (7, N'Đen')
INSERT [dbo].[MauSac] ([MaMS], [TenMS]) VALUES (8, N'Xanh Biển')
SET IDENTITY_INSERT [dbo].[MauSac] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDT], [Email]) VALUES (1, N'Cung Cấp 1', N'Hà Nội Việt Nam', N'012312312', N'cungcap1@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDT], [Email]) VALUES (2, N'Cung Cấp 2', N'Đống Đa', N'01233123', N'cungcap2@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDT], [Email]) VALUES (4, N'Cung Cấp 4', N'Cầu Giấy', N'033344445', N'test@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDT], [Email]) VALUES (5, N'Cung Cấp 5', N'Ba Đình', N'563345635', N'test@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDT], [Email]) VALUES (6, N'Cung Cấp 6', N'Ba Đình', N'12341324', N'test@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDT], [Email]) VALUES (7, N'Cung Cấp 7', N'Thanh Xuân', N'13412344', N'test@gmail.com')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (1, N'Blue Dante', CAST(N'2003-11-15T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nam', N'Đang Làm')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (2, N'Dante', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'039412312', N'Hà Giang', 2, N'Nữ', N'Thôi Việc')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (3, N'Giang', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nam', N'Đang Làm')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (4, N'Hoàng', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nữ', N'Đang Làm')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (5, N'Lâm', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nữ', N'Đang Làm')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (6, N'Tuấn', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nam', N'Đang Làm')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (7, N'Lực', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nữ', N'Đang Làm')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[QuocGia] ON 

INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (1, N'Việt Nam')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (2, N'Nhật Bản')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (3, N'Hàn Quốc')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (5, N'Mỹ')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (6, N'Đức')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (7, N'Canada')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (8, N'Malaysia')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (9, N'Singapore')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (10, N'Thái Lan')
SET IDENTITY_INSERT [dbo].[QuocGia] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (3, N'Giày Bata', 11000.0000, 10000.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 3, 2, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (4, N'Dép bitis', 16500.0000, 15000.0000, N'Nữ', N'C:\Users\nvh20\Pictures\BTL\a5b77dc1ff89af84f75a570333dc5485.jpg', 2, 4, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (8, N'Dép Tổ Ong', 44000.0000, 40000.0000, N'Nam', N'D:\meme\284496561_3190142404632817_36637318327881917_n.jpg', 1, 5, 2)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (9, N'Converse Chuck Taylor', 220000.0000, 200000.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\29e8ff98424bd16da4b7097849a70529.jpg', 5, 1, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (10, N'Giày Cao Su', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (11, N'Giày Cao A', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (12, N'Giày Cao B', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (13, N'Giày Thấp C', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (14, N'Giày  Cao Gót', 154000.0000, 140000.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (15, N'Giày Thấp ', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 3, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (16, N'Giày Tròn', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 2, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (17, N'Giày Tròn Size', 100.0000, 20.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 2, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (18, N'Cao Gót', 780.0000, 667.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 4, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (19, N'Cao Gót Z', 780.0000, 667.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 4, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (20, N'Cao Gót O', 780.0000, 667.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 4, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (21, N'Giày Bitis', 800.0000, 678.0000, N'Nam', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 1, 5, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (22, N'Giày Nike', 800.0000, 678.0000, N'Nữ', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 1, 5, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (23, N'Giày Airfoce', 800.0000, 678.0000, N'Nữ', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 2, 5, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (24, N'Fila Giày', 800.0000, 678.0000, N'Nữ', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 3, 5, 3)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (25, N'Fila Giày Dép', 800.0000, 678.0000, N'Nữ', N'C:\Users\nvh20\Pictures\BTL\efcec2b3cdaa1de90303c8e59b845bdf.jpg', 3, 5, 3)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[Size] ON 

INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (1, N'25')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (2, N'26')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (3, N'27')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (4, N'28')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (5, N'29')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (6, N'30')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (7, N'31')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (8, N'32')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (10, N'33')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (11, N'34')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (12, N'35')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (13, N'36')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (14, N'37')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (15, N'38')
INSERT [dbo].[Size] ([MaS], [TenS]) VALUES (16, N'39')
SET IDENTITY_INSERT [dbo].[Size] OFF
GO
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (1, N'Dép')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (2, N'Giày Thường')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (3, N'Giày Thể Thao')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (5, N'Giày Converse')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (6, N'Golf')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (7, N'Tennis')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (8, N'Running')
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
GO
/****** Object:  Index [UQ__ChiTietH__508BFF6E52F2D36C]    Script Date: 23/11/2022 8:20:33 CH ******/
ALTER TABLE [dbo].[ChiTietHDB] ADD UNIQUE NONCLUSTERED 
(
	[MaCTHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ChiTietH__508BFF5AED03F607]    Script Date: 23/11/2022 8:20:33 CH ******/
ALTER TABLE [dbo].[ChiTietHDN] ADD UNIQUE NONCLUSTERED 
(
	[MaCTHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ChiTietS__1E4FCECC86F1914F]    Script Date: 23/11/2022 8:20:33 CH ******/
ALTER TABLE [dbo].[ChiTietSP] ADD UNIQUE NONCLUSTERED 
(
	[MaCTSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietHDB] ADD  DEFAULT ((0)) FOR [ThanhTien]
GO
ALTER TABLE [dbo].[ChiTietHDN] ADD  DEFAULT ((0)) FOR [ThanhTien]
GO
ALTER TABLE [dbo].[HoaDonBan] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT (N'Đang làm') FOR [TinhTrang]
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_ChiTietSP] FOREIGN KEY([MaCTSP])
REFERENCES [dbo].[ChiTietSP] ([MaCTSP])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_ChiTietSP]
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_HoaDonBan] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[HoaDonBan] ([MaHDB])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_HoaDonBan]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_ChiTietSP] FOREIGN KEY([MaCTSP])
REFERENCES [dbo].[ChiTietSP] ([MaCTSP])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_ChiTietSP]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_HoaDonNhap] FOREIGN KEY([MaHDN])
REFERENCES [dbo].[HoaDonNhap] ([MaHDN])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_HoaDonNhap]
GO
ALTER TABLE [dbo].[ChiTietSP]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSP_MS] FOREIGN KEY([MaMS])
REFERENCES [dbo].[MauSac] ([MaMS])
GO
ALTER TABLE [dbo].[ChiTietSP] CHECK CONSTRAINT [FK_ChiTietSP_MS]
GO
ALTER TABLE [dbo].[ChiTietSP]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSP_S] FOREIGN KEY([MaS])
REFERENCES [dbo].[Size] ([MaS])
GO
ALTER TABLE [dbo].[ChiTietSP] CHECK CONSTRAINT [FK_ChiTietSP_S]
GO
ALTER TABLE [dbo].[ChiTietSP]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSP_SP] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietSP] CHECK CONSTRAINT [FK_ChiTietSP_SP]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_MaKH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_MaKH]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_MaNCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_MaNCC]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ChatLieu] FOREIGN KEY([MaCL])
REFERENCES [dbo].[ChatLieu] ([MaCL])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ChatLieu]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_QuocGia] FOREIGN KEY([MaQG])
REFERENCES [dbo].[QuocGia] ([MaQG])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_QuocGia]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_TheLoai] FOREIGN KEY([MaTL])
REFERENCES [dbo].[TheLoai] ([MaTL])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_TheLoai]
GO
