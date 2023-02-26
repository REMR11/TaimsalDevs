using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemTaimsalDevs.EL;

public partial class Provider
{
    [Key]
    public int IdProvider { get; set; }

    [StringLength(40)]
    public string NameProvider { get; set; } = null!;

    [InverseProperty("IdProviderNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
    [NotMapped]
    public int Top_Aux { get; set; }
}
