using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentaComputadores.API.Data.Models;
using VentaComputadores.API.Services;

namespace VentaComputadores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputadoresController : ControllerBase
    {
        private readonly IComputadoresService servicioComputadores;

        public ComputadoresController(IComputadoresService servicioComputadores)
        {
            this.servicioComputadores = servicioComputadores;
        }

        [Route("Insertar")]
        [HttpPost]
        public async Task<ActionResult<String>> Insert([FromBody] Computador computador) {
            String resultado = await servicioComputadores.Insert(computador);
            if (resultado.Equals("Computador insertado exitosamente"))
            {
                return Ok(resultado);
            }
            else {
                return StatusCode(500, resultado);
            }
        }

        [Route("Actualizar/{numeroUnicoComputador}")]
        [HttpPut]
        public async Task<ActionResult<String>> Update(int numeroUnicoComputador, [FromBody] Computador computador) {
            String resultado = await servicioComputadores.Update(numeroUnicoComputador, computador);
            if (resultado.Equals("Actualización de la información del computador realizada con éxito"))
            {
                return Ok(resultado);
            }
            else {
                if (resultado.Equals("El computador no existe en la base de datos"))
                {
                    return NotFound(resultado);
                }
                else {
                    return StatusCode(500, resultado);
                }
            }
        }

        [Route("Eliminar/{numeroUnicoComputador}")]
        [HttpDelete]
        public async Task<ActionResult<String>> Delete(int numeroUnicoComputador) {
            String resultado = await servicioComputadores.Delete(numeroUnicoComputador);
            if (resultado.Equals("Computador eliminado con éxito"))
            {
                return Ok(resultado);
            }
            else {
                if (resultado.Equals("No fue encontrado ningún computador con ese número único. No es posible continuar con la eliminación"))
                {
                    return NotFound(resultado);
                }
                else {
                    return StatusCode(500, resultado);
                }
            }
        }

        [Route("ListaComputadores")]
        [HttpGet]
        public async Task<ActionResult<List<Computador>>> ListAll() {
            List<Computador> listaComputadores = await servicioComputadores.ToList();
            if (listaComputadores == null)
            {
                return StatusCode(500, "Lista de computadores es NULL");
            }
            else {
                if (!listaComputadores.Any())
                {
                    return NotFound("No hay ningún computador registrado");
                }
                else {
                    return Ok(listaComputadores);
                }
            }
        }

        [Route("BuscarComputador/{numeroUnicoComputador}")]
        [HttpGet]
        public async Task<ActionResult<Computador>> SearchComputer(int numeroUnicoComputador) {
            Computador? computador = await servicioComputadores.Search(numeroUnicoComputador);
            if (computador != null)
            {
                return Ok(computador);
            }
            else {
                return NotFound();
            }
        }
    }
}
