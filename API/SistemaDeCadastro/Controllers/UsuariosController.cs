using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Data;
using SistemaDeCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly Contexto _context;

        public UsuariosController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Usuarios.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Usuarios usuarios)
        {
            try
            {
                _context.Usuarios.Add(usuarios);
                _context.SaveChanges();
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuarios usuarioAtualizado)
        {
            try
            {
                Usuarios usuarioBuscado = await _context.Usuarios.FindAsync(id);
                if (usuarioBuscado == null)
                {
                    return NotFound();
                }
                if (usuarioAtualizado.Nome != null)
                {
                    usuarioBuscado.Nome = usuarioAtualizado.Nome;
                }
                if (usuarioAtualizado.Idade != usuarioBuscado.Idade)
                {
                    usuarioBuscado.Idade = usuarioAtualizado.Idade;
                }

                    usuarioBuscado.Sexo = usuarioAtualizado.Sexo;
        
                _context.Usuarios.Update(usuarioBuscado);
                _context.SaveChanges();

                return StatusCode((int)HttpStatusCode.NoContent);
            }

            catch (Exception ex)

            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuarios usuarioBuscado = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
                if (usuarioBuscado == null)
                {
                    return NotFound();
                }
                _context.Usuarios.Remove(usuarioBuscado);
                _context.SaveChanges();

                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (Exception ex)

            {
                return BadRequest(ex);
            }
        }
    }
}
