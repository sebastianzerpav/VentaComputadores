using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VentaComputadores.API.Data;
using VentaComputadores.API.Data.Models;

namespace VentaComputadores.API.Services
{
    public class ComputadoresService : IComputadoresService
    {
        private readonly ApplicationDbContext context;

        public ComputadoresService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<String> Insert(Computador computador) {
            try
            {
                context.Computadores.Add(computador);
                await context.SaveChangesAsync();
                return "Computador insertado exitosamente";
            }
            catch (Exception e) {
                Console.WriteLine("Error al insertar el computador" + e.Message);
                return "Error al insertar el computador";
            }
        }

        public async Task<String> Update(int numeroUnicoComputador, Computador computador) {
            try
            {
                Computador? objComputador = await Search(numeroUnicoComputador);

                if (objComputador != null)
                {
                    objComputador.IdTipoComputador = computador.IdTipoComputador;
                    objComputador.NitAgencia = computador.NitAgencia;
                    objComputador.NombreModelo = computador.NombreModelo;
                    objComputador.MarcaComputador = computador.MarcaComputador;
                    objComputador.NumeroProcesadores = computador.NumeroProcesadores;
                    objComputador.MarcaProcesadores = computador.MarcaProcesadores;
                    objComputador.TipoAlmacenamiento = computador.TipoAlmacenamiento;
                    objComputador.CapacidadAlmacenamientoGb = computador.CapacidadAlmacenamientoGb;
                    objComputador.RamGb = computador.RamGb;
                    objComputador.ComponentesAdicionales = computador.ComponentesAdicionales;
                    await context.SaveChangesAsync();
                    return "Actualización de la información del computador realizada con éxito";
                }
                else {
                    return "El computador no existe en la base de datos";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("No fue posible actualizar la información del computador. " + e.Message);
                return "No fue posible actualizar la información del computador";
            }
        }

        public async Task<String> Delete(int numeroUnicoComputador) {

            try
            {
                Computador? objComputador = await Search(numeroUnicoComputador);

                if (objComputador != null)
                {
                    context.Computadores.Remove(objComputador);
                    await context.SaveChangesAsync();
                    return "Computador eliminado con éxito";
                }
                else {
                    return "No fue encontrado ningún computador con ese número único. No es posible continuar con la eliminación";
                }
            }
            catch (Exception e) {
                Console.WriteLine("No fue posible eliminar la información del computador. " + e.Message);
                return "No fue posible eliminar la información del computador";
            }
        }

        public async Task<Computador?> Search(int numeroUnicoComputador) {
            Computador? computador = await context.Computadores.FindAsync(numeroUnicoComputador);
            return computador;
        }

        public async Task<List<Computador>> ToList() {
            return await context.Computadores.ToListAsync();
        }
    }

    public interface IComputadoresService 
    {
        public Task<String> Insert(Computador computador);
        public Task<String> Update(int numeroUnicoComputador, Computador computador);

        public Task<String> Delete(int numeroUnicoComputador);

        public Task<Computador?> Search(int numeroUnicoComputador);

        public Task<List<Computador>> ToList();
    }
}
