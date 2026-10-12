using Ex04.StudentManagement.Enums;

namespace Ex04.StudentManagement.Helpers;


/// Lớp hỗ trợ nhập liệu từ console, có kiểm tra và yêu cầu nhập lại khi sai định dạng.

public static class InputHelper
{
    public static string ReadNonEmptyString(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(">> Giá trị không được để trống. Vui lòng nhập lại.");
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input.Trim();
    }

    // Cho phép để trống (dùng cho các trường không bắt buộc như số điện thoại)
    public static string? ReadOptionalString(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
    }

    public static DateTime ReadDate(string prompt)
    {
        DateTime result;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out result))
            {
                if (result > DateTime.Now)
                {
                    Console.WriteLine(">> Ngày sinh không được lớn hơn ngày hiện tại. Vui lòng nhập lại.");
                    continue;
                }
                return result;
            }
            Console.WriteLine(">> Định dạng ngày không hợp lệ (vd: 15/08/2003). Vui lòng nhập lại.");
        }
    }

    public static double ReadDouble(string prompt, double min, double max)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($">> Vui lòng nhập một số từ {min} đến {max}.");
        }
    }

    public static int ReadInt(string prompt, int min, int max)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out result) && result >= min && result <= max)
            {
                return result;
            }
            Console.WriteLine($">> Vui lòng nhập một số nguyên từ {min} đến {max}.");
        }
    }

    public static Gender ReadGender(string prompt)
    {
        while (true)
        {
            Console.Write(prompt + " (0: Nam, 1: Nữ, 2: Khác): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 2)
            {
                return (Gender)choice;
            }
            Console.WriteLine(">> Lựa chọn không hợp lệ. Vui lòng nhập lại.");
        }
    }

    public static StudentStatus ReadStatus(string prompt)
    {
        while (true)
        {
            Console.Write(prompt + " (0: Đang học, 1: Bảo lưu, 2: Đã tốt nghiệp, 3: Thôi học): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 3)
            {
                return (StudentStatus)choice;
            }
            Console.WriteLine(">> Lựa chọn không hợp lệ. Vui lòng nhập lại.");
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt + " (y/n): ");
            string? input = Console.ReadLine()?.Trim().ToLower();
            if (input == "y") return true;
            if (input == "n") return false;
            Console.WriteLine(">> Vui lòng nhập 'y' hoặc 'n'.");
        }
    }

    public static void PauseBeforeContinue()
    {
        Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
        Console.ReadKey();
    }
}
