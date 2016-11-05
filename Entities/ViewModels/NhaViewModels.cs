﻿using System.ComponentModel.DataAnnotations;
using System;
namespace Entities.ViewModels
{
    public class NhaCreatingViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn dạng mặt bằng")]
        [Display(Name = "Dạng mặt bằng")]
        public string MatBangId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quận")]
        [Display(Name = "Quận")]
        public long QuanId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn đường")]
        [Display(Name = "Đường")]
        public string DuongId { get; set; }

        [Display(Name = "Số nhà")]
        [StringLength(200, ErrorMessage = "Số nhà không được vượt quá 200 ký tự!")]
        public string SoNha { get; set; }

        [Display(Name = "Tên tòa nhà")]
        [StringLength(200, ErrorMessage = "Tên tòa nhà không được vượt quá 200 ký tự!")]
        public string TenToaNha { get; set; }

        [Display(Name = "Mặt tiền treo biển (m)")]
        public string MatTienTreoBien { get; set; }

        [Display(Name = "Bề ngang lọt lòng (m)")]
        public string BeNgangLotLong { get; set; }

        [Display(Name = "Diện tích đất (m2)")]
        public string DienTichDat { get; set; }

        [Display(Name = "Diện tích đất sử dụng tầng 1 (m2)")]
        public string DienTichDatSuDungTang1 { get; set; }

        [Display(Name = "Số tầng")]
        public string SoTang { get; set; }

        [Display(Name = "Tổng diện tích sử dụng (m2)")]
        public string TongDienTichSuDung { get; set; }

        [Display(Name = "Đi chung chủ")]
        public string DiChungChu { get; set; }

        [Display(Name = "Hầm")]
        public string Ham { get; set; }

        [Display(Name = "Thang máy")]
        public string ThangMay { get; set; }

        [Display(Name = "Nội thất/ Khách thuê cũ")]
        public string NoiThatKhachThueCuId { get; set; }

        [Display(Name = "Đánh giá phù hợp với")]
        public string DanhGiaPhuHopVoiId { get; set; }

        [Display(Name = "Tổng giá thuê")]
        public string TongGiaThue { get; set; }

        [Display(Name = "Giá thuê BQ/m2")]
        public string GiaThueBQ { get; set; }

        [Display(Name = "Tên người liên hệ - vai trò")]
        public string TenNguoiLienHeVaiTro { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Ngày CN hẹn liên hệ lại")]
        public string NgayCNHenLienHeLai { get; set; }

        [Display(Name = "Cấp độ theo dõi")]
        public string CapDoTheoDoiId { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Ngày tạo")]
        [RegularExpression(@"^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$", ErrorMessage = "Ngày không hợp lệ!")]
        public string NgayTao { get; set; }

        [Display(Name = "Người tạo")]
        public string NguoiTaoId { get; set; }

        [Display(Name = "Nhân viên phụ trách")]
        public string NhanVienPhuTrachId { get; set; }

        [Display(Name = "Đã phân công")]
        public string DaPhanCong { get; set; }

        [Display(Name = "Tên nhân viên phụ trách")]
        public string NhanVienPhuTrachName { get; set; }

        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; }
    }
    public class NhaUpdatingViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn dạng mặt bằng")]
        [Display(Name = "Dạng mặt bằng")]
        public long MatBangId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quận")]
        [Display(Name = "Quận")]
        public long QuanId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn đường")]
        [Display(Name = "Đường")]
        public long DuongId { get; set; }

        [Display(Name = "Số nhà")]
        [StringLength(200, ErrorMessage = "Số nhà không được vượt quá 200 ký tự!")]
        public string SoNha { get; set; }

        [Display(Name = "Tên tòa nhà")]
        [StringLength(200, ErrorMessage = "Tên tòa nhà không được vượt quá 200 ký tự!")]
        public string TenToaNha { get; set; }

        [Display(Name = "Mặt tiền treo biển (m)")]
        public float MatTienTreoBien { get; set; }

        [Display(Name = "Bề ngang lọt lòng (m)")]
        public float BeNgangLotLong { get; set; }

        [Display(Name = "Diện tích đất (m2)")]
        public float DienTichDat { get; set; }

        [Display(Name = "Diện tích đất sử dụng tầng 1 (m2)")]
        public float DienTichDatSuDungTang1 { get; set; }

        [Display(Name = "Số tầng")]
        public int SoTang { get; set; }

        [Display(Name = "Tổng diện tích sử dụng (m2)")]
        public float TongDienTichSuDung { get; set; }

        [Display(Name = "Đi chung chủ")]
        public bool DiChungChu { get; set; }

        [Display(Name = "Hầm")]
        public bool Ham { get; set; }

        [Display(Name = "Thang máy")]
        public bool ThangMay { get; set; }

        [Display(Name = "Nội thất/ Khách thuê cũ")]
        public long NoiThatKhachThueCuId { get; set; }

        [Display(Name = "Đánh giá phù hợp với")]
        public long DanhGiaPhuHopVoiId { get; set; }

        [Display(Name = "Tổng giá thuê")]
        public decimal TongGiaThue { get; set; }

        [Display(Name = "Giá thuê BQ/m2")]
        public decimal GiaThueBQ { get; set; }

        [Display(Name = "Tên người liên hệ - vai trò")]
        public string TenNguoiLienHeVaiTro { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Ngày CN hẹn liên hệ lại")]
        public string NgayCNHenLienHeLai { get; set; }

        [Display(Name = "Cấp độ theo dõi")]
        public int CapDoTheoDoiId { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Ngày tạo")]
        [RegularExpression(@"^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$", ErrorMessage = "Ngày không hợp lệ!")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Người tạo")]
        public long NguoiTaoId { get; set; }

        [Display(Name = "Nhân viên phụ trách")]
        public long NhanVienPhuTrachId { get; set; }

        [Display(Name = "Khách")]
        public long KhachId { get; set; }

        [Display(Name = "Nhu cầu thuê")]
        public long NhuCauThueId { get; set; }

        [Display(Name = "Đã phân công")]
        public string DaPhanCong { get; set; }

        [Display(Name = "Tên nhân viên phụ trách")]
        public string NhanVienPhuTrachName { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
    }
}
