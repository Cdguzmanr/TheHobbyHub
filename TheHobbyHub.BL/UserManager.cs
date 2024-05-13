﻿using TheHobbyHub.BL.Models;
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
using Humanizer.Localisation;


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
        public UserManager(DbContextOptions<HobbyHubEntities> options) : base(options) { }

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


                    tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserName.Trim() == user.UserName.Trim());

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


        // ----------------------- Method to create List of Hobbys

        private static List<Hobby> ConvertToHobbys(ICollection<tblUserHobby> userhobbys)
        {
            List<Hobby> hobbys = new List<Hobby>();
            foreach (tblUserHobby mg in userhobbys)
            {
                hobbys.Add(new Hobby { Id = mg.HobbyId, Description = mg.Hobby.Description });
            }
            return hobbys;
        }

        private static List<tblUserHobby> ConvertToUserHobbys(User user)
        {
            List<tblUserHobby> userhobbys = new List<tblUserHobby>();
            foreach (Hobby g in user.Hobbys)
            {
                userhobbys.Add(new tblUserHobby { Id = Guid.NewGuid(), UserId = user.Id, HobbyId = g.Id });
            }
            return userhobbys;
        }




        // CRUD methods ------------------------------------------------- //
        public int Insert(User user, bool rollback = false)
        {

            try
            {
                int results = 0;
                using (HobbyHubEntities dc= new HobbyHubEntities(options)) 
                {
                    bool inuse = dc.tblUsers.Any(u => u.UserName.Trim().ToUpper() == user.UserName.Trim().ToUpper());
                    if(inuse && rollback ==false)
                    {

                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser newUser = new tblUser
                        {
                            Id = Guid.NewGuid(),
                            UserName = user.UserName,
                            Password = GetHash(user.Password),
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            Image = user.Image,
                            UserHobbies = ConvertToUserHobbys(user)
                        };
                        user.Id = newUser.Id;
                        dc.tblUsers.Add(newUser);
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                        //return base.Insert(row, rollback);
                    }

                }
                return results;
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

                    UserName = user.UserName,
                    Password = user.Password, // -------------------------------- Deleted the Hashing since it is already hashed and don't want to change it
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Image = user.Image,
                    UserHobbies = ConvertToUserHobbys(user)
                }, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public int Delete(Guid id, bool rollback = false)
        //{
        //    try
        //    {
        //        return base.Delete(id, rollback);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HobbyHubEntities dc = new HobbyHubEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser deleteRow = dc.tblUsers.FirstOrDefault(x => x.Id == id);

                    if (deleteRow != null)
                    {
                        //Delete all the associated tblCompanyUser rows
                        var Companies = dc.tblCompanies.Where(u => u.UserId == id);
                        dc.tblCompanies.RemoveRange(Companies);


                        var Events = dc.tblEvents.Where(u => u.UserId == id);
                        dc.tblEvents.RemoveRange(Events);

                        var Friends = dc.tblFriends.Where(u => u.UserId == id);
                        dc.tblFriends.RemoveRange(Friends);

                        var UserHobby = dc.tblUserHobbies.Where(u => u.UserId == id);
                        dc.tblUserHobbies.RemoveRange(UserHobby);


                        //Remove the users
                        dc.tblUsers.Remove(deleteRow);

                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not Found");
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<User> Load(Guid? hobbyId = null)
        {
            List<User> users = new List<User>();
            try
            {

                base.Load()
                    .Where(uh => uh.UserHobbies.Any(_ => _.HobbyId == hobbyId) || (hobbyId == null))
                    .ToList()
                    .ForEach(user => users.Add(
                        new User()
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Password = GetHash(user.Password),
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            Image = user.Image,
                            Hobbys = ConvertToHobbys(user.UserHobbies.ToList())
                        }));

            }
            catch (Exception)
            {
                throw;
            }
            return users;
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
                        UserName = user.UserName,
                        Password = GetHash(user.Password),
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Image = user.Image,
                        Hobbys = new HobbyManager(options).Load(user.Id)
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
                        UserName = row.UserName,
                        Password = GetHash(row.Password),
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Email = row.Email,
                        PhoneNumber = row.PhoneNumber,
                        Image = row.Image,
                        Hobbys = new HobbyManager(options).Load(row.Id),
                        FriendsList = new FriendsManager(options).Load(row.Id)
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
