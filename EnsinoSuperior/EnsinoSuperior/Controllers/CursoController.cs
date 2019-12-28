using EnsinoSuperior.Data;
using EnsinoSuperior.Data.DAL.Cadastros;
using EnsinoSuperior.Data.DAL.Discente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace EnsinoSuperior.Controllers
{
    public class CursoController : Controller
    {
        private IESContext _context;
        private DepartamentoDAL departamentoDAL;
        private CursoDAL cursoDAL;

        public CursoController(IESContext context)
        {            
            _context = context;
            departamentoDAL = new DepartamentoDAL(_context);
            cursoDAL = new CursoDAL(_context);
        }

        public async Task<IActionResult> Index()
        {            
            var cursos = await cursoDAL.ObterCursosClassificadosPorNome().ToListAsync();

            return View(cursos);
        }

        public IActionResult Create()
        {            
            ViewBag.Departamentos = departamentoDAL.ObterDepartamentosClassificadosPorNome();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            cursoDAL.AdicionarCurso(curso);

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(long? id)
        {
            var curso = await cursoDAL.ObterCursoPorId(id);
            ViewBag.Departamentos = new SelectList(_context.Departamentos.OrderBy(d => d.Nome),"DepartamentoID","Nome", curso.CursoID);

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Curso curso)
        {
            await cursoDAL.AtualizarCurso(curso);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(long? id)
        {
            var curso = await cursoDAL.ObterCursoPorId(id);

            return View(curso);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            var curso = await cursoDAL.ObterCursoPorId(id);

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Curso cursoASerRemovido)
        {
            var curso = await cursoDAL.ObterCursoPorId(cursoASerRemovido.CursoID);
            await cursoDAL.RemoverCurso(curso);

            return RedirectToAction(nameof(Index));
        }
    }
}