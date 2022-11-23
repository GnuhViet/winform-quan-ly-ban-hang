drop view SanPhamTonKho
--1 in danh sach san pham ton kho
create view SanPhamTonKho
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

drop function fn_DanhSachHoaDonTheoNhanVien;

-- 3 Báo cáo danh sách hóa đơn và tổng tiền nhập hàng theo quý chọn trước
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

-- 2 Báo cáo danh sách hóa đơn và tổng tiền nhập hàng theo quý chọn trước
drop function fn_BaoCaoHoaDonNhapTheoQuyVaNam
create function fn_BaoCaoHoaDonNhapTheoQuyVaNam(@monthStart int, @monthEnd int, @nam int)
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
select * from fn_BaoCaoHoaDonNhapTheoQuyVaNam('8', '12','2022')

-- 4 Báo cáo danh sách hóa đơn và tổng tiền nhập hàng theo quý chọn trước
drop function fn_Top3KhachHang
create function fn_Top3KhachHang(@monthStart int, @monthEnd int, @nam int)
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

select * from fn_Top3KhachHang('8', '12','2022')