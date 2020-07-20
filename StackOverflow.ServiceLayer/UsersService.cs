using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using stackOverflow.ViewModels;
using StackOverflow.Repositories;

using StackOverflow.DomainModel;
using AutoMapper;
using AutoMapper.Configuration;


namespace StackOverflow.ServiceLayer
{
    public interface IUsersService
    {
        int InsertUser(RegisterViewModel uvm);
        void UpdateUserDetails(EditUserViewModel uvm);
        void UpdateUserPassword(EditUserPassword uvm);

        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();

        UserViewModel GetUsersByEmailAndPassword(string email, string password);
        UserViewModel GetUsersByEmail(string email);


    }
   public class UsersService : IUsersService
    {
        IUserRepository ur;
        public UsersService()
        {
            ur = new UsersRepository();
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetUsers()
        {
            List<User> u = ur.GetUsers();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<User>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string email)
        {
           User u = ur.GetUsersByEmail(email).FirstOrDefault();
            UserViewModel uvm = null;

            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnMapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByEmailAndPassword(string email, string password)
        {
            User u = ur.GetUsersByEmailAndPassword(email, SHA256HashGenerator.GenerateHash(password));
            UserViewModel uvm = null;

         if(u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnMapped(); });
                IMapper mapper = config.CreateMapper();
               uvm = mapper.Map<User,UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByUserID(int UserID)
        {
            User u = ur.GetUsersByUserID(UserID);
            UserViewModel uvm = null;

            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnMapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }

        public int InsertUser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, User>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<RegisterViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.InserUser(u);
            int uid = ur.GetLatestUserID();
            return uid;

    }

    public void UpdateUserDetails(EditUserViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserViewModel, User>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserViewModel, User>(uvm);
            ur.UpdateUserDetail(u);
        }

        public void UpdateUserPassword(EditUserPassword uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserViewModel, User>(); cfg.IgnoreUnMapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserPassword, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUserDetail(u);
        }
    }
}
