using Interfaces;
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

        }
      
    }

