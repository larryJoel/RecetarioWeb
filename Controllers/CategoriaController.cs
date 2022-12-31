using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Recetario.Models;

namespace Recetario.Controllers
{
    public class CategoriaController: Controller
    {
        private readonly BdrecetasContext _context;
        public CategoriaController(BdrecetasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(){
            return View(await _context.Categoria.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear(){
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Categorium categoria){
            if(ModelState.IsValid){
                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();
                TempData["Mensaje"]="La categoria se creó correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? Id){
            if( Id == null){
                return NotFound();
                }
            var categoria = _context.Categoria.Find(Id);
            if(categoria == null){
                return NotFound();
                }
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Categorium categoria){
            if(ModelState.IsValid){
                _context.Update(categoria);
                await _context.SaveChangesAsync();
                TempData["Mensaje"]="La categoria fué editada";
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Borrar(int? Id){
            if(Id == null){
                return NotFound();
            }
            var categoria = _context.Categoria.Find(Id);
            if(categoria == null){
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrar( Categorium categoria){
            if(categoria == null){
                return NotFound();
            }
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            TempData["Mensaje"]="La categoria fué borrada";
            return RedirectToAction(nameof(Index));
        }
    }
}