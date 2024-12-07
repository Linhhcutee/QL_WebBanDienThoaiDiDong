use QL_DienThoaiDiDongWeb
select * from TAIKHOAN
INSERT INTO VaiTro (TenVaiTro, Mota)
VALUES (N'Nhân Viên', N'Nhân Viên Của Cửa Hàng'),
       (N'Quản Lý', N'Người quản lý cửa hàng'),
	   (N'Admin', N'Người quản lý hệ thống'),
       (N'Khách Hàng', N'Người dùng thông thường');
INSERT INTO Mau (TenMau, MaHex, MoTa)
VALUES
(N'Đen', '#000000', N'Màu đen'),
(N'Đỏ', '#FF0000', N'Màu đỏ tươi'),
(N'Xanh Dương', '#0000FF', N'Màu xanh dương đậm'),
(N'Xanh Lá', '#00FF00', N'Màu xanh lá cây'),
(N'Vàng', '#FFFF00', N'Màu vàng sáng'),
(N'Trắng', '#FFFFFF', N'Màu trắng tinh khôi');
INSERT INTO TrangThai(TenTrangThai, Mota) VALUES
(N'Đã Bán'),
(N'Chưa Bán')
INSERT INTO TAIKHOAN (TenTK, MK, HoDem, Ten, VaiTroId) VALUES 
('nguyenan', '123', N'Nguyễn', N'An', 7),
('tranbinh', '123', N'Trần', N'Bình', 7),
('phamlinh', '123', N'Phạm', N'Linh', 7),
('phamdung', '123', N'Phạm', N'Dũng', 7),
('hoanghai', '123', N'Hoàng', N'Hải', 7)


INSERT INTO THUONGHIEU (Ten, QuocGia) VALUES 
('Apple', 'Mỹ'),
('Samsung', 'Hàn Quốc'),
('Xiaomi', 'Trung Quốc'),
('Nokia', 'Phần Lan'),
('Sony', 'Nhật Bản');

insert into LoaiSP(tenloai,mota) values
(N'Loại 1', N'Hàng Mới Full Box'),
(N'Loại 2', N'Hàng đẹp 98-99%'),
(N'Loại 3', N'Hàng cấn móp, ngoại hình xấu');
select * from SANPHAM
INSERT INTO [dbo].[SANPHAM] (Ten, Anh, SL, BoNho, Ram, CPU, ManHinh, Camera, Pin, MoTa, MaThuongHieu) VALUES 
('iPhone 14', 'iphone14.jpg', 10, '128GB', '4GB', 'A15', '6.1 inches', '12MP', '3279 mAh', N'Điện thoại thông minh của Apple', 1),
('Galaxy S21', 'galaxyS21.jpg', 15, '256GB', '8GB', 'Exynos 2100', '6.2 inches', '12MP', '4000 mAh', N'Điện thoại thông minh của Samsung', 2),
('Mi 11', 'mi11.jpg', 20, '128GB', '8GB', 'Snapdragon 888', '6.81 inches', '108MP', '4600 mAh', N'Điện thoại thông minh của Xiaomi', 3),
('Nokia 3310', 'nokia3310.jpg', 5, '16MB', '16MB', 'N/A', '2.4 inches', '0.3MP', '1200 mAh', N'Điện thoại cổ điển', 4),
('Xperia 5', 'xperia5.jpg', 8, '128GB', '8GB', 'Snapdragon 865', '6.1 inches', '12MP', '3140 mAh', N'Điện thoại thông minh của Sony', 5),
('Samsung Galaxy S21', NULL, 10, '128GB', '8GB', 'Exynos 2100', '6.2 inches', '64MP', '4000mAh', N'Flagship phone from Samsung', 1),
('iPhone 12', NULL, 15, '64GB', '4GB', 'A14 Bionic', '6.1 inches', '12MP', '2815mAh', N'Flagship phone from Apple', 2),
('Xiaomi Mi 11', NULL, 20, '256GB', '8GB', 'Snapdragon 888', '6.81 inches', '108MP', '4600mAh', N'Flagship phone from Xiaomi', 3),
('Sony Xperia 1 III', NULL, 5, '256GB', '12GB', 'Snapdragon 888', '6.5 inches', '12MP', '4500mAh', N'Premium phone from Sony', 5),
('Nokia 8.3 5G', NULL, 8, '128GB', '8GB', 'Snapdragon 765G', '6.81 inches', '64MP', '4500mAh', N'5G capable phone from Nokia', 4);

DBCC CHECKIDENT ('CTSANPHAM', RESEED, 0);
INSERT INTO CTSANPHAM (IMEI, Ten, GiaBan, TrangThai, Mau) VALUES
('123456789012345', N'iPhone 14', 5000000, 1, 1),
('123456789012346', N'Galaxy S21', 7000000, 1, 2),
('123456789012347', N'Mi 11', 9000000, 1, 3),
('123456789012348', N'Nokia 3310', 1500000, 1, 1),
('123456789012349', N'Xperia 5', 2000000, 1, 2),
('123456789012350', N'Samsung Galaxy S21', 2500000, 1, 3),
('123456789012351', N'iPhone 12', 3000000, 1, 1),
('123456789012352', N'Xiaomi Mi 11', 3500000, 1, 2),
('123456789012353', N'Sony Xperia 1 III', 4000000, 1, 3),
('123456789012354', N'Nokia 8.3 5G', 4500000, 1, 1);

INSERT INTO HOADON (MaTaiKhoan, NgayLap, TongTien, GhiChu) VALUES 
('user5', GETDATE(), 5000000, 'Mua iPhone 14'),
('user6', GETDATE(), 7000000, 'Mua Galaxy S21'),
('user7', GETDATE(), 9000000, 'Mua Mi 11'),
('user8', GETDATE(), 1500000, 'Mua Nokia 3310'),
('user9', GETDATE(), 2000000, 'Mua Xperia 5');

INSERT INTO PHIEUNHAPKHO (TenNV, TRANGTHAITT, THOIGIAN,TONGTIEN, MOTA)
VALUES 
('user1', N'Hoàn thành', GETDATE(),100000000, N'Nhập hàng đợt 1'),
('user2', N'Chưa hoàn thành', GETDATE(),50000000, N'Nhập hàng đợt 2'),
('user3', N'Hoàn thành', GETDATE(),30000000, N'Nhập hàng đợt 3'),
('user4', N'Hoàn thành', GETDATE(),70000000, N'Nhập hàng đợt 4'),
('user5', N'Chưa hoàn thành', GETDATE(),95000000, N'Nhập hàng đợt 5');


INSERT INTO CHITIETPNK (TenSanPham, LoaiSP, MAPHIEUNHAP, SOLUONG, GiaNhap, GHICHU)
VALUES
(N'iPhone 14', 1, 1, 10, 4500000, N'Mới, còn bảo hành'),
(N'Galaxy S21', 2, 2, 5, 5500000, N'Mới, còn bảo hành'),
(N'Mi 11', 3, 3, 7, 7500000, N'Mới, nguyên seal');

INSERT INTO CTHOADON (MaHoaDon, TenSanPham, IMEI)
VALUES
(1, N'iPhone 14', '123456789012345'),
(2, N'Galaxy S21', '123456789012346'),
(3, N'Mi 11', '123456789012347'),
(4, N'Nokia 3310', '123456789012348'),
(5, N'Xperia 5', '123456789012349');


select * from hoa