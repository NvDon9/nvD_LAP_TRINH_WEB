using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenVanDong_24120707_Mau2026.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    [Display(Name = "MaTL")]
    public int? MaTl { get; set; }

    [Required(ErrorMessage = "Tên sách không được để trống.")]
    [Display(Name = "TenSach")]
    public string? TenSach { get; set; }

    [Required(ErrorMessage = "Giá không được để trống.")]
    [Range(50, 1000, ErrorMessage = "Giá phải là số và nằm trong giới hạn từ 50 đến 1000.")]
    [Display(Name = "Gia")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"(?i)^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .jpeg | .png | .webp")]
    [Required(ErrorMessage = "Tên file ảnh không được để trống.")]
    [Display(Name = "Anh")]
    public string? Anh { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; }
}
