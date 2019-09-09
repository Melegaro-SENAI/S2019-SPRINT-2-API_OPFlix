using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository
    {
        public List<Categorias> Listar()
        {
            using (OPFlixContext ctx = new OPFlixContext())
            {
                // select
                return ctx.Categorias.ToList();
            }
        }

        public void Cadastrar(Categorias categorias)
        {
            using (OPFlixContext ctx = new OPFlixContext())
            {
                // insert 
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }

        // buscar por id
    }
}
