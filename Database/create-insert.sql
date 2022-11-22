USE [QLBanGiay]
GO
/****** Object:  Table [dbo].[ChatLieu]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[ChiTietHDB]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[ChiTietHDN]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[ChiTietSP]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[ChucVu]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[MauSac]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[NhanVien]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[QuocGia]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[Size]    Script Date: 22/11/2022 4:36:33 CH ******/
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
/****** Object:  Table [dbo].[TheLoai]    Script Date: 22/11/2022 4:36:33 CH ******/
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
SET IDENTITY_INSERT [dbo].[ChatLieu] ON 

INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (1, N'Da Bò')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (2, N'Tơ Tằm')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (3, N'Tơ Sen')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (4, N'Vàng')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (5, N'Kim Cương')
SET IDENTITY_INSERT [dbo].[ChatLieu] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietHDB] ON 

INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (13, 4, 1, 1, 27.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (12, 4, 4, 1, 44.0000, 44.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (9, 9, 1, 1, 27.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (11, 9, 4, 1, 44.0000, 44.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (10, 9, 6, 1, 27.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (14, 10, 1, 2, 54.0000, 27.0000)
INSERT [dbo].[ChiTietHDB] ([MaCTHDB], [MaHDB], [MaCTSP], [SoLuong], [ThanhTien], [DonGiaBan]) VALUES (16, 11, 1, 1, 27.0000, 27.0000)
SET IDENTITY_INSERT [dbo].[ChiTietHDB] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietSP] ON 

INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (1, 1, 1, 3, 1)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (6, 1, 2, 3, 2)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (4, 4, 4, 4, 2)
INSERT [dbo].[ChiTietSP] ([MaCTSP], [MaS], [MaMS], [MaSP], [SoLuong]) VALUES (9, 8, 5, 3, 6)
SET IDENTITY_INSERT [dbo].[ChiTietSP] OFF
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (1, N'Quản Lý')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (2, N'Giám Đốc')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (3, N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonBan] ON 

INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (4, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 71.0000, 2, 2)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (9, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 98.0000, 3, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (10, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 54.0000, NULL, 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [NgayBan], [TongTien], [MaKH], [MaNV]) VALUES (11, CAST(N'2022-11-22T00:00:00.000' AS DateTime), 27.0000, NULL, 1)
SET IDENTITY_INSERT [dbo].[HoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (2, N'Pham Quang', N'012394124')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (3, N'Daxua', N'012394124')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (4, N'Nhat Anh', N'054988123')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [SoDT]) VALUES (5, N'Hoang Lam', N'012317292')
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
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (1, N'Nhân Viên Số 01', CAST(N'2009-11-15T00:00:00.000' AS DateTime), N'021958585', N'Hà Nội', 3, N'Nam', N'Đang Làm')
INSERT [dbo].[NhanVien] ([MaNV], [HoTenNV], [NgaySinh], [SoDT], [DiaChi], [MaCV], [GioiTinh], [TinhTrang]) VALUES (2, N'Nhân Viên Số 04', CAST(N'1995-02-04T00:00:00.000' AS DateTime), N'039412312', N'Hà Giang', 2, N'Nữ', N'Đang Làm')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[QuocGia] ON 

INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (1, N'Việt Nam')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (2, N'Nhật Bản')
INSERT [dbo].[QuocGia] ([MaQG], [TenQG]) VALUES (3, N'Hàn Quốc')
SET IDENTITY_INSERT [dbo].[QuocGia] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (3, N'Áo Da Bò', 27.0000, 10.0000, N'Nam', N'D:\296219759_176373904878559_8773703359931902353_n.jpg', 3, 1, 1)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonGiaBan], [DonGiaNhap], [GioiTinh], [Anh], [MaTL], [MaCL], [MaQG]) VALUES (4, N'Quần Vải', 44.0000, 10.0000, N'Nữ', N'D:\299118884_129760219777208_2069025036163472025_n.jpg', 2, 5, 3)
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
SET IDENTITY_INSERT [dbo].[Size] OFF
GO
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (1, N'Dép')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (2, N'Quần')
INSERT [dbo].[TheLoai] ([MaTL], [TenTL]) VALUES (3, N'Áo')
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
GO
/****** Object:  Index [UQ__ChiTietH__508BFF6E52F2D36C]    Script Date: 22/11/2022 4:36:33 CH ******/
ALTER TABLE [dbo].[ChiTietHDB] ADD UNIQUE NONCLUSTERED 
(
	[MaCTHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ChiTietH__508BFF5AED03F607]    Script Date: 22/11/2022 4:36:33 CH ******/
ALTER TABLE [dbo].[ChiTietHDN] ADD UNIQUE NONCLUSTERED 
(
	[MaCTHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ChiTietS__1E4FCECC86F1914F]    Script Date: 22/11/2022 4:36:33 CH ******/
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
