using System.Text.RegularExpressions;
using Ex04.StudentManagement.Models;

namespace Ex04.StudentManagement.Validators;

/// <summary>
/// Chịu trách nhiệm kiểm tra các quy tắc nghiệp vụ liên quan đến Student.
/// </summary>
public static class StudentValidator
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled);

    public static bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);
    }

    public static bool IsValidGpa(double gpa)
    {
        return gpa >= 0 && gpa <= 10;
    }

    public static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    /// <summary>
    /// Kiểm tra mã sinh viên đã tồn tại trong danh sách hay chưa.
    /// </summary>
    public static bool IsDuplicateId(List<Student> students, string maSinhVien, string? excludeId = null)
    {
        return students.Any(s =>
            s.MaSinhVien.Equals(maSinhVien, StringComparison.OrdinalIgnoreCase) &&
            (excludeId == null || !s.MaSinhVien.Equals(excludeId, StringComparison.OrdinalIgnoreCase)));
    }

    public static bool Exists(List<Student> students, string maSinhVien)
    {
        return students.Any(s => s.MaSinhVien.Equals(maSinhVien, StringComparison.OrdinalIgnoreCase));
    }
}
