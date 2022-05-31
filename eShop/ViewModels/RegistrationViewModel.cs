using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ViewModels
{
    public class RegistrationViewModel
    {

        [Required(ErrorMessage = "Не вказано ім'я")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не вказаний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId { get; set; }

    }
}
