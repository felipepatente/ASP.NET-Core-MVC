using Modelo.Cadastros;
using Modelo.Discente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsinoSuperior.Data.DAL.Discente
{
    public class CursosProfessorDAL
    {
        private IESContext _context;

        public CursosProfessorDAL(IESContext context)
        {
            _context = context;
        }

        public IList<CursoProfessor> TrazerCursosESeusProfessores(List<CursoProfessor> cursosProfessorComID)
        {
            IList<CursoProfessor> cursosProfessorComNome = new List<CursoProfessor>();

            foreach (var item in cursosProfessorComID)
            {
                Curso curso = _context.Cursos.SingleOrDefault(c => c.CursoID == item.CursoID);
                Professor professor = _context.Professor.SingleOrDefault(p => p.ProfessorID == item.ProfessorID);

                cursosProfessorComNome.Add(
                    new CursoProfessor()
                    {
                        Curso = curso,
                        Professor = professor
                    }
                    );
            }

            return cursosProfessorComNome;
        }
    }
}
