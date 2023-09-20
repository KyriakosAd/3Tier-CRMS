using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using LOGIC.Services.Models.Room;

namespace LOGIC.Services.Implementation
{
    public class User_Service : IUser_Service
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<User_ResultSet>> AddUser(string name, string password, string email, string department, string role)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                User User = new User
                {
                    User_Name = name,
                    User_Password = password,
                    User_Email = email,
                    User_Department = department,
                    User_Role = role
                };

                User = await _crud.Create<User>(User);

                User_ResultSet userAdded = new User_ResultSet
                {
                    id = User.User_ID,
                    name = User.User_Name,
                    password = User.User_Password,
                    email = User.User_Email,
                    department = User.User_Department,
                    role = User.User_Role
                };

                result.userMessage = string.Format("The provided user {0} was added successfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: AddUser() method executed successfully.";
                result.result_set = userAdded;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the user provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: AddUser(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers()
        {
            Generic_ResultSet<List<User_ResultSet>> result = new Generic_ResultSet<List<User_ResultSet>>();
            try
            {
                List<User> Users = await _crud.ReadAll<User>();

                result.result_set = new List<User_ResultSet>();
                Users.ForEach(du => {
                    result.result_set.Add(new User_ResultSet {
                        id = du.User_ID,
                        name = du.User_Name,
                        password = du.User_Password,
                        email = du.User_Email,
                        department = du.User_Department,
                        role = du.User_Role
                    });
                });

                result.userMessage = string.Format("All users obtained successfully.");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetAllUsers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to fetch all the required users from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetAllUsers(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<User_ResultSet>> GetUserById(int id)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                User User = await _crud.Read<User>(id);

                if (User == null)
                {
                    throw new Exception();
                }

                User_ResultSet userReturned = new User_ResultSet
                {
                    id = User.User_ID,
                    name = User.User_Name,
                    password = User.User_Password,
                    email = User.User_Email,
                    department = User.User_Department,
                    role = User.User_Role
                };

                result.userMessage = string.Format("User {0} was found successfully.", userReturned.name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetUserById() method executed successfully.";
                result.result_set = userReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the user provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetUserById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<User_ResultSet>> UpdateUser(int id, string name, string password, string email, string department, string role)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                User User = new User
                {
                    User_ID = id,
                    User_Name = name,
                    User_Password = password,
                    User_Email = email,
                    User_Department = department,
                    User_Role = role
                };

                User = await _crud.Update<User>(User, id);

                if (User == null)
                {
                    throw new Exception();
                }

                User_ResultSet userUpdated = new User_ResultSet
                {
                    id = User.User_ID,
                    name = User.User_Name,
                    password = User.User_Password,
                    email = User.User_Email,
                    department = User.User_Department,
                    role = User.User_Role
                };

                result.userMessage = string.Format("The provided user {0} was updated successfully.", name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: UpdateUser() method executed successfully.";
                result.result_set = userUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to register your information for the user provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: UpdateUser(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteUser(int id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                bool userDeleted = await _crud.Delete<User>(id);

                if (!userDeleted)
                {
                    throw new Exception();
                }

                result.userMessage = string.Format("The user with ID {0} was deleted successfully.", id);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: DeleteUser() method executed successfully.";
                result.result_set = userDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to find the user provided. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: DeleteUser(): {0}", exception.Message);
            }
            return result;
        }
    }
}
