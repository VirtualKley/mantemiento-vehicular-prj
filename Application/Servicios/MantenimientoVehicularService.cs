using Application.Interfaces;
using Domain.DTOs;
using Domain.Entidades;
using Domain.Repositories;

namespace Application.Servicios
{
    public class MantenimientoVehicularService(IMantenimientoVehicularRepository repo) : IMantenimientoVehicularService
    {
        public async Task<CitaVehicularDTO> CrearCitaVehicular(CitaVehicularDTO cita)
        {
            ValidarHorario(cita.Cita);
            if (await repo.ExisteCitaEnHorario(cita.Cita)) throw new Exception("Ya existe una cita programada en ese horario.");
            var res = await repo.CrearCitaVehicular(new CitaVehicular
            {
                Placa = cita.Placa,
                Cita = cita.Cita
            });
            return MapToDto(res);
        }

        public async Task<List<CitaVehicularDTO>> GetHistorialVehicular(string placa)
        {
            var lista = await repo.GetHistorialVehicular(placa);
            var dto = lista.Select(MapToDto).ToList();

            return dto;
        }

        private CitaVehicularDTO MapToDto(CitaVehicular entity)
        {
            return new CitaVehicularDTO
            {
                Id = entity.Id,
                Placa = entity.Placa,
                Cita = entity.Cita
            };
        }

        private void ValidarHorario(DateTime fechaHora)
        {
            if (fechaHora.DayOfWeek == DayOfWeek.Saturday ||
                fechaHora.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new Exception("Solo se permiten citas de lunes a viernes.");
            }

            var hora = fechaHora.TimeOfDay;

            if (hora < new TimeSpan(8, 0, 0) ||
                hora > new TimeSpan(14, 0, 0))
            {
                throw new Exception("El horario debe ser entre 08:00 y 14:00.");
            }

            if (fechaHora.Minute != 0 && fechaHora.Minute != 30)
            {
                throw new Exception("Las citas deben ser en intervalos de 30 minutos.");
            }
        }
    }
}
