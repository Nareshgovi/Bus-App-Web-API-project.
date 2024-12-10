using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tb3.models.Entity;

namespace tb3.Data;

public partial class TkContext : DbContext
{
    public TkContext()
    {
    }

    public TkContext(DbContextOptions<TkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CreateTicket> CreateTickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CreateTicket>(entity =>
        {
            entity.HasKey(e => e.BusNo).HasName("PK__CreateTi__6A0F3A41C6C6B709");

            entity.ToTable("CreateTicket");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
