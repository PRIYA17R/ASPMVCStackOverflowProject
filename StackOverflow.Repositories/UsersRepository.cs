using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using StackOverflow.DomainModel;
using System.Data.Entity.Migrations;

namespace StackOverflow.Repositories
{

    public interface IUserRepository
    {
        void InserUser(User u);
        void UpdateUserDetail(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(User u);
        List<User> GetUsers();

        List<User> GetUsersByEmailAndPassword(string Email, string Password);

        List<User> GetUsersByEmail(string Email);
        User GetUsersByUserID(int UserID);

        int GetLatestUserID();


    }
    public class UsersRepository : IUserRepository
    {
        StackeOverflowDBContext db;
        public UsersRepository()
        {
            db = new StackeOverflowDBContext();

        }

        public void DeleteUser(int uid)
        {
            User u = db.Users.Where(t => t.UserID == uid).FirstOrDefault();

            if (u!= null)
            {
                db.Users.Remove(u);
                db.SaveChanges();
            }
        }

        public int   GetLatestUserID()
        {
          int uid = db.Users.Select(t => t.UserID).Max();
            return uid;
        }

        public List<User> GetUsers()
        {
            List<User> u = db.Users.Where(t=> t.IsAdmin == false).OrderBy(t => t.Name).ToList();
            return u;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            List<User> u = db.Users.Where(t => t.Email == Email).OrderBy(t => t.Name).ToList();
            return u;
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string Password)
        {
            List<User> u = db.Users.Where(t => t.Email == Email && t.PasswordHash == Password).OrderBy(t => t.Name).ToList();
            return u;
        }

        public User GetUsersByUserID(int UserID)
        {
            User u = db.Users.Where(t => t.UserID == UserID).FirstOrDefault();
            return u;
        }

        public void InserUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetail(User u)
        {
            User exstingUser = db.Users.Where(t => t.UserID == u.UserID).FirstOrDefault();

            if(exstingUser!= null)
            {
            exstingUser.Name = u.Name;
            exstingUser.Mobile = u.Mobile;
            exstingUser.IsAdmin = u.IsAdmin;
            exstingUser.PasswordHash = u.PasswordHash;
            db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User exstingUser = db.Users.Where(t => t.UserID == u.UserID).FirstOrDefault();

            if (exstingUser != null)
            {
                exstingUser.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }
    }
}
