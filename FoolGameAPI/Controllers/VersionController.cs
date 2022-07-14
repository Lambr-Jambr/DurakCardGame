using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FoolGameAPI.Controllers
{
    public class VersionController : ApiController
    {
        public string GetVersion()
        {
            return "0.1";
        }
    }
}