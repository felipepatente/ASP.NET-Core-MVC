using EnsinoSuperior.Data;
using EnsinoSuperior.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System.Threading.Tasks;

namespace EnsinoSuperior.Controllers
{
    [Authorize]
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;

        public InstituicaoController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
        }

        public async Task<IActionResult> Index()
        {            
            return View(await instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToListAsync());
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
            try
            {
                if (ModelState.IsValid)
                {
                    await instituicaoDAL.GravarInstituicao(instituicao);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("","Não foi possível inserir os dados");
            }

            return View(instituicao);
        }

        public async Task<IActionResult> Edit(long id)
        {
            return await ObterVisaoInstituicaoPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await instituicaoDAL.GravarInstituicao(instituicao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(instituicao);
        }
        
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoInstituicaoPorId(id);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return await ObterVisaoInstituicaoPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Instituicao instituicao)
        {
            await instituicaoDAL.EliminarInstituicaoPorId((long) instituicao.InstituicaoID);

            return RedirectToAction(nameof(Index));
        }

        private async  Task<bool> InstituicaoExists(long? id)
        {            
            return await instituicaoDAL.ObterInstituicaoPorId((long)id) != null;
        }

        private async Task<IActionResult> ObterVisaoInstituicaoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await instituicaoDAL.ObterInstituicaoPorId((long)id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }
    }
}