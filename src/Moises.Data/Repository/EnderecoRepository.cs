using Microsoft.EntityFrameworkCore;
using MinhaAppMvcCompleta.Models;
using Moises.Business.Interfaces;
using Moises.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moises.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
           return await Db.Enderecos.AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == fornecedorId);
        }
    }
}
