﻿using Modelo.Cadastros;

namespace Modelo.Discente
{
    public class CursoProfessor
    {
        public long CursoProfessorID { get; set; }

        public long? CursoID { get; set; }
        public Curso Curso { get; set; }
        public long? ProfessorID { get; set; }
        public Professor Professor { get; set; }
    }
}