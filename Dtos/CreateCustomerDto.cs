﻿using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El email no es valido")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
