using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.PL.Data
{   
    public class HobbyHubEntities : DbContext
    {
        // Create Guid's for each table


        public virtual DbSet<tblAddress> tblAddresses { get; set; }

        public virtual DbSet<tblCompany> tblCompanies { get; set; }

        public virtual DbSet<tblEvent> tblEvents { get; set; }

        public virtual DbSet<tblFriend> tblFriends { get; set; }

        public virtual DbSet<tblHobby> tblHobbies { get; set; }

        public virtual DbSet<tblUser> tblUsers { get; set; }

        public virtual DbSet<tblUserHobby> tblUserHobbies { get; set; }


        // Constructor for HobbyHubEntities using DbContextOptions
        public HobbyHubEntities(DbContextOptions<HobbyHubEntities> options) : base(options)
        {
        }

        // Configure the connection to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        // Simple constructor for HobbyHubEntities
        public HobbyHubEntities()
        {
        }


        // --------------------------------------- old code ---------------------------------------
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            

            

            

           

            

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        */



        // --------------------------------------- New code ---------------------------------------

        protected override void OnModelCreating(ModelBuilder modelBuilder){
                base.OnModelCreating(modelBuilder);

                CreateAddresses(modelBuilder);
                CreateCompanies(modelBuilder);
                CreateEvents(modelBuilder);
                CreateFriends(modelBuilder);
                CreateHobbies(modelBuilder);
                CreateUsers(modelBuilder);
                CreateUserHobbies(modelBuilder);
        }

        private void CreateAddresses(ModelBuilder modelBuilder)
        {
            // Create tblAddress table
            modelBuilder.Entity<tblAddress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblAddre__3214EC073797D4B0");

                entity.ToTable("tblAddress");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            // Implement default data for tblAddress
            List<tblAddress> addresses = new List<tblAddress>
            {
                new tblAddress { Id = Guid.NewGuid(), Address = "123 Main St", City = "Anytown", State = "CA", Zip = "12345" },
                new tblAddress { Id = Guid.NewGuid(), Address = "456 Elm St", City = "Othertown", State = "NY", Zip = "54321" },
                new tblAddress { Id = Guid.NewGuid(), Address = "789 Oak St", City = "Somewhere", State = "TX", Zip = "67890" }
            };

            // Add default data to tblAddress
            modelBuilder.Entity<tblAddress>().HasData(addresses);
        }

        private void CreateCompanies(ModelBuilder modelBuilder)
        {
            // Create tblCompany table
            modelBuilder.Entity<tblCompany>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblCompa__3214EC07F736E848");

                entity.ToTable("tblCompany");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Implement default data for tblCompany
            List<tblCompany> companies = new List<tblCompany>
            {
                new tblCompany { Id = Guid.NewGuid(), CompanyName = "Company A", UserName = "userA", Password = "passwordA", Image = "imageA.jpg" },
                new tblCompany { Id = Guid.NewGuid(), CompanyName = "Company B", UserName = "userB", Password = "passwordB", Image = "imageB.jpg" },
                new tblCompany { Id = Guid.NewGuid(), CompanyName = "Company C", UserName = "userC", Password = "passwordC", Image = "imageC.jpg" }
            };

            // Add default data to tblCompany
            modelBuilder.Entity<tblCompany>().HasData(companies);
        }

        private void CreateEvents(ModelBuilder modelBuilder)
        {
            // Create tblEvent table
            modelBuilder.Entity<tblEvent>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblEvent__3214EC07BF9B1F91");

                entity.ToTable("tblEvent");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
            });


            // Implement default data for tblEvents
            List<tblEvent> events = new List<tblEvent>
            {
                new tblEvent { Id = Guid.NewGuid(), Description = "Event A", Image = "imageA.jpg" },
                new tblEvent { Id = Guid.NewGuid(), Description = "Event B", Image = "imageB.jpg" },
                new tblEvent { Id = Guid.NewGuid(), Description = "Event C", Image = "imageC.jpg" }
            };

            // Add default data to tblEvents
            modelBuilder.Entity<tblEvent>().HasData(events);
        }

        private void CreateFriends(ModelBuilder modelBuilder)
        {
            // Create tblFriend table
            modelBuilder.Entity<tblFriend>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblFrien__3214EC07DE9FD9A3");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            // Implement default data for tblFriends


            // Add default data to tblFriends

        }

        private void CreateHobbies(ModelBuilder modelBuilder)
        {
            // Create tblHobby table
            modelBuilder.Entity<tblHobby>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblHobby__3214EC0783BA9627");

                entity.ToTable("tblHobby");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.HobbyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Implement default data for tblHobbies


            // Add default data to tblHobbies

        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            // Create tblUser table
            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC079D83832D");

                entity.ToTable("tblUser");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Implement default data for tblUsers

            // Add default data to tblUsers

        }

        private void CreateUserHobbies(ModelBuilder modelBuilder)
        {
            // Create tblUserHobby table
            modelBuilder.Entity<tblUserHobby>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__tblUserH__3214EC0736B690FC");

                entity.ToTable("tblUserHobby");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });


            // Implement default data for tblUserHobbies

            // Add default data to tblUserHobbies

        }


        // Hashing function for User and Company passwords
        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }


    }
}


