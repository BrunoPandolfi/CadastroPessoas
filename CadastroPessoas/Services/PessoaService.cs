using CadastroPessoas.Data;
using CadastroPessoas.Models;
using CadastroPessoas.Services.Exceptions;
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

        public async Task InsertAsync(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Pessoa pessoa)
        {
            bool hasAny = await _context.Pessoa.AnyAsync(obj => obj.Id == id);
            if (!hasAny)
            {
                throw new ApplicationException("Id não encontrado");
            }
            try
            {
                _context.Update(pessoa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("Não é possível atualizar os dados da pessoa");
            }
        }

        public async Task DeleteAsync(int id)
        {
            bool hasAny = await _context.Pessoa.AnyAsync(obj => obj.Id == id);
            if (!hasAny)
            {
                throw new ApplicationException("Id não encontrado");
            }
            try
            {
                var pessoa = await _context.Pessoa.FindAsync(id);
                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não é possível atualizar os dados da pessoa");
            }
        }
    }
}
