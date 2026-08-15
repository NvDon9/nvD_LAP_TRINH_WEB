using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Helpers;
using Ex04.StudentManagement.Models;
using Ex04.StudentManagement.Services;

namespace Ex04.StudentManagement.Views;

/// <summary>
/// Chịu trách nhiệm hiển thị dữ liệu và thu thập dữ liệu nhập từ người dùng.
/// Gọi xuống StudentService để thực hiện nghiệp vụ.
/// </summary>
public class StudentConsoleView
{
    private readonly StudentService _service;

    public StudentConsoleView(StudentService service)
    {
        _service = service;
    }

    private static void PrintHeader(string title)
    {
        Console.Clear();
        Console.WriteLine(new string('=', 100));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 100));
    }

    private static void PrintTableHeader()
    {
        Console.WriteLine($"{"Mã SV",-8} | {"Họ tên",-25} | {"Ngày sinh",10} | {"Giới tính",-6} | " +
                           $"{"Email",-25} | {"SĐT",-12} | {"Ngành học",-20} | {"Điểm TB",5} | Trạng thái");
        Console.WriteLine(new string('-', 130));
    }

    private static void PrintStudentList(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("(Không có sinh viên nào để hiển thị.)");
            return;
        }

        PrintTableHeader();
        foreach (var s in students)
        {
            Console.WriteLine(s.ToString());
        }
        Console.WriteLine(new string('-', 130));
        Console.WriteLine($"Tổng số: {students.Count} sinh viên.");
    }

    // 1. Thêm sinh viên
    public void AddStudent()
    {
        PrintHeader("THÊM SINH VIÊN MỚI");

        string maSinhVien = InputHelper.ReadNonEmptyString("Mã sinh viên: ");
        string hoTen = InputHelper.ReadNonEmptyString("Họ tên: ");
        DateTime ngaySinh = InputHelper.ReadDate("Ngày sinh (dd/MM/yyyy): ");
        Gender gioiTinh = InputHelper.ReadGender("Giới tính");
        string email = InputHelper.ReadNonEmptyString("Email: ");
        string? sdt = InputHelper.ReadOptionalString("Số điện thoại (có thể bỏ trống): ");
        string nganhHoc = InputHelper.ReadNonEmptyString("Ngành học: ");
        double diemTrungBinh = InputHelper.ReadDouble("Điểm trung bình (0-10): ", 0, 10);
        StudentStatus trangThai = InputHelper.ReadStatus("Trạng thái học tập");

        var student = new Student(maSinhVien, hoTen, ngaySinh, gioiTinh, email, sdt, nganhHoc, diemTrungBinh, trangThai);
        var (success, message) = _service.AddStudent(student);

        Console.WriteLine();
        Console.WriteLine(success ? $"[OK] {message}" : $"[LỖI] {message}");
        InputHelper.PauseBeforeContinue();
    }

    // 2. Hiển thị danh sách
    public void DisplayAll()
    {
        PrintHeader("DANH SÁCH SINH VIÊN");
        PrintStudentList(_service.GetAll());
        InputHelper.PauseBeforeContinue();
    }

    // 3. Tìm theo mã
    public void FindById()
    {
        PrintHeader("TÌM SINH VIÊN THEO MÃ");
        string ma = InputHelper.ReadNonEmptyString("Nhập mã sinh viên cần tìm: ");
        var student = _service.FindById(ma);

        if (student is null)
        {
            Console.WriteLine($"Không tìm thấy sinh viên có mã '{ma}'.");
        }
        else
        {
            PrintStudentList(new List<Student> { student });
        }
        InputHelper.PauseBeforeContinue();
    }

    // 4. Tìm gần đúng theo họ tên
    public void FindByNameApprox()
    {
        PrintHeader("TÌM SINH VIÊN THEO HỌ TÊN (GẦN ĐÚNG)");
        string keyword = InputHelper.ReadNonEmptyString("Nhập từ khóa họ tên: ");
        var results = _service.FindByNameApprox(keyword);
        PrintStudentList(results);
        InputHelper.PauseBeforeContinue();
    }

    // 5. Cập nhật sinh viên
    public void UpdateStudent()
    {
        PrintHeader("CẬP NHẬT SINH VIÊN");
        string ma = InputHelper.ReadNonEmptyString("Nhập mã sinh viên cần cập nhật: ");
        var student = _service.FindById(ma);

        if (student is null)
        {
            Console.WriteLine($"[LỖI] Không tìm thấy sinh viên có mã '{ma}'.");
            InputHelper.PauseBeforeContinue();
            return;
        }

        Console.WriteLine("Thông tin hiện tại:");
        PrintStudentList(new List<Student> { student });
        Console.WriteLine("\nNhập thông tin mới (Enter để giữ nguyên với các trường có thể bỏ trống):\n");

        string hoTen = InputHelper.ReadNonEmptyString($"Họ tên [{student.HoTen}]: ");
        DateTime ngaySinh = InputHelper.ReadDate($"Ngày sinh [{student.NgaySinh:dd/MM/yyyy}]: ");
        Gender gioiTinh = InputHelper.ReadGender("Giới tính");
        string email = InputHelper.ReadNonEmptyString($"Email [{student.Email}]: ");
        string? sdt = InputHelper.ReadOptionalString($"Số điện thoại [{student.SoDienThoai ?? "(trống)"}]: ");
        string nganhHoc = InputHelper.ReadNonEmptyString($"Ngành học [{student.NganhHoc}]: ");
        double diem = InputHelper.ReadDouble("Điểm trung bình (0-10): ", 0, 10);
        StudentStatus trangThai = InputHelper.ReadStatus("Trạng thái học tập");

        var (success, message) = _service.UpdateStudent(ma, s =>
        {
            s.HoTen = hoTen;
            s.NgaySinh = ngaySinh;
            s.GioiTinh = gioiTinh;
            s.Email = email;
            s.SoDienThoai = sdt;
            s.NganhHoc = nganhHoc;
            s.DiemTrungBinh = diem;
            s.TrangThaiHocTap = trangThai;
        });

        Console.WriteLine();
        Console.WriteLine(success ? $"[OK] {message}" : $"[LỖI] {message}");
        InputHelper.PauseBeforeContinue();
    }

    // 6. Xóa sinh viên
    public void DeleteStudent()
    {
        PrintHeader("XÓA SINH VIÊN");
        string ma = InputHelper.ReadNonEmptyString("Nhập mã sinh viên cần xóa: ");
        var student = _service.FindById(ma);

        if (student is null)
        {
            Console.WriteLine($"[LỖI] Không tìm thấy sinh viên có mã '{ma}'.");
            InputHelper.PauseBeforeContinue();
            return;
        }

        PrintStudentList(new List<Student> { student });
        bool confirm = InputHelper.ReadYesNo("Bạn có chắc chắn muốn xóa sinh viên này không?");

        if (confirm)
        {
            var (success, message) = _service.DeleteStudent(ma);
            Console.WriteLine(success ? $"[OK] {message}" : $"[LỖI] {message}");
        }
        else
        {
            Console.WriteLine("Đã hủy thao tác xóa.");
        }

        InputHelper.PauseBeforeContinue();
    }

    // 7. Sắp xếp theo họ tên
    public void SortByName()
    {
        PrintHeader("SẮP XẾP SINH VIÊN THEO HỌ TÊN");
        bool ascending = InputHelper.ReadYesNo("Sắp xếp tăng dần?");
        PrintStudentList(_service.SortByName(ascending));
        InputHelper.PauseBeforeContinue();
    }

    // 8. Sắp xếp theo điểm trung bình
    public void SortByGpa()
    {
        PrintHeader("SẮP XẾP SINH VIÊN THEO ĐIỂM TRUNG BÌNH");
        bool ascending = InputHelper.ReadYesNo("Sắp xếp tăng dần?");
        PrintStudentList(_service.SortByGpa(ascending));
        InputHelper.PauseBeforeContinue();
    }

    // 9. Hiển thị sinh viên có điểm >= 8
    public void DisplayHighAchievers()
    {
        PrintHeader("SINH VIÊN CÓ ĐIỂM TỪ 8 TRỞ LÊN");
        PrintStudentList(_service.GetStudentsWithGpaFrom(8));
        InputHelper.PauseBeforeContinue();
    }

    // 10. Hiển thị sinh viên có điểm cao nhất
    public void DisplayTopStudent()
    {
        PrintHeader("SINH VIÊN CÓ ĐIỂM CAO NHẤT");
        PrintStudentList(_service.GetTopGpaStudents());
        InputHelper.PauseBeforeContinue();
    }

    // 11. Tính điểm trung bình toàn bộ sinh viên
    public void DisplayOverallAverage()
    {
        PrintHeader("ĐIỂM TRUNG BÌNH TOÀN BỘ SINH VIÊN");
        if (_service.Count == 0)
        {
            Console.WriteLine("Chưa có sinh viên nào trong hệ thống.");
        }
        else
        {
            double avg = _service.GetOverallAverageGpa();
            Console.WriteLine($"Điểm trung bình chung của {_service.Count} sinh viên: {avg:0.00}");
        }
        InputHelper.PauseBeforeContinue();
    }

    // 12. Thống kê theo ngành
    public void DisplayStatsByMajor()
    {
        PrintHeader("THỐNG KÊ SINH VIÊN THEO NGÀNH HỌC");
        var stats = _service.GetStatsByMajor();

        if (stats.Count == 0)
        {
            Console.WriteLine("Chưa có sinh viên nào trong hệ thống.");
        }
        else
        {
            foreach (var kv in stats)
            {
                Console.WriteLine($"{kv.Key,-30}: {kv.Value} sinh viên");
            }
        }
        InputHelper.PauseBeforeContinue();
    }

    // 13. Thống kê theo trạng thái
    public void DisplayStatsByStatus()
    {
        PrintHeader("THỐNG KÊ SINH VIÊN THEO TRẠNG THÁI HỌC TẬP");
        var stats = _service.GetStatsByStatus();

        if (stats.Count == 0)
        {
            Console.WriteLine("Chưa có sinh viên nào trong hệ thống.");
        }
        else
        {
            foreach (var kv in stats)
            {
                string label = kv.Key switch
                {
                    StudentStatus.DangHoc => "Đang học",
                    StudentStatus.BaoLuu => "Bảo lưu",
                    StudentStatus.DaTotNghiep => "Đã tốt nghiệp",
                    StudentStatus.ThoiHoc => "Thôi học",
                    _ => "Không xác định"
                };
                Console.WriteLine($"{label,-20}: {kv.Value} sinh viên");
            }
        }
        InputHelper.PauseBeforeContinue();
    }
}
