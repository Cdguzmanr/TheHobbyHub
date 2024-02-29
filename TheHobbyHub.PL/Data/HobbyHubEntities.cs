using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.PL.Data
{   
    public class HobbyHubEntities : DbContext
    {
        // Create Guid's for each table

        /*
        Todo: Add foreign keys to the tables. See example from DVDCentralEntities.cs below:

                entity.HasOne(d => d.Director).WithMany(p => p.tblMovies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblMovie_DirectorId");

                entity.HasOne(d => d.Format).WithMany(p => p.tblMovies)
                    .HasForeignKey(d => d.FormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblMovie_FormatId");

                entity.HasOne(d => d.Rating).WithMany(p => p.tblMovies)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tblMovie_RatingId");
         */

        Guid[] addressId = new Guid[3];
        Guid[] companyId = new Guid[3];
        Guid[] hobbyId = new Guid[3];
        Guid[] userId = new Guid[3];
        Guid[] eventId = new Guid[3];
        //Guid[] userHobbyId = new Guid[3];
       // Guid[] friendId = new Guid[3];


        public virtual DbSet<tblAddress> tblAddresses { get; set; }

        public virtual DbSet<tblCompany> tblCompanies { get; set; }

        public virtual DbSet<tblEvent> tblEvents { get; set; }

        public virtual DbSet<tblFriend> tblFriends { get; set; }

        public virtual DbSet<tblHobby> tblHobbies { get; set; }

        public virtual DbSet<tblUser> tblUsers { get; set; }

        public virtual DbSet<tblUserHobby> tblUserHobbies { get; set; }

        public virtual DbSet<tblEventHobby> tblEventHobbies { get; set; }

        public virtual DbSet<tblEventUser> tblEventUsers { get; set; }

       // public virtual DbSet<tblEventCompany> tblEventCompanies { get; set; }

        public virtual DbSet<tblEventAddress> tblEventAddresses { get; set; }

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

        // OnModelCreating method to create the tables and implement default data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateAddresses(modelBuilder);
            CreateCompanies(modelBuilder);
            CreateEvents(modelBuilder);
            CreateFriends(modelBuilder);
            CreateHobbies(modelBuilder);
            CreateUsers(modelBuilder);
            CreateUserHobbies(modelBuilder);
            CreateEventHobbies(modelBuilder);

            CreateEventUsers(modelBuilder);

            CreateEventAddresses(modelBuilder);
            //CreateEventCompanies(modelBuilder);
        }

        private void CreateAddresses(ModelBuilder modelBuilder)
        {
           // for (int i = 0; i < addressId.Length; i++)
             //   addressId[i] = Guid.NewGuid();


            // Create tblAddress table
            modelBuilder.Entity<tblAddress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblAddress_Id");

                entity.ToTable("tblAddress");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(12)
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

            for (int i = 0; i < companyId.Length; i++)
                companyId[i] = Guid.NewGuid();

            // Create tblCompany table
            modelBuilder.Entity<tblCompany>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblCompany_Id");

                entity.ToTable("tblCompany");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
               .WithMany(p => p.Companies)
               .HasForeignKey(d => d.AddressId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("fk_tblCompany_AddressId");

            });

            // Implement default data for tblCompany
            List<tblCompany> companies = new List<tblCompany>
            {
                new tblCompany {    Id = companyId[0], 
                                    CompanyName = "Company A", 
                                    UserName = "copanyA", 
                                    Password = GetHash("passwordA"), 
                                    Image = "imageA.jpg" , 
                                    AddressId = addressId[0]},

                new tblCompany {    Id = companyId[1],
                                    CompanyName = "Company B", 
                                    UserName = "companyB", 
                                    Password = GetHash("passwordB"),
                                    Image = "imageB.jpg", 
                                    AddressId = addressId[1] },

                new tblCompany {    Id = companyId[2], 
                                    CompanyName = "Company C", 
                                    UserName = "companyC", 
                                    Password = GetHash("passwordC"), 
                                    Image = "imageC.jpg", 
                                    AddressId = addressId[2] }
            };

            // Add default data to tblCompany
            modelBuilder.Entity<tblCompany>().HasData(companies);
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
            {
                userId[i] = Guid.NewGuid();
            }

            // Create tblUser table
            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUser_Id");

                entity.ToTable("tblUser");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false);
                entity.Property(e => e.LastName).IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Implement default data for tblUsers
            // Todo: Add default data to tblUsers

            List<tblUser> users = new List<tblUser>
            {
                new tblUser { Id = userId[0],
                              FirstName = "Alex",
                              LastName = "Rosas",
                              Email = "Alexr@gmail.com",
                              UserName = "Arosas",
                              Image = "image.jpg",
                              PhoneNumber ="2627459097",
                              Password = GetHash("test")},

              new tblUser { Id = userId[1],
                              FirstName = "Someone",
                              LastName = "Somebody",
                              Email = "ss@gmail.com",
                              UserName = "SSM",
                              Image = "image.jpg",
                              PhoneNumber ="3333333333",
                              Password = GetHash("ssm")},

                new tblUser { Id = userId[2],
                              FirstName = "sam",
                              LastName = "fisher",
                              Email = "sf@gmail.com",
                              UserName = "sammyfish",
                              Image = "sammy.jpg",
                              PhoneNumber ="1111111111",
                              Password = GetHash("test")
                }
            };

            // Add default data to tblUsers
            modelBuilder.Entity<tblUser>().HasData(users);
        }

        private void CreateEvents(ModelBuilder modelBuilder)
        {

            for (int i = 0; i < eventId.Length; i++)
                eventId[i] = Guid.NewGuid();
            // Create tblEvent table
            modelBuilder.Entity<tblEvent>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblEvent_Id"); 

                entity.ToTable("tblEvent");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Date).HasColumnType("datetime");

                // entity.HasOne(d => d.Address)
                //.WithMany(p => p.Events)
                //.HasForeignKey(d => d.AddressId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("fk_tblEvent_AddressId");

                //  entity.HasOne(d => d.User)
                //.WithMany(p => p.Events)
                //.HasForeignKey(d => d.UserId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("fk_tblEvent_UserId");


                entity.HasOne(d => d.Company)
               .WithMany(p => p.Events)
               .HasForeignKey(d => d.CompanyId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("fk_tblEvent_CompanyId");

                // entity.HasOne(d => d.Hobby)
                //.WithMany(p => p.Events)
                //.HasForeignKey(d => d.HobbyId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("fk_tblEvent_HobbyId");

            });


            // Implement default data for tblEvents
            List<tblEvent> events = new List<tblEvent>
            {
                new tblEvent {  Id = eventId[0],
                                //AddressId = addressId[0], 
                                //UserId= userId[0], 
                                CompanyId = companyId[0], 
                                //HobbyId = hobbyId[0],
                                Description = "Event A",
                                Image = "imageA.jpg",  
                                Date = new DateTime(2024, 2, 15) 
                },

                 new tblEvent {  Id = eventId[1],
                                //AddressId = addressId[1],
                                //UserId= userId[1],
                                CompanyId = companyId[1],
                                //HobbyId = hobbyId[1],
                                Description = "Event B",
                                Image = "imageB.jpg",
                                Date = new DateTime(2024, 2, 15) 
                 },

                  new tblEvent {  Id = eventId[2],
                               // AddressId = addressId[2],
                                //UserId= userId[2],
                                CompanyId = companyId[2],
                                //HobbyId = hobbyId[2],
                                Description = "Event C",
                                Image = "imageC.jpg",
                                Date = new DateTime(2024, 2, 15) }
            };

            // Add default data to tblEvents
            modelBuilder.Entity<tblEvent>().HasData(events);
        }

        private void CreateFriends(ModelBuilder modelBuilder)
        {

           

            // Create tblFriend table
            modelBuilder.Entity<tblFriend>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblFriend_Id");


                entity.ToTable("tblFriend");

                entity.Property(e => e.Id).ValueGeneratedNever();


                entity.HasOne(d => d.User)
             .WithMany(p => p.Friends)
             .HasForeignKey(d => d.UserId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_tblFriend_UserId");

                entity.HasOne(d => d.Company)
              .WithMany(p => p.Friends)
              .HasForeignKey(d => d.CompanyId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("fk_tblFriend_CompanyId");


            });

            // Implement default data for tblFriends
            // Todo: Add default data to tblFriends

            List<tblFriend> friends = new List<tblFriend>
            {
            new tblFriend
            {
                Id = Guid.NewGuid(),
                UserId = userId[0],
                CompanyId = companyId[0],
            },

            new tblFriend
            {
                Id = Guid.NewGuid(),
                UserId = userId[1],
                CompanyId = companyId[1],
            },

            new tblFriend
            {
                Id = Guid.NewGuid(),
                UserId = userId[2],
                CompanyId = companyId[2],
            }

            };

            // Add default data to tblFriends

            modelBuilder.Entity<tblFriend>().HasData(friends);

        }

        private void CreateHobbies(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < hobbyId.Length; i++)
                hobbyId[i] = Guid.NewGuid();

            // Create tblHobby table
            modelBuilder.Entity<tblHobby>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblHobby_Id");

                entity.ToTable("tblHobby");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description).IsUnicode(false)
                .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.HobbyName).IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Image).IsUnicode(false)
                .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            // Implement default data for tblHobbies
            // Todo: Add default data to tblHobbies


            List<tblHobby> hobbies = new List<tblHobby>
            {

                new tblHobby
                {
                    Id = hobbyId[0],
                    HobbyName = "Gym",
                    Description = "Gyyymm",
                    Type ="Indoor",
                    Image = "image.jpg",
                },
                 new tblHobby
                {
                    Id = hobbyId[1],
                    HobbyName = "Golf",
                    Description = "stick",
                    Type ="outdoor",
                    Image = "outdoor.jpg",
                },
                  new tblHobby
                {
                    Id = hobbyId[2],
                    HobbyName = "Running",
                    Description = "Run",
                    Type ="Outdoor",
                    Image = "run.jpg",
                }

            };

            // Add default data to tblHobbies

            modelBuilder.Entity<tblHobby>().HasData(hobbies);

        }


        private void CreateUserHobbies(ModelBuilder modelBuilder)
        {
            // Create tblUserHobby table
            modelBuilder.Entity<tblUserHobby>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUserHobby_Id");

                entity.ToTable("tblUserHobby");

                entity.Property(e => e.Id).ValueGeneratedNever();


                entity.HasOne(d => d.User)
             .WithMany(p => p.UserHobbies)
             .HasForeignKey(d => d.UserId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_tblUserHobby_UserId");

                entity.HasOne(d => d.Hobby)
              .WithMany(p => p.UserHobbies)
              .HasForeignKey(d => d.HobbyId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("fk_tblUserHobby_HobbyId");

            });
            // Implement default data for tblUserHobbies
            // Todo: Add default data to tblUserHobbies

            List<tblUserHobby> userHobbies = new List<tblUserHobby>
            {
            new tblUserHobby
            {
                Id = Guid.NewGuid(),
                UserId = userId[0],
                HobbyId = hobbyId[0],
            },

             new tblUserHobby
            {
                Id = Guid.NewGuid(),
                UserId = userId[1],
                HobbyId = hobbyId[1],
            },

              new tblUserHobby
            {
                Id = Guid.NewGuid(),
                UserId = userId[2],
                HobbyId = hobbyId[2]}
            };

            // Add default data to tblUserHobbies
            modelBuilder.Entity<tblUserHobby>().HasData(userHobbies);
        }

        private void CreateEventHobbies(ModelBuilder modelBuilder)
        {

            // Create tblFriend table
            modelBuilder.Entity<tblEventHobby>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblEventHobby_Id");


                entity.ToTable("tblEventHobby");

                entity.Property(e => e.Id).ValueGeneratedNever();


                entity.HasOne(d => d.Events)
             .WithMany(p => p.EventHobbies)
             .HasForeignKey(d => d.EventId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_tblEventHobby_EventId");

                entity.HasOne(d => d.Hobbies)
              .WithMany(p => p.EventHobbies)
              .HasForeignKey(d => d.HobbyId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("fk_tblEventHobby_HobbyId");


            });

            // Implement default data for tblFriends
            // Todo: Add default data to tblFriends

            List<tblEventHobby> eventhobbies = new List<tblEventHobby>
            {
            new tblEventHobby
            {
                Id = Guid.NewGuid(),
                HobbyId = hobbyId[0],
                EventId = eventId[0],
            },

            new tblEventHobby
            {
                Id = Guid.NewGuid(),
                HobbyId = hobbyId[1],
                EventId = eventId[1],
            },

            new tblEventHobby
            {
                Id = Guid.NewGuid(),
                HobbyId = hobbyId[2],
                EventId = eventId[2],
            }

            };

            // Add default data to tblFriends

            modelBuilder.Entity<tblEventHobby>().HasData(eventhobbies);

        }

        private void CreateEventUsers(ModelBuilder modelBuilder)
        {

            // Create tblFriend table
            modelBuilder.Entity<tblEventUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblEventUser_Id");


                entity.ToTable("tblEventUser");

                entity.Property(e => e.Id).ValueGeneratedNever();


                entity.HasOne(d => d.Events)
             .WithMany(p => p.EventUsers)
             .HasForeignKey(d => d.EventId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_tblEventUser_EventId");

                entity.HasOne(d => d.Users)
              .WithMany(p => p.EventUsers)
              .HasForeignKey(d => d.UserId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("fk_tblEventUser_UserId");


            });

            // Implement default data for tblFriends
            // Todo: Add default data to tblFriends

            List<tblEventUser> evenusers = new List<tblEventUser>
            {
            new tblEventUser
            {
                Id = Guid.NewGuid(),
                UserId = userId[0],
                EventId = eventId[0],
            },

            new tblEventUser
            {
                Id = Guid.NewGuid(),
                UserId = userId[1],
                EventId = eventId[1],
            },

            new tblEventUser
            {
                Id = Guid.NewGuid(),
                UserId = userId[2],
                EventId = eventId[2],
            }

            };

            // Add default data to tblFriends

            modelBuilder.Entity<tblEventUser>().HasData(evenusers);

        }

        private void CreateEventAddresses(ModelBuilder modelBuilder)
        {

            // Create tblFriend table
            modelBuilder.Entity<tblEventAddress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblEventAddress_Id");


                entity.ToTable("tblEventAddress");

                entity.Property(e => e.Id).ValueGeneratedNever();


                entity.HasOne(d => d.Events)
             .WithMany(p => p.EventAddresses)
             .HasForeignKey(d => d.EventId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_tblEventAddress_EventId");

                entity.HasOne(d => d.Addresses)
              .WithMany(p => p.EventAddresses)
              .HasForeignKey(d => d.AddressId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("fk_tblEventAddress_AddressId");


            });

            // Implement default data for tblFriends
            // Todo: Add default data to tblFriends

            List<tblEventAddress> eventAddresses = new List<tblEventAddress>
            {
            new tblEventAddress
            {
                Id = Guid.NewGuid(),
                AddressId = addressId[0],
                EventId = eventId[0],
            },

            new tblEventAddress
            {
                Id = Guid.NewGuid(),
                AddressId = addressId[1],
                EventId = eventId[1],
            },

            new tblEventAddress
            {
                Id = Guid.NewGuid(),
                AddressId = userId[2],
                EventId = eventId[2],
            }

            };

            // Add default data to tblFriends

            modelBuilder.Entity<tblEventAddress>().HasData(eventAddresses);

        }

        //private void CreateEventCompanies(ModelBuilder modelBuilder)
        //{

        //    // Create tblFriend table
        //    modelBuilder.Entity<tblEventCompany>(entity =>
        //    {
        //        entity.HasKey(e => e.Id).HasName("tblEventCompany");


        //        entity.ToTable("tblEventCompany");

        //        entity.Property(e => e.Id).ValueGeneratedNever();


        //        entity.HasOne(d => d.Events)
        //     .WithMany(p => p.EventCompany)
        //     .HasForeignKey(d => d.EventId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .HasConstraintName("fk_tblEventCompany_CompanyId");

        //        entity.HasOne(d => d.Companies)
        //      .WithMany(p => p.EventCompany)
        //      .HasForeignKey(d => d.CompanyId)
        //      .OnDelete(DeleteBehavior.ClientSetNull)
        //      .HasConstraintName("fk_tblEventCompany_CompanyId");


        //    });

        //    // Implement default data for tblFriends
        //    // Todo: Add default data to tblFriends

        //    List<tblEventCompany> eventCompanies= new List<tblEventCompany>
        //    {
        //    new tblEventCompany
        //    {
        //        Id = Guid.NewGuid(),
        //        CompanyId = companyId[0],
        //        EventId = eventId[0],
        //    },

        //    new tblEventCompany
        //    {
        //        Id = Guid.NewGuid(),
        //        CompanyId = companyId[1],
        //        EventId = eventId[1],
        //    },

        //    new tblEventCompany
        //    {
        //        Id = Guid.NewGuid(),
        //        CompanyId = companyId[2],
        //        EventId = eventId[2],
        //    }

        //    };

        //    // Add default data to tblFriends

        //    modelBuilder.Entity<tblEventCompany>().HasData(eventCompanies);

        //}

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


