using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace ProvaCandidato.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        public readonly ContextoPrincipal _db;

        public ClienteRepository(ContextoPrincipal db = null)
        {
            _db = db ?? new ContextoPrincipal();
        }

        public IEnumerable<Cliente> GetByName(string nome)
        {
            var clientes = _db.Clientes.Include(c => c.Cidade);

            if (!String.IsNullOrEmpty(nome))
            {
                clientes = clientes.Where(x => x.Nome.Contains(nome));
            }

            return clientes.ToList();
        }

    }
}