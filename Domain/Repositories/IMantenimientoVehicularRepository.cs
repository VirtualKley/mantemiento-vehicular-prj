using Domain.Entidades;

namespace Domain.Repositories
{
    public interface IMantenimientoVehicularRepository
    {
        public Task<List<CitaVehicular>> GetHistorialVehicular(string placa);
        public Task<bool> ExisteCitaEnHorario(DateTime cita);
        public Task<CitaVehicular> CrearCitaVehicular(CitaVehicular cita);
    }
}
