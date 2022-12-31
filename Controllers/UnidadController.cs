
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recetario.Models;

namespace Recetario.Controllers
{
  
    public class UnidadController : Controller
    {
        private readonly BdrecetasContext _context;

        public UnidadController(BdrecetasContext context)
        {
            _context = context;
        }
       [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidades.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Unidade unidad)
        {
            if(ModelState.IsValid){
                _context.Unidades.Add(unidad);
                await _context.SaveChangesAsync();
                TempData["Mensaje"]="La unidad se creó correctamente.!";
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if(Id == null){return NotFound();}
            var unidad =  _context.Unidades.Find(Id);
            if(unidad == null){return NotFound();}
            return View(unidad);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Unidade unidad){
            if(ModelState.IsValid){
                _context.Update(unidad);
                await _context.SaveChangesAsync();
                TempData["Mensaje"]="La unidad de medida a sido modificada..!";
                return RedirectToAction(nameof(Index));
            }
            return View(unidad);
        }
        
        [HttpGet]
        public IActionResult Borrar(int? Id){
            if(Id == null){ return NotFound();}
            var unidad = _context.Unidades.Find(Id);
            if(unidad == null){return NotFound();}
            return View(unidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrar(Unidade unidad){
            
            if(unidad == null){return NotFound();}

            _context.Unidades.Remove(unidad);
            await _context.SaveChangesAsync();
            TempData["Mensaje"]="La unidad de medida se borró correctamente";
            return RedirectToAction(nameof(Index));
        }
        
    }
}