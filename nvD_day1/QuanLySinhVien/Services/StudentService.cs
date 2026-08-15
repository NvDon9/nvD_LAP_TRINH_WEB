using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Models;
using Ex04.StudentManagement.Validators;

namespace Ex04.StudentManagement.Services;

/// <summary>
/// Xử lý toàn bộ nghiệp vụ quản lý sinh viên (CRUD, tìm kiếm, sắp xếp, thống kê).
/// Sử dụng List&lt;Student&gt; để lưu trữ trong bộ nhớ.
/// </summary>
public class StudentService
{
    private readonly List<Student> _students = new();

    public IReadOnlyList<Student> Students => _students;

    public int Count => _students.Count;

    // 1. Thêm sinh viên
    public (bool Success, string Message) AddStudent(Student student)
    {
        if (!StudentValidator.IsValidName(student.HoTen))
            return (false, "Họ tên không được để trống.");

        if (StudentValidator.IsDuplicateId(_students, student.MaSinhVien))
            return (false, $"Mã sinh viên '{student.MaSinhVien}' đã tồn tại.");

        if (!StudentValidator.IsValidGpa(student.DiemTrungBinh))
            return (false, "Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");

        if (!StudentValidator.IsValidEmail(student.Email))
            return (false, "Email không đúng định dạng.");

        _students.Add(student);
        return (true, "Thêm sinh viên thành công.");
    }

    // 2. Hiển thị danh sách
    public List<Student> GetAll() => _students.ToList();

    // 3. Tìm sinh viên theo mã
    public Student? FindById(string maSinhVien)
    {
        return _students.FirstOrDefault(s =>
            s.MaSinhVien.Equals(maSinhVien, StringComparison.OrdinalIgnoreCase));
    }

    // 4. Tìm gần đúng theo họ tên
    public List<Student> FindByNameApprox(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return new List<Student>();
        return _students
            .Where(s => s.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // 5. Cập nhật sinh viên
    public (bool Success, string Message) UpdateStudent(string maSinhVien, Action<Student> updateAction)
    {
        var student = FindById(maSinhVien);
        if (student is null)
            return (false, $"Không tìm thấy sinh viên có mã '{maSinhVien}'.");

        updateAction(student);
        return (true, "Cập nhật sinh viên thành công.");
    }

    // 6. Xóa sinh viên
    public (bool Success, string Message) DeleteStudent(string maSinhVien)
    {
        var student = FindById(maSinhVien);
        if (student is null)
            return (false, $"Không tìm thấy sinh viên có mã '{maSinhVien}'.");

        _students.Remove(student);
        return (true, "Xóa sinh viên thành công.");
    }

    // 7. Sắp xếp theo họ tên
    public List<Student> SortByName(bool ascending = true)
    {
        return ascending
            ? _students.OrderBy(s => s.HoTen, StringComparer.OrdinalIgnoreCase).ToList()
            : _students.OrderByDescending(s => s.HoTen, StringComparer.OrdinalIgnoreCase).ToList();
    }

    // 8. Sắp xếp theo điểm trung bình
    public List<Student> SortByGpa(bool ascending = true)
    {
        return ascending
            ? _students.OrderBy(s => s.DiemTrungBinh).ToList()
            : _students.OrderByDescending(s => s.DiemTrungBinh).ToList();
    }

    // 9. Hiển thị sinh viên có điểm từ 8 trở lên
    public List<Student> GetStudentsWithGpaFrom(double minGpa = 8)
    {
        return _students.Where(s => s.DiemTrungBinh >= minGpa).ToList();
    }

    // 10. Hiển thị sinh viên có điểm cao nhất
    public List<Student> GetTopGpaStudents()
    {
        if (_students.Count == 0) return new List<Student>();
        double maxGpa = _students.Max(s => s.DiemTrungBinh);
        return _students.Where(s => Math.Abs(s.DiemTrungBinh - maxGpa) < 0.0001).ToList();
    }

    // 11. Tính điểm trung bình toàn bộ sinh viên
    public double GetOverallAverageGpa()
    {
        return _students.Count == 0 ? 0 : _students.Average(s => s.DiemTrungBinh);
    }

    // 12. Thống kê sinh viên theo ngành
    public Dictionary<string, int> GetStatsByMajor()
    {
        return _students
            .GroupBy(s => s.NganhHoc, StringComparer.OrdinalIgnoreCase)
            .OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    // 13. Thống kê sinh viên theo trạng thái học tập
    public Dictionary<StudentStatus, int> GetStatsByStatus()
    {
        return _students
            .GroupBy(s => s.TrangThaiHocTap)
            .OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}
