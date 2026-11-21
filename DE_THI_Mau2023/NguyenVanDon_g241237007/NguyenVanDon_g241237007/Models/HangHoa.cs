using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;


namespace NguyenVanDon_g241237007.Models;

public partial class HangHoa
{
    [Required(ErrorMessage = "Vui long nhap ten hang hoa")]
    public int MaHang { get; set; }
    [Required(ErrorMessage = "Vui long chon loai hang hoa")]
    public int MaLoai { get; set; }
    [Required(ErrorMessage = "Vui long nhap ten hang hoa")]
    public string TenHang { get; set; } = null!;
    [Required(ErrorMessage = "Vui long nhap gia hang hoa")]
    [Range(100,5000, ErrorMessage = "Gia phai la so va nam trong khoang 100 den 5000")]
    public decimal? Gia { get; set; }
    [Required(ErrorMessage = "Vui long nhap anh hang hoa")]
    [RegularExpression(@"^.*\.(jpg|jpeg|png|gif)$", ErrorMessage = "Vui long nhap duoi anh hop le (jpg, jpeg, png, gif)")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
