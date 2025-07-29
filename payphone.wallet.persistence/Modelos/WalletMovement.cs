using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace payphone.wallet.persistence.Modelos;

[Table("WalletMovement")]
public partial class WalletMovement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("walletId")]
    public int WalletId { get; set; }

    [Column("amount", TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [Column("type")]
    [StringLength(1)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [Column("available", TypeName = "decimal(18, 2)")]
    public decimal Available { get; set; }

    [Column("calendarAt")]
    public DateTime CalendarAt { get; set; }

    [Column("userCreate")]
    [StringLength(20)]
    [Unicode(false)]
    public string UserCreate { get; set; } = null!;

    [Column("createAt")]
    public DateTime CreateAt { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("document")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Document { get; set; }

    [ForeignKey("UserCreate")]
    [InverseProperty("WalletMovements")]
    public virtual UserW UserCreateNavigation { get; set; } = null!;

    [ForeignKey("WalletId")]
    [InverseProperty("WalletMovements")]
    public virtual Wallet Wallet { get; set; } = null!;
}
