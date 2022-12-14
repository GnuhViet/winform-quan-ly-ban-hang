USE [QLBanGiay]
GO
--1
/****** Object:  Trigger [dbo].[tg_SoLuongKhiBan]    Script Date: 23/11/2022 8:22:32 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_SoLuongKhiBan] on [dbo].[ChiTietHDB] for insert, delete, update as
begin
	update ChiTietSP
	set SoLuong = SoLuong - a.sl
	from
	(
		select MaCTSP, sum(SoLuong) sl
		from inserted
		group by MaCTSP
	) a
	where a.MaCTSP = ChiTietSP.MaCTSP

	update ChiTietSP
	set SoLuong = SoLuong + a.sl
	from
	(
		select MaCTSP, sum(SoLuong) sl
		from deleted
		group by MaCTSP
	) a
	where a.MaCTSP = ChiTietSP.MaCTSP
end
--2
/****** Object:  Trigger [dbo].[tg_SoLuongKhiNhap]    Script Date: 23/11/2022 8:23:09 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_SoLuongKhiNhap] on [dbo].[ChiTietHDN] for insert, delete, update as
begin
	update ChiTietSP
	set SoLuong = SoLuong + a.sl
	from
	(
		select MaCTSP, sum(SoLuong) sl
		from inserted
		group by MaCTSP
	) a
	where a.MaCTSP = ChiTietSP.MaCTSP

	update ChiTietSP
	set SoLuong = SoLuong - a.sl
	from
	(
		select MaCTSP, sum(SoLuong) sl
		from deleted
		group by MaCTSP
	) a
	where a.MaCTSP = ChiTietSP.MaCTSP
end
--3
/****** Object:  Trigger [dbo].[tg_TinhGiaBanKhiNhap]    Script Date: 23/11/2022 8:23:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_TinhGiaBanKhiNhap] on [dbo].[ChiTietHDN] for insert, update as
begin
	update SanPham
	set DonGiaNhap = a.dgn, DonGiaBan = a.Dgn * 1.1
	from
	(
		select MaSP,  DonGiaNhap dgn
		from inserted i join ChiTietSP c on i.MaCTSP = c.MaCTSP
	) a
	where SanPham.MaSP = a.MaSP
end
--4
/****** Object:  Trigger [dbo].[tg_TongTienHDN]    Script Date: 23/11/2022 8:23:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_TongTienHDN] on [dbo].[ChiTietHDN] for insert, delete, update as
begin
	update HoaDonNhap
	set TongTien = isnull(TongTien, 0) + a.tien
	from
	(
		select MaHDN, sum(ThanhTien) tien
		from inserted
		group by MaHDN
	) a
	where HoaDonNhap.MaHDN = a.MaHDN

	update HoaDonNhap
	set TongTien = isnull(TongTien, 0) - a.tien
	from
	(
		select MaHDN, sum(ThanhTien) tien
		from deleted
		group by MaHDN
	) a
	where HoaDonNhap.MaHDN = a.MaHDN
end
--5
/****** Object:  Trigger [dbo].[tg_delHDB]    Script Date: 23/11/2022 8:24:13 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_delHDB] on [dbo].[HoaDonBan] instead of delete as
begin
	delete from ChiTietHDB
	where MaHDB in (select MaHDB from deleted)

	delete from HoaDonBan
	where MaHDB in (select MaHDB from deleted)
end
--6
/****** Object:  Trigger [dbo].[tg_delHDN]    Script Date: 23/11/2022 8:24:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_delHDN] on [dbo].[HoaDonNhap] instead of delete as
begin
	delete from ChiTietHDN
	where MaHDN in (select MaHDN from deleted)

	delete from HoaDonNhap
	where MaHDN in (select MaHDN from deleted)
end
--7
/****** Object:  Trigger [dbo].[tg_delNV]    Script Date: 23/11/2022 8:24:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_delNV] on [dbo].[NhanVien] instead of delete as
begin
	update NhanVien
	set TinhTrang = N'Th??i vi???c'
	where MaNV in
	(
		select MaNV from deleted
	)
end