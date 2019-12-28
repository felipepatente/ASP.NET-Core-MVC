using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Discente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsinoSuperior.Data.DAL.Discente
{
    public class CursoDAL
    {
        private IESContext _context;

        public CursoDAL(IESContext context)
        {
            _context = context;
        }

        public void RegistrarProfessor(long cursoID, long professorID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professor = _context.Professor.Find(professorID);
            curso.CursosProfessores.Add(new CursoProfessor() { Curso = curso, Professor = professor });
            _context.SaveChanges();
        }

        public async Task<Curso> ObterCursoPorId(long? id)
        {
            var curso = await _context.Cursos.SingleOrDefaultAsync(c => c.CursoID == id);
            _context.Departamentos.Where(d => d.DepartamentoID == curso.DepartamentoID).Load();

            return curso;
        }

        public IQueryable<Professor> ObterProfessoresForaDoCurso(long cursoID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professoresDoCurso = curso.CursosProfessores.Select(cp => cp.ProfessorID).ToArray();
            var professoresForaDoCurso = _context.Professor.Where(p => !professoresDoCurso.Contains(p.ProfessorID));
            return professoresForaDoCurso;
        }

        public IQueryable<Curso> ObterCursosPorDepartamento(long departamentoID)
        {
            var cursos = _context.Cursos.Where(c => c.DepartamentoID == departamentoID);

            return cursos;
        }

        public IQueryable<Curso> ObterCursosClassificadosPorNome()
        {
            return _context.Cursos.Include(d => d.Departamento).OrderBy(c => c.Nome);
        }

        public void AdicionarCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }

        public async Task<Curso> AtualizarCurso(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        public async Task<Curso> RemoverCurso(Curso curso)
        {
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return curso;
        }
    }
}
