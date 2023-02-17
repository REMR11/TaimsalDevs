using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemTaimsalDevs.EL.Models;

[Table("Machine")]
public partial class Machine
{
    [Key]
    public int IdMachine { get; set; }

    [StringLength(30)]
    public string NameMachine { get; set; } = null!;

    public string? ImageMachine { get; set; }

    [InverseProperty("IdMachineNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
