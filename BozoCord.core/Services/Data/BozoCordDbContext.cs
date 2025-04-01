using System;
using Microsoft.EntityFrameworkCore;
using BozoCord.Core.Models.User;
using BozoCord.Core.Models.Server;
using BozoCord.Core.Models.Chat;

namespace BozoCord.Core.Services.Data
{
    public class BozoCordDbContext : DbContext
    {
        public BozoCordDbContext(DbContextOptions<BozoCordDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configurations
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Server configurations
            modelBuilder.Entity<Server>()
                .HasOne(s => s.Owner)
                .WithMany()
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Channel configurations
            modelBuilder.Entity<Channel>()
                .HasOne(c => c.Server)
                .WithMany(s => s.Channels)
                .HasForeignKey(c => c.ServerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Channel>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Message configurations
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Author)
                .WithMany()
                .HasForeignKey(m => m.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Channel)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ReplyToMessage)
                .WithMany()
                .HasForeignKey(m => m.ReplyToMessageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Role configurations
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Server)
                .WithMany(s => s.Roles)
                .HasForeignKey(r => r.ServerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users);

            modelBuilder.Entity<Channel>()
                .HasMany(c => c.AllowedRoles)
                .WithMany();

            // Configure JSON columns
            modelBuilder.Entity<Server>()
                .OwnsOne(s => s.Settings);

            modelBuilder.Entity<Channel>()
                .OwnsOne(c => c.Settings);

            modelBuilder.Entity<Message>()
                .OwnsOne(m => m.Metadata);

            modelBuilder.Entity<Role>()
                .OwnsOne(r => r.Settings);
        }
    }
} 