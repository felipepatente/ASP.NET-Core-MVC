using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsinoSuperior.Data.DAL.Discente
{
    public class ProfessorDAL
    {
        private IESContext context;

        public ProfessorDAL(IESContext context)
        {
            this.context = context;
        }
    }
}
