using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        readonly ILogger<UsuariosController> _logger;

        public UsuariosController(Contexto context, ILogger<UsuariosController> log)
        {
            _context = context;
            _logger = log;
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
                _logger.LogError("Action Get :: UsuariosController :: problema: " + ex.ToString() + " executou em: " + DateTime.Now.ToString());
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
                _logger.LogError("Action Post :: UsuariosController :: problema: " + ex.ToString() + " executou em: " + DateTime.Now.ToString());
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
                    _logger.LogWarning("Action Put :: UsuariosController :: problema: Usuário não encontrado id: " + id + " executou em: " + DateTime.Now.ToString());
                    return NotFound();
                }

                usuarioBuscado.Nome = usuarioAtualizado.Nome;

                usuarioBuscado.Idade = usuarioAtualizado.Idade;

                usuarioBuscado.Sexo = usuarioAtualizado.Sexo;
        
                _context.Usuarios.Update(usuarioBuscado);
                _context.SaveChanges();

                return StatusCode((int)HttpStatusCode.NoContent);
            }

            catch (Exception ex)
            {
                _logger.LogError("Action Put :: UsuariosController :: problema: " + ex.ToString() + " executou em: " + DateTime.Now.ToString());
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
                    _logger.LogWarning("Action Delete :: UsuariosController :: problema: Usuário não encontrado id: " + id + " executou em: " + DateTime.Now.ToString());
                    return NotFound();
                }
                _context.Usuarios.Remove(usuarioBuscado);
                _context.SaveChanges();

                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError("Action Delete :: UsuariosController :: problema: " + ex.ToString() + " executou em: " + DateTime.Now.ToString());
                return BadRequest(ex);
            }
        }
    }
}
