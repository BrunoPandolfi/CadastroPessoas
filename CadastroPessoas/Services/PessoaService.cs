using CadastroPessoas.Data;
using CadastroPessoas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Services
{
    public class PessoaService
    {
        private readonly CadastroPessoasContext _context;

        public PessoaService (CadastroPessoasContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> FindAllAsync()
        {
            return await _context.Pessoa.ToListAsync();
        }

        public async Task<Pessoa> FindByIdAsync(int id)
        {
            return await _context.Pessoa.FirstOrDefaultAsync(obj => obj.Id == id);
        }
    }
}
