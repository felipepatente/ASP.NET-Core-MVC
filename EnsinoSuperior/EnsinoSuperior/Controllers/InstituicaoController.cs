using EnsinoSuperior.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System.Linq;
using System.Threading.Tasks;

namespace EnsinoSuperior.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;

        public InstituicaoController(IESContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {            
            return View(await _context.Instituicoes.OrderBy(c => c.Nome).ToListAsync());
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Instituicao instituicao)
        {
            _context.Add(instituicao);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(long id)
        {
            return View(await _context.Instituicoes.Where(i => i.InstituicaoID == id).FirstAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Instituicao instituicao)
        {
            _context.Instituicoes.Update(instituicao);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(long id)
        {

            var instituicao 
                = await _context.Instituicoes.Include(d => d.Departamentos).SingleOrDefaultAsync(m => m.InstituicaoID == id);

            return View(instituicao);
        }

        public async Task<ActionResult> Delete(long id)
        {
            return View(await _context.Instituicoes.Where(i => i.InstituicaoID == id).FirstAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Instituicao instituicao)
        {
            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}