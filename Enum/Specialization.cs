using System.ComponentModel.DataAnnotations;

namespace AppointmentHospital.EnumStatus
{
    public enum Specialization
    {
        [Display(Name ="Tai mũi họng")]
        TaiMuiHong,
        [Display(Name = "Nhi")]
        Nhi,
        [Display(Name = "Da Liễu")]
        DaLieu,
        [Display(Name = "Ngoại Khoa")]
        NgoaiKhoa,
        [Display(Name = "Nội Khoa")]
        NoiKhoa,
        [Display(Name = "Răng Hàm Mặt")]
        RangHamMat,
        [Display(Name = "Sản Khoa")]
        SanKhoa,
        [Display(Name = "Nhãn Khoa")]
        NhanKhoa,
        [Display(Name = "Tim Mạch")]
        TimMach,
        [Display(Name = "Thần Kinh")]
        ThanKinh,
        [Display(Name = "Mắt")]
        Mat,
        [Display(Name = "Phụ Khoa")]
        PhuKhoa
    }
}
