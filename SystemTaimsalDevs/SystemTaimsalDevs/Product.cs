﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemTaimsalDevs.EL;

[Table("Product")]
public partial class Product
{
    [Key]
    public int IdProduct { get; set; }

    [StringLength(40)]
    public string NameProduct { get; set; } = null!;

    public string? ImageProduct { get; set; }

    [StringLength(500)]
    public string? DescriptionProduct { get; set; }

    public int? Stock { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
    [NotMapped]
    public int Top_Aux { get; set; }
}
