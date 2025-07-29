using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace payphone.wallet.persistence.Modelos;

[Table("Wallet")]
public partial class Wallet
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("documentId")]
    [StringLength(10)]
    [Unicode(false)]
    public string DocumentId { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("balance", TypeName = "decimal(18, 2)")]
    public decimal Balance { get; set; }

    [Column("state")]
    [StringLength(1)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("locks", TypeName = "decimal(18, 2)")]
    public decimal? Locks { get; set; }

    [Column("calendarAt")]
    public DateTime CalendarAt { get; set; }

    [Column("userCreate")]
    [StringLength(20)]
    [Unicode(false)]
    public string UserCreate { get; set; } = null!;

    [Column("createAt")]
    public DateTime CreateAt { get; set; }

    [Column("userUpdate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? UserUpdate { get; set; }

    [Column("updateAt")]
    public DateTime? UpdateAt { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [ForeignKey("UserCreate")]
    [InverseProperty("WalletUserCreateNavigations")]
    public virtual UserW UserCreateNavigation { get; set; } = null!;

    [ForeignKey("UserUpdate")]
    [InverseProperty("WalletUserUpdateNavigations")]
    public virtual UserW? UserUpdateNavigation { get; set; }

    [InverseProperty("Wallet")]
    public virtual ICollection<WalletMovement> WalletMovements { get; set; } = new List<WalletMovement>();
}
