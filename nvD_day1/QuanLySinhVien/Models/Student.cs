using Ex04.StudentManagement.Enums;

namespace Ex04.StudentManagement.Models;

/// <summary>
/// Lớp Student mô tả một sinh viên.
/// Minh họa: Class & Object, Constructor, Property, Encapsulation, Static Member,
/// Nullable Reference Types.
/// </summary>
public class Student
{
  
    // Đếm tổng số đối tượng Student đã được tạo ra (toàn bộ vòng đời chương trình).
    private static int _totalCreated = 0;
    public static int TotalCreated => _totalCreated;

    // Encapsulation: các trường private, truy cập qua Property 
    private string _maSinhVien = string.Empty;
    private string _hoTen = string.Empty;
    private double _diemTrungBinh;

    public string MaSinhVien
    {
        get => _maSinhVien;
        set => _maSinhVien = value.Trim();
    }

    public string HoTen
    {
        get => _hoTen;
        set => _hoTen = value.Trim();
    }

    public DateTime NgaySinh { get; set; }

    public Gender GioiTinh { get; set; }

    public string Email { get; set; } = string.Empty;

    // Số điện thoại có thể không bắt buộc -> Nullable Reference Type
    public string? SoDienThoai { get; set; }

    public string NganhHoc { get; set; } = string.Empty;

    public double DiemTrungBinh
    {
        get => _diemTrungBinh;
        set
        {
            // Ràng buộc nghiệp vụ: điểm trung bình trong khoảng 0 - 10
            if (value < 0 || value > 10)
                throw new ArgumentOutOfRangeException(nameof(value), "Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");
            _diemTrungBinh = value;
        }
    }

    public StudentStatus TrangThaiHocTap { get; set; }

    // ----- Constructor -----
    public Student(
        string maSinhVien,
        string hoTen,
        DateTime ngaySinh,
        Gender gioiTinh,
        string email,
        string? soDienThoai,
        string nganhHoc,
        double diemTrungBinh,
        StudentStatus trangThaiHocTap)
    {
        MaSinhVien = maSinhVien;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        GioiTinh = gioiTinh;
        Email = email;
        SoDienThoai = soDienThoai;
        NganhHoc = nganhHoc;
        DiemTrungBinh = diemTrungBinh;
        TrangThaiHocTap = trangThaiHocTap;

        _totalCreated++;
    }

    public string GioiTinhToString() => GioiTinh switch
    {
        Gender.Nam => "Nam",
        Gender.Nu => "Nữ",
        Gender.Khac => "Khác",
        _ => "Không xác định"
    };

    public string TrangThaiToString() => TrangThaiHocTap switch
    {
        StudentStatus.DangHoc => "Đang học",
        StudentStatus.BaoLuu => "Bảo lưu",
        StudentStatus.DaTotNghiep => "Đã tốt nghiệp",
        StudentStatus.ThoiHoc => "Thôi học",
        _ => "Không xác định"
    };

    public override string ToString()
    {
        return $"{MaSinhVien,-8} | {HoTen,-25} | {NgaySinh:dd/MM/yyyy} | {GioiTinhToString(),-6} | " +
               $"{Email,-25} | {SoDienThoai ?? "(trống)",-12} | {NganhHoc,-20} | {DiemTrungBinh,5:0.00} | {TrangThaiToString()}";
    }
}
