using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле назва є обов'язковою для заповнення")]
        [Remote("NameLength", "Validation", ErrorMessage = "Назва має бути довшою за два символи")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле ціна обов'язкова для заповнення")]
        [Remote("CheckPrice", "Validation", ErrorMessage = "Ціна має бути більше 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        public string ShortDesc { get; set; }
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        public string LongDesc { get; set; }
        public IFormFile File { get; set; }
    }
}