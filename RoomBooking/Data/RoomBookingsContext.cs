using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RoomBooking.Models;

namespace RoomBooking.Data
{
    public partial class RoomBookingsContext : DbContext
    {
        public RoomBookingsContext()
        {
        }

        public RoomBookingsContext(DbContextOptions<RoomBookingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomUser> RoomUser { get; set; }
        public virtual DbSet<UserCred> UserCred { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QOB7SIN\\FREEINVOICEDB;Initial Catalog=RoomBookings;Integrated Security=True;User ID=sa;Password=***********");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__Bookings__73951ACD4E3D420A");

                entity.HasIndex(e => new { e.StartTime, e.EndTime, e.RoomId })
                    .HasName("UN_Bookings")
                    .IsUnique();

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomUserId).HasColumnName("RoomUserID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Room");

                entity.HasOne(d => d.RoomUser)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_RoomUser");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomName).HasMaxLength(80);
            });

            modelBuilder.Entity<RoomUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__RoomUser__1788CCACEE717697");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(120);
            });

            modelBuilder.Entity<UserCred>(entity =>
            {
                entity.HasKey(e => e.CredId)
                    .HasName("PK__UserCred__9417227D749A4436");

                entity.Property(e => e.CredId).HasColumnName("CredID");

                entity.Property(e => e.CredHash).HasMaxLength(512);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCred)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCred_RoomUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
