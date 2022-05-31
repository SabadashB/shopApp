using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ViewModels
{
    public class LoginViewModel
    {
        [Remote("CheckRegisterEmail","Validation",ErrorMessage = "Користувач не зареестрований!")]
        [Required(ErrorMessage = "Не вказаний Email")]
        public string Email { get; set; }
   
        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
            
    }

    
}