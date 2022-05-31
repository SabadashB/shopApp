using System.ComponentModel.DataAnnotations;

namespace eShop.ViewModels
{
    public class OrderViewModel
    {
        [Required (ErrorMessage = "Поле обов'язкове для заповнення")]
        public string CustomerName { get; set; }
        [Required (ErrorMessage = "Поле обов'язкове для заповнення")]
        public string Address { get; set; }
        [Required (ErrorMessage = "Поле обов'язкове для заповнення")]
        public string PhoneNumber { get; set; }
       
    }
}