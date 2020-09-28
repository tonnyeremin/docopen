using System;
using System.Linq;
using DocOpen.Data;
namespace DocOpen.Core
{
    internal class UserCreator
    {
        private readonly IUsersRepository _userRepository;
        public UserCreator(IUsersRepository repository)
        {
            _userRepository = repository;
        }

        internal bool ValidateCreation(User user, out string error)
        {
           try
           {
                error = string.Empty;

                if(_userRepository.Find(u=>u.Email == user.Email).Any())
                    error = "Account with specified email is already exixsts";

                return string.IsNullOrEmpty(error);
           }
           catch(Exception ex)
           {
               throw;
           }
        }

        internal void CreateUser(User user)
        {
           try
           {
                _userRepository.Add(user);
                _userRepository.Commit();
           }
           catch(Exception ex)
           {
               throw;
           }
        }

        internal async void SendActivationEmailAsync(User user)
        {
            try
            {
                var newUser = _userRepository.GetByIt(user.Id);
                if(newUser == null)
                    throw new Exception("User not found");

                if(user.State == EUserState.New)
                {
                    
                }    

            }
            catch(Exception ex)
            {
                throw;          
            }
        }
    }
}