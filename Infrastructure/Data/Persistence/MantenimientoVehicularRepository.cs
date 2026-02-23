using Domain.Entidades;
using Domain.Repositories;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence
{
    public class MantenimientoVehicularRepository(ApplicationDbContext context) : IMantenimientoVehicularRepository
    {
        public async Task<CitaVehicular> CrearCitaVehicular(CitaVehicular cita)
        {
            await context.CitasVehiculares.AddAsync(cita);
            await context.SaveChangesAsync();
            return cita;
        }

        public async Task<bool> ExisteCitaEnHorario(DateTime cita)
        {
            return await context.CitasVehiculares.AnyAsync(x => x.Cita == cita);
        }

        public async Task<List<CitaVehicular>> GetHistorialVehicular(string placa)
        {
            return await context.CitasVehiculares.Where(x => x.Placa == placa).ToListAsync();
        }
    }
}
