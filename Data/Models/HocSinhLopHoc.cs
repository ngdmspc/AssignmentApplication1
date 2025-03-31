using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("HocSinhLopHoc")]
public partial class HocSinhLopHoc
{
    [Key]
    [Column("HocSinhLopHocID")]
    public int HocSinhLopHocId { get; set; }

    [Column("HocSinhID")]
    public int HocSinhId { get; set; }

    [Column("LopHocID")]
    public int LopHocId { get; set; }

    [ForeignKey("HocSinhId")]
    [InverseProperty("HocSinhLopHocs")]
    public virtual HocSinh HocSinh { get; set; } = null!;

    [ForeignKey("LopHocId")]
    [InverseProperty("HocSinhLopHocs")]
    public virtual LopHoc LopHoc { get; set; } = null!;
}
