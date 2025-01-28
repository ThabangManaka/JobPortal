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

            // Check if the password matches
            if (!MatchPasswordHash(passwordText, user.Password))
            {
                Console.WriteLine("Invalid password.");
                return null;
            }

            return user;
        }

        private bool MatchPasswordHash(string passwordText, string storedPassword)
        {
            // Convert the stored Base64 password back to bytes
            var storedPasswordBytes = Convert.FromBase64String(storedPassword);

            using (var hmac = new HMACSHA512())
            {
                // Compute the hash of the provided password
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));

                // Compare the computed hash with the stored hash
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != storedPasswordBytes[i])
                        return false;
                }
            }

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
    }
      
    }

