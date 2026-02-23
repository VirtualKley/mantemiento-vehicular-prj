using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MantenimientoVehicularController(IMantenimientoVehicularService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHistorialVehicularAsync(string placa)
        {
            return Ok(await service.GetHistorialVehicular(placa));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CitaVehicularDTO cita)
        {
            try
            {
                if (cita == null) throw new Exception("No existe informacion.");
                var resp = await service.CrearCitaVehicular(cita);
                return CreatedAtAction("Post", new { id = resp.Id }, resp);

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
