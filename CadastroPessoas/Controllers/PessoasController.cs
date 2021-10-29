using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroPessoas.Data;
using CadastroPessoas.Models;
using CadastroPessoas.Services;
using CadastroPessoas.Services.Exceptions;

namespace CadastroPessoas
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaService _pessoaService;

        public PessoasController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoa()
        {
            return await _pessoaService.FindAllAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var pessoa = await _pessoaService.FindByIdAsync(id.Value);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pessoaService.UpdateAsync(id, pessoa);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ApplicationException(e.Message);
            }

            return NoContent();
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa pessoa)
        {
            await _pessoaService.InsertAsync(pessoa);
            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);
        }


        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePessoa(int id)
        {
            try
            {
                await _pessoaService.DeleteAsync(id);
                return NoContent();
            }
            catch (IntegrityException e)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                return result;
            }
        }

        /*private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }*/
    }
}
