﻿using System.ComponentModel.DataAnnotations;

namespace ServicaDB.DTOs
{
    public class ProfesionalCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
