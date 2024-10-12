﻿namespace IntroduccionEFCore.DTOs
{
    public class UsuarioCreacionDTO
    {
        public string NombreUsuario { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int? ProfesionalId { get; set; } // Este campo es opcional
    }

}
