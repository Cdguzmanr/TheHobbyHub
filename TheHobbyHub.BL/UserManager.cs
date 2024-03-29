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


namespace TheHobbyHub.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials.  Your IP address has been saved.")
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }
    }

    // TODO: When API and Migration handler are fixed, remove Static methods and use the following code instead

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
                                    throw new LoginFailureException("Cannot log in with these credentials.  Your IP address has been saved.");
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



    /**/ // ------------------------------------------------- Static methods ------------------------------------------------- //
    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<HobbyHubEntities> options) : base(options)
        {

        }



        // We need the hability to hash something (password). -- This is the only place on code where hash is used

        public static string GetHash(string password)
        {
            using (var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password); // Takes the string and create a byte array
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes)); //  
            }
        }

        public static int DelteAll()
        {
            using (HobbyHubEntities dc = new HobbyHubEntities())
            {
                dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                return dc.SaveChanges();
            }
        }

        public static int Insert(User user, bool rollback = false)
        {
            // When to use Users o User (Plural or singular) in code?
            // Rule: when theres a dc. Almost alwasy needs Users (plural)


            try
            {
                int results = 0;
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser entity = new tblUser();
                    entity.Id = Guid.NewGuid();
                    //entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.UserName = user.UserName;
                    entity.Password = GetHash(user.Password);

                    // IMPORTANT - BACK FILL THE ID 
                    user.Id = entity.Id;

                    dc.tblUsers.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Login(User user) // Returns true if worked, otherwise false and exceptions 
        {
            // User is loged in if there is a user object in session
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {

                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (HobbyHubEntities dc = new HobbyHubEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserName == user.UserName);
                            if (tblUser != null)
                            {
                                if (tblUser.Password == GetHash(user.Password))
                                {
                                    // Login Successful
                                    user.Id = tblUser.Id;
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Could not login with those credentials. IP Address saved --|=====> ");
                                }
                            }
                            else
                            {
                                throw new LoginFailureException("UserName was not found.");
                            }
                        }

                    }
                    else
                    {
                        throw new LoginFailureException("UserName was not set.");
                    }
                }
                else
                {
                    throw new LoginFailureException("UserName was not set.");
                }
            }
            catch (LoginFailureException)
            {
                throw;
            }

            catch (Exception)
            {

                throw;
            }
        }


        public static void Seed() // Just to hardcode some users to test
        {
            using (HobbyHubEntities dc = new HobbyHubEntities())
            {
                if (!dc.tblUsers.Any())
                {
                    // Hardcord a couple of users with hashed passwords
                    Insert(new User { UserName = "Arosas", Password = "A1234", FirstName = "Alex", LastName = "Rosas", Email = "arosas@gmail.com", PhoneNumber = "1111111111", Image = "none" });
                    Insert(new User { UserName = "User", Password = "Abcd123", FirstName = "User", LastName = "name", Email = "UName@gmail.com", PhoneNumber = "1111111111", Image = "none" });
                    Insert(new User { UserName = "bfoote", Password = "maple", FirstName = "Brian", LastName = "Foote", Email = "bfoote@fvtc.edu", PhoneNumber = "1111111111", Image = "none" });


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

        public static User LoadById(Guid id)
        {
            try
            {


                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(s => s.Id == id);
                    if (user != null)
                    {
                        return new User
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            UserName = user.UserName
                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (HobbyHubEntities dc = new HobbyHubEntities()) //blocked scope
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();


                    //Get the row that we are trying to update
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == user.Id);

                    if (entity != null)
                    {
                        entity.FirstName = user.FirstName;
                        entity.LastName = user.LastName;
                        entity.UserName = user.UserName;

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();

                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public static List<User> Load(Guid? userId = null)
        {
            try
            {
                List<User> list = new List<User>(); //empty list
                using (HobbyHubEntities dc = new HobbyHubEntities())
                {
                    list = dc.tblUsers
                .Where(s => userId == null || s.Id == userId)
                .Select(s => new User
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    UserName = s.UserName
                })
                .ToList();

                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /**/


    }
}
        