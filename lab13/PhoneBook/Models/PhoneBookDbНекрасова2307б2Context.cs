using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models;

public partial class PhoneBookDbНекрасова2307б2Context : DbContext
{
    public PhoneBookDbНекрасова2307б2Context()
    {
    }

    public PhoneBookDbНекрасова2307б2Context(DbContextOptions<PhoneBookDbНекрасова2307б2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3HCFBNF\\MSSQLSERVER01;Initial Catalog=PhoneBookDB_НЕКРАСОВА_2307Б2;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC074546F455");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
