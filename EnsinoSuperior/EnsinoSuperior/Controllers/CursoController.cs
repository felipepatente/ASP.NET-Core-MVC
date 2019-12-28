using EnsinoSuperior.Data;
using EnsinoSuperior.Data.DAL.Cadastros;
using EnsinoSuperior.Data.DAL.Discente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo.Cadastros;
using System.Collections;
using System.Linq;

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

        public IActionResult Index()
        {            
            var cursos = cursoDAL.GetCursos();

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
        
        public IActionResult Edit(long? id)
        {
            var curso = cursoDAL.ObterCursoPorId(id);
            ViewBag.Departamentos = new SelectList(_context.Departamentos.OrderBy(d => d.Nome),"DepartamentoID","Nome", curso.CursoID);

            return View(curso);
        }

        [HttpPost]
        public IActionResult Edit(Curso curso)
        {
            cursoDAL.AtualizarCurso(curso);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long? id)
        {
            var curso = cursoDAL.ObterCursoPorId(id);

            return View(curso);
        }

        public IActionResult Delete(long? id)
        {
            var curso = cursoDAL.ObterCursoPorId(id);

            return View(curso);
        }

        [HttpPost]
        public IActionResult Delete(Curso cursoASerRemovido)
        {
            var curso = cursoDAL.ObterCursoPorId(cursoASerRemovido.CursoID);
            cursoDAL.RemoverCurso(curso);

            return RedirectToAction(nameof(Index));
        }
    }
}