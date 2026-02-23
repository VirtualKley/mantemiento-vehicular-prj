using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class CitaVehicular
    {
        public int Id { get; set; }
        public required string Placa { get; set; }
        public DateTime Cita { get; set; }
    }
}
