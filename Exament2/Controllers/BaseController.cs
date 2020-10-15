using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exament2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exament2.Controllers
{
    public class BaseController : Controller
    {
        private readonly PokemonContext context;
        public BaseController(PokemonContext context)
        {
            this.context = context;
        }
        //protected Usuario logeruser()
        //{
        //    var claims = HttpContext.User.Claims.FirstOrDefault();
        //    var user = context.Usuarios.Where(o => o.Username == claims.Value).FirstOrDefault();
        //    return user;
        //}
    }
}
