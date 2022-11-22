USE [QLBanGiay]
GO
/****** Object:  Trigger [dbo].[tg_SoLuongKhiBan]    Script Date: 22/11/2022 4:37:21 CH ******/
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
/****** Object:  Trigger [dbo].[tg_SoLuongKhiNhap]    Script Date: 22/11/2022 4:37:56 CH ******/
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
/****** Object:  Trigger [dbo].[tg_TongTienHDN]    Script Date: 22/11/2022 4:38:09 CH ******/
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
/****** Object:  Trigger [dbo].[tg_delHDB]    Script Date: 22/11/2022 4:38:58 CH ******/
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
/****** Object:  Trigger [dbo].[tg_delHDN]    Script Date: 22/11/2022 4:39:12 CH ******/
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
/****** Object:  Trigger [dbo].[tg_delNV]    Script Date: 22/11/2022 4:39:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[tg_delNV] on [dbo].[NhanVien] instead of delete as
begin
	update NhanVien
	set TinhTrang = N'Thôi việc'
	where MaNV in
	(
		select MaNV from deleted
	)
end






