using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using stackOverflow.ViewModels;
using StackOverflow.ServiceLayer;

namespace StackOverFlowProject.ApiControllers
{
    public class AccountController : ApiController
    {
        IUsersService us;
     public AccountController(IUsersService us)
        {
            this.us = us;
        }
        public string Get(string email)
        {
           if( this.us.GetUsersByEmail(email)!= null)
            {
                return "Found";

            }
            else
            {
                return "Not Found";
            }
               

        }
    }
}
