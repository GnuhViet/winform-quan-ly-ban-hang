drop view SanPhamTonKho

create view SanPhamTonKho
as
select SanPham.MaSP as [Mã],
       TenSP        as [Tên Sản Phẩm],
       DonGiaBan       [Giá Bán],
       DonGiaNhap      [Giá Nhập],
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

drop function fn_DanhSachHoaDonTheoNhanVien;

create function fn_DanhSachHoaDonTheoNhanVien(@HoTenNV nvarchar(255))
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

create function fn_TinhTongTienTheoNhanVien(@HoTenNV nvarchar(255))
    returns money as
begin
    declare @TongTien money, @MaNV int
    select @MaNV = MaNV from NhanVien where HoTenNV = @HoTenNV
    select @TongTien = SUM(TongTien) from HoaDonBan where MaNV = @MaNV
    return @TongTien
end

select * from fn_DanhSachHoaDonTheoNhanVien('Blue Dante')
print dbo.fn_TinhTongTienTheoNhanVien('Blue Dante')
