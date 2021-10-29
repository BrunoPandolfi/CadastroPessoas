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
using System.IO;

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
        public async Task<IActionResult> PutPessoa(int id, [FromForm] PessoaViewModel pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imgAvatar = pessoa.ImgAvatar;
            using (var fileContentStream = new MemoryStream())
            {
                await imgAvatar.CopyToAsync(fileContentStream);
                await System.IO.File.WriteAllBytesAsync(Path.Combine("Images/", imgAvatar.FileName), fileContentStream.ToArray());
            }
            var upPessoa = new Pessoa
            {
                Id = id,
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento,
                Email = pessoa.Email,
                ImgAvatar = imgAvatar.FileName
            };
            try
            {
                await _pessoaService.UpdateAsync(id, upPessoa);
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
        public async Task<ActionResult<Pessoa>> PostPessoa([FromForm] PessoaViewModel pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imgAvatar = pessoa.ImgAvatar;
            using (var fileContentStream = new MemoryStream())
            {
                await imgAvatar.CopyToAsync(fileContentStream);
                await System.IO.File.WriteAllBytesAsync(Path.Combine("Images/", imgAvatar.FileName), fileContentStream.ToArray());
            }
            var novaPessoa = new Pessoa
            {
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento,
                Email = pessoa.Email,
                ImgAvatar = imgAvatar.FileName
            };
            await _pessoaService.InsertAsync(novaPessoa);
            return CreatedAtAction("GetPessoa", new { id = novaPessoa.Id }, novaPessoa);
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
    }
}
