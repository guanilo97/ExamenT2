using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Exament2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Exament2.Controllers
{
    public class PokemonController : BaseController
    {
        private PokemonContext _context;
        public IHostEnvironment _hostEnv;
        public PokemonController(PokemonContext context, IHostEnvironment hostEnv) : base(context)
        {
            _context = context;
            _hostEnv = hostEnv;
        }
        public ActionResult Index()
        {
            ViewBag.Pokemon = _context.pokemons.Include(o => o.tipo).ToList();
            return View("Index");
        }
        [HttpGet]
        public ActionResult Create()//funciona con get y post
        {
            ViewBag.Tipos = _context.tipos.ToList();
            return View("Create", new Pokemons());
        }
        [HttpPost]
        public ActionResult Create(Pokemons pokemons, IFormFile image)//funciona con get y post
        {
           // pokemons.UsuarioId = logeruser().Id;
            if (ModelState.IsValid)
            {
                //guardar archivo en el servidor
                pokemons.Imagen = SaveImage(image);
                _context.pokemons.Add(pokemons);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", pokemons);
        }
        private string SaveImage(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var basepath = _hostEnv.ContentRootPath + @"\wwwroot";
                var ruta = @"\files\" + image.FileName;
                using (var stream = new FileStream(basepath + ruta, FileMode.Create))
                {
                    image.CopyTo(stream);
                    return ruta;
                }
            }
            return null;
        }
        [Authorize]
        public ActionResult Index1()
        {
            ViewBag.Pokemon = _context.pokemons.Include(o => o.tipo).ToList();
            return View("Index1");
        }
        [HttpGet]
        public ActionResult Capturar(int id)
        {
            ViewBag.Pokemos = _context.pokemons.Where(o => o.Id == id).FirstOrDefault();
            return View("Capturar");
        }
        [HttpPost]
        public ActionResult Capturar(UsuarioPokemon usuarioPokemon)
        {
            ViewBag.Pokemons = _context.usuarioPokemons.Include(o => o.pokemons).ToList();
            _context.usuarioPokemons.Add(usuarioPokemon);
            _context.SaveChanges();
            return RedirectToAction("Capturar");
        }
    }
}
