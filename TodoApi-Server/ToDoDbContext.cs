// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

// namespace TodoApi;

// public partial class ToDoDbContext : DbContext
// {
//     public ToDoDbContext()
//     {
//     }

//     public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
//         : base(options)
//     {
//     }

//     // ודאי שזה Items (עם S)
//     public virtual DbSet<Item> Items { get; set; } = null!; 

//     // 💥 שיטת OnConfiguring נמחקה!

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder
//             .UseCollation("utf8mb4_0900_ai_ci")
//             .HasCharSet("utf8mb4");

//         modelBuilder.Entity<Item>(entity => // ודא שזה Items (עם S)
//         {
//             entity.HasKey(e => e.Id).HasName("PRIMARY");

//             entity.ToTable("items"); 

//             entity.Property(e => e.Name).HasMaxLength(100);
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }


using Microsoft.EntityFrameworkCore;

namespace TodoApi;

// ToDoDbContext יורש מ-DbContext, ומשתמש ב-Options לטובת הזרקת תלויות (DI)
public partial class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    // ה-DbSet הנדרש עבור טבלת המשימות
    public virtual DbSet<Item> Items { get; set; } = null!;

    // מתודה זו נדרשת רק אם משתמשים ב-Db First
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            // אלו הגדרות שנוצרות אוטומטית ע"י Scaffolding ורצוי לשמרן
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items"); // ודאו ששם הטבלה הוא 'items' במסד הנתונים

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}