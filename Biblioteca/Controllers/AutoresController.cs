using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Entities;
using Biblioteca.Services.Interfaces;
using Biblioteca.Exceptions;
using Biblioteca.DTOs;

// el controlador llama a un metodo para que me devuelva una info
namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresService service;

        public AutoresController(IAutoresService service)
        {
            this.service = service;
        }

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return await service.GetAutores();
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetOneAutor(int id)
        {
            var autor = await service.GetAutor(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, AutorDTO autorToModify)
        {
            try
            {
                var autor = autorToModify.ToAutor();
                autor.Id = id;
                await service.UpdateAutor(id, autor);
            }
            catch (AutorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Autores
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(AutorDTO autor)
        {
            var createdAutor = await service.CreateAutor(autor.ToAutor());

            // como buena practica 
            return CreatedAtAction(nameof(GetOneAutor), new { id = createdAutor.Id }, createdAutor);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            try
            {
                await service.DeleteAutor(id);
            }
            catch (AutorNotFoundException ex)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
