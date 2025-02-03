using Dto;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public  class UserRepository : IUserRepository
    {

        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }



     public void Register(Users user)
        {
            try
            {

             
                using (var hmac = new HMACSHA512())
                {

                    user.PasswordSalt = hmac.Key;

                    // Hash the password
                    user.Password = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                }
                // Set creation and modification dates
                user.DateCreated = DateTime.UtcNow;
                user.DateModified = DateTime.UtcNow;

                // Add the user to the context and save changes
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");

                throw;
            }
          }

     public bool CheckUsersExits(string username)
        {
            var result = (from user in _context.Users
                          where user.Username == username
                          select user).Count();

            return result > 0 ? true : false;
        }

    public async Task<Users> Authenticate(string userName, string passwordText)
        {
            // Fetch the user from the database
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);

            if (user == null || string.IsNullOrEmpty(user.Password))
            {
                Console.WriteLine("User not found or password is missing.");
                return null;
            }

            // Validate the password
            if (!VerifyPasswordHash(passwordText, user.Password, user.PasswordSalt))
                return null;

            return user;
        }
    private bool VerifyPasswordHash(string passwordText, string storedPassword, byte[] storedSalt)
    {
      // Ensure that the stored password and salt are not null or empty
      if (string.IsNullOrEmpty(storedPassword) || storedSalt == null || storedSalt.Length == 0)
      {
        return false;
      }

      using (var hmac = new HMACSHA512(storedSalt))
      {
        // Hash the provided password with the stored salt
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));

        // Convert the stored password hash (Base64) to a byte array
        var storedHashBytes = Convert.FromBase64String(storedPassword);

        // If the lengths of the hashes don't match, they are not equal
        if (computedHash.Length != storedHashBytes.Length)
        {
          return false;
        }

        // Compare the computed hash with the stored hash byte by byte
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHashBytes[i])
          {
            return false; // Return false if any byte doesn't match
          }
        }
      }

      // If no mismatches were found, return true
      return true;
    }
    public LoginResDto GetUserDetailsbyCredentials(string username)
        {
            try
            {
                var result = (from user in _context.Users
                                  //join userinrole in _context.UsersInRoles on user.UserId equals userinrole.UserId
                              where user.Username == username

                              select new LoginResDto
                              {
                                  UserId = user.UserId,
                                  Username = user.Username
                              }).SingleOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    public Users GetUsersbyId(int userId)
    {
      var result = (from user in _context.Users
                    where user.UserId == userId
                    select user).FirstOrDefault();

      return result;
    }
  }
      
    }

