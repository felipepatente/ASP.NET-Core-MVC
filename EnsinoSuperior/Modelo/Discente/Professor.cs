﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Discente
{
    public class Professor
    {
        public long? ProfessorID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<CursoProfessor> CursosProfessores { get; set; }
    }
}
