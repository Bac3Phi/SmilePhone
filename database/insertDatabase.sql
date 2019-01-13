USE [master]
GO
ALTER DATABASE [CellphoneComponent] SET  READ_WRITE 
GO
select * from dbo.PhanQuyen
insert into dbo.PhanQuyen values ('PQ1', N'Admin');
insert into dbo.PhanQuyen values ('PQ2', N'Kế Toán');
insert into dbo.PhanQuyen values ('PQ3', N'Kinh doanh');
insert into dbo.PhanQuyen values ('PQ4', N'Thủ kho');

select * from dbo.NhanVien
insert into dbo.NhanVien values ('NV2', N'Trần Văn A', N'abc', '123', 'PQ1','');
insert into dbo.NhanVien values ('NV1', N'Phạm Thị Minh', N'minhpt', '456', 'PQ2','');
insert into dbo.NhanVien values ('NV3', N'Đặng Văn Thành', N'thanhdv', '789', 'PQ4','');
insert into dbo.NhanVien values ('NV4', N'Nguyễn Thị Trang', N'trangnt', '357', 'PQ3','');

select * from dbo.NhaCungCap
INSERT INTO dbo.NHACUNGCAP VALUES('NCC1', N'Công Ty TNHH Tin học Đông Phúc', N'147 ĐƯỜNG BA CU', '0978456812', 'DONGPHUC@GMAIL.COM')
INSERT INTO dbo.NHACUNGCAP VALUES('NCC2', N'Công Ty TNHH Nam Thông Bảo', N'258 ĐƯỜNG LÊ DUẨN', '09034562', 'NAMTHONGBAO@GMAIL.COM')
INSERT INTO dbo.NHACUNGCAP VALUES('NCC3', N'Công Ty TNHH TM DV Tin Học Hoàng Khang', N'369 ĐƯỜNG HOA SỮA', '09039994533', 'HOANGKHANG@GMAIL.COM')
INSERT INTO dbo.NHACUNGCAP VALUES('NCC4', N'Công Ty TNHH TM & DV Nhật Tân Tín', N'357 ĐƯỜNG VÕ THỊ SÁU', '01228041103', 'NHATTANTIN@GMAIL.COM')
INSERT INTO dbo.NHACUNGCAP VALUES('NCC5', N'Công Ty TNHH MTV Tên Lửa Số', N'159 ĐƯỜNG ĐINH TIÊN HOÀNG', '01227456666', 'TENLUASO@GMAIL.COM')
INSERT INTO dbo.NHACUNGCAP VALUES('NCC6', N'Công Ty TNHH Vi Tính Tiến Phát', N'123 ĐƯỜNG LÊ VĂN SỈ', '01697542311', 'TIENPHAT@GMAIL.COM')

select MaNhanVien from dbo.NhanVien where MaNhanVien = (Select Max(MaNhanVien) from dbo.NhanVien)
select MaPhanQuyen from dbo.PhanQuyen where TenPhanQuyen = N'Admin'

select * from dbo.LoaiHangHoa
INSERT INTO dbo.LoaiHangHoa VALUES('LHH1', N'Tai nghe', '5')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH2', N'Ốp lưng điện thoại', '5')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH3', N'Pin', '7')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH4', N'Cáp sạc', '7')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH5', N'Dây volume', '8')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH6', N'Màn hình', '10')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH7', N'Dây cảm biến', '7')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH8', N'Dây nguồn đuôi sạc', '12')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH9', N'Khay sim', '5')
INSERT INTO dbo.LoaiHangHoa VALUES('LHH010', N'Dây nút home', '8')

select * from dbo.HangHoa
INSERT INTO dbo.HangHoa VALUES('HH1', N'Tai nghe Apple EarPods Lightning', '120', '10', '20', N'Cai', N'chiều dài tiêu chuẩn là 118cm', N'Tai nghe được trang bị controller đặc biệt, với 3 phím chức năng và 1 micro thoại.', N'Mỹ', '6', '', N'LHH1', N'1', N'APEPODUBLI7')
INSERT INTO dbo.HangHoa VALUES('HH2', N'Pin tăng dung lượng Remax RPA-i7', '25', '15', '30', N'Cục', N'Pin tăng dung lượng dành cho iPhone 7 có dung lượng là 22mAh, cao hơn dung pin mặc định (1960mAh) là 240mAh. Còn pin dành cho iPhone 7+ có dung lượng 33mAh, cao hơn dung lượng pin mặc định (29mAh) là 4mAh.', N'Model: RPA - i7\nDung lượng: 22/ 33mAh\nLõi pin: Polymer\nInput: DC4.35V\nOutput: 3.8V\nTương thích: model iPhone 7 và iPhone 7 plus.', N'Trung Quốc', '1', '', N'LHH3', N'1', N'PRMRPAi7')
INSERT INTO dbo.HangHoa VALUES('HH3', N'Màn hình full zin Amoled Iphone X', '290', '5', '25', N'Cái', N'', N'', N'Đài Loan', '', '', N'LHH6', N'0', N'MHZIPX')

select * from dbo.PhieuNhap
INSERT INTO dbo.PhieuNhap VALUES('PN1', '2018-05-10T18:10:00', 'NV3', N'NCC6', '79345', N'Nhập đủ. Hàng chất lượng tốt.', '2018-05-14T18:10:00')
INSERT INTO dbo.PhieuNhap VALUES('PN2', '2018-12-20T18:10:00', 'NV3', N'NCC3', '228570', N'Nhập được 50% số lượng đặt. Hàng chất lượng tốt.', '2018-12-27T18:10:00')

select * from dbo.ChiTietPhieuNhap
INSERT INTO dbo.ChiTietPhieuNhap VALUES('PN1', 'HH2', '30', '233644', '79345', 'CTPN1')
INSERT INTO dbo.ChiTietPhieuNhap VALUES('PN2', 'HH1', '20', '1142857', '228570', 'CTPN2')

select * from dbo.PhieuChi
INSERT INTO dbo.PhieuChi VALUES('PC1', '2018-05-15', 'NV1', 'PN1', '79345', N'Đã hoàn tất việc thu chi.', '2018-05-15')
INSERT INTO dbo.PhieuChi VALUES('PC2', '2018-12-29', 'NV1', 'PN2', '228570', N'Đã hoàn tất việc thu chi cho 50% số lượng đặt.', '2019-01-02')