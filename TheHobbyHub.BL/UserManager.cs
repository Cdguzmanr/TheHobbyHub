using TheHobbyHub.BL.Models;
using TheHobbyHub.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



using TheHobbyHub.BL.Models;
using TheHobbyHub.PL.Entities;


namespace TheHobbyHub.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials.  Your IP user has been saved.")
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }
    }

    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }

        // User only Methods

        public string GetHash(string password)
        {
            using (var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password); // Takes the string and create a byte array
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes)); //  
            }
        }


        public bool Login(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                throw new LoginFailureException("UserName is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new LoginFailureException("Password is required.");
            }

            try
            {
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserName == user.UserName);
                    if (tblUser == null)
                    {
                        throw new LoginFailureException("User not found.");
                    }

                    if (tblUser.Password != GetHash(user.Password))
                    {
                        throw new LoginFailureException("Incorrect password.");
                    }

                    // Login Successful
                    user.Id = tblUser.Id;
                    user.FirstName = tblUser.FirstName;
                    user.LastName = tblUser.LastName;
                    return true;
                }
            }
            catch (LoginFailureException)
            {
                throw; // Re-throwing custom exceptions to maintain error messages
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Exception during login: {ex.Message}");
                throw new LoginFailureException("An unexpected error occurred.");
            }
        }

        public void Seed() // Just to hardcode some users to test
        {
            using (HobbyHubEntities dc = new HobbyHubEntities(options))
            {
                if (!dc.tblUsers.Any())
                {
                    // Hardcord a couple of users with hashed passwords
                    Insert(new User { UserName = "Arosas", Password = "A1234", FirstName = "Alex", LastName = "Rosas", Email = "arosas@gmail.com", PhoneNumber = "1111111111", Image = "none" });
                    Insert(new User { UserName = "User", Password = "Abcd123", FirstName = "User", LastName = "name", Email = "UName@gmail.com", PhoneNumber = "1111111111", Image = "none" });
                    Insert(new User { UserName = "bfoote", Password = "maple", FirstName = "Brian", LastName = "Foote", Email = "bfoote@fvtc.edu", PhoneNumber = "1111111111", Image = "none" });

                    // ---------- Old way of inserting users ---------------- //
                    //User user = new User
                    //{
                    //    UserName = "kfrog",
                    //    FirstName = "Kermit",
                    //    LastName = "The frog",
                    //    Password = "misspiggy"
                    //};
                    //Insert(user);

                    //user = new User
                    //{
                    //    UserName = "bfoote",
                    //    FirstName = "Brian",
                    //    LastName = "Foote",
                    //    Password = "maple"
                    //};
                    //Insert(user);

                }
            }
        }


        public int DelteAll()
        {
            using (HobbyHubEntities dc = new HobbyHubEntities())
            {
                dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                return dc.SaveChanges();
            }
        }



        // CRUD methods ------------------------------------------------- //
        public int Insert(User user, bool rollback = false)
        {
            try
            {
                tblUser row = new tblUser();
                row.Id = Guid.NewGuid();
                row.FirstName = user.FirstName;
                row.LastName = user.LastName;
                row.UserName = user.UserName;
                row.Password = GetHash(user.Password);


                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(User user, bool rollback = false)
        {
            try
            {
                return base.Update(new tblUser
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = GetHash(user.Password),
            }, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> Load()
        {
            try
            {
                List<User> rows = new List<User>();
                base.Load()
                .ForEach(user => rows.Add(
                    new User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        Password = GetHash(user.Password),
                    }));
                return rows;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User LoadById(Guid id)
        {
            try
            {
                tblUser row = base.LoadById(id);

                if (row != null)
                {
                    User user = new User
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        UserName = row.UserName,
                        Password = GetHash(row.Password),
                    };
                    return user;
                }
                else
                {
                    throw new Exception("Row was not found.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    /**/


    // ------------------------------------------------- Non Static methods ------------------------------------------------- //
    /**
    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<HobbyHubEntities> options) : base(options) { }


        private string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

        // Regular Seed method
        public void Seed()
        {
            List<User> users = Load();

            foreach (User user in users)
            {
                if (user.Password.Length != 28)
                {
                    Update(user);
                }
            }

            if (users.Count == 0)
            {
                // Hardcord a couple of users with hashed passwords
                Insert(new User { UserName = "Arosas", Password="A1234", FirstName = "Alex", LastName = "Rosas", Email = "arosas@gmail.com", PhoneNumber = "1111111111", Image ="none"});
                Insert(new User { UserName = "User", Password = "Abcd123", FirstName = "User", LastName = "name", Email = "UName@gmail.com", PhoneNumber = "1111111111", Image = "none" });
                Insert(new User { UserName = "bfoote", Password = "maple", FirstName = "Brian", LastName = "Foote", Email = "bfoote@fvtc.edu", PhoneNumber = "1111111111", Image = "none" });
            }
        }

        public bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (HobbyHubEntities dc = new HobbyHubEntities(options))
                        {
                            tblUser userrow = dc.tblUsers.FirstOrDefault(u => u.UserName == user.UserName);

                            if (userrow != null)
                            {
                                // check the password
                                if (userrow.Password == GetHash(user.Password))
                                {
                                    // Login was successfull
                                    user.Id = userrow.Id;
                                    user.UserName = userrow.UserName;
                                    user.Password = userrow.Password;
                                    user.FirstName = userrow.FirstName;
                                    user.LastName = userrow.LastName;
                                    user.Email = userrow.Email;
                                    user.PhoneNumber = userrow.PhoneNumber;
                                    user.Image = userrow.Image;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Cannot log in with these credentials.  Your IP user has been saved.");
                                }
                            }
                            else
                            {
                                throw new Exception("User could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<User> Load()
        {
            try
            {
                List<User> users = new List<User>();

                base.Load()
                    .ForEach(u => users
                    .Add(new User
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Password = u.Password,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        PhoneNumber = u.PhoneNumber,
                        Image = u.Image
                    }));

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User LoadById(Guid id)
        {
            try
            {

                tblUser row = base.LoadById(id);

                if (row != null)
                {
                    User company = new User
                    {
                        Id = row.Id,
                        UserName = row.UserName,
                        Password = row.Password,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Email = row.Email,
                        PhoneNumber = row.PhoneNumber,
                        Image = row.Image
                    };
                    return company;
                }
                else
                {
                    throw new Exception("Row was not found.");
                }
            //  ---------------------
            /* Old method
*                User user = new User();

            using (HobbyHubEntities dc = new HobbyHubEntities())
            {
                user = (from u in dc.tblUsers
                        where u.Id == id
                        select new User
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            Password = u.Password,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            PhoneNumber = u.PhoneNumber,
                            Image = u.Image

                        }).FirstOrDefault();
            }

            return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    // Check if username already exists - do not allow ....
                    bool inuse = dc.tblUsers.Any(u => u.UserName.Trim().ToUpper() == user.UserName.Trim().ToUpper());

                    if (inuse && rollback == false)
                    {
                        //throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser newUser = new tblUser();

                        newUser.Id = Guid.NewGuid();
                        newUser.UserName = user.UserName.Trim();
                        newUser.Password = user.Password.Trim();
                        newUser.FirstName = user.FirstName.Trim();
                        newUser.LastName = user.LastName.Trim();
                        newUser.Email = user.Email.Trim();
                        newUser.Image = user.Image.Trim();
                        newUser.PhoneNumber = user.PhoneNumber.Trim();

                        user.Id = newUser.Id;

                        dc.tblUsers.Add(newUser);

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    // Check if username already exists - do not allow ....
                    tblUser existingUser = dc.tblUsers.Where(u => u.UserName.Trim().ToUpper() == user.UserName.Trim().ToUpper()).FirstOrDefault();

                    if (existingUser != null && existingUser.Id != user.Id && rollback == false)
                    {
                        throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser upDateRow = dc.tblUsers.FirstOrDefault(r => r.Id == user.Id);

                        if (upDateRow != null)


                        {
                            upDateRow.UserName = user.UserName.Trim();
                            upDateRow.Password = GetHash(user.Password.Trim());
                            upDateRow.FirstName = user.FirstName.Trim();
                            upDateRow.LastName = user.LastName.Trim();
                            upDateRow.Email = user.Email.Trim();
                            upDateRow.Image = user.Image.Trim();

                            dc.tblUsers.Update(upDateRow);

                            // Commit the changes and get the number of rows affected
                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    // Check if user is associated with an exisiting order - do not allow delete ....
                  // bool inuse = dc.tbl.Any(o => o.UserId == id);

                   // if (inuse)
                   // {
                   //     throw new Exception("This user is associated with an existing account and therefore cannot be deleted.");
                   // }
                    //else
                    //{
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser deleteRow = dc.tblUsers.FirstOrDefault(r => r.Id == id);

                        if (deleteRow != null)
                        {
                            dc.tblUsers.Remove(deleteRow);

                            // Commit the changes and get the number of rows affected
                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                   // }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
    **/
}
