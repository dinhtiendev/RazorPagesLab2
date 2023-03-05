using Microsoft.AspNetCore.Mvc;
using RazorPagesLab2.Binding;
using RazorPagesLab2.Validation;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesLab2.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from 3 to 30 characters")]
        [Display(Name = "Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer email is required!")]
        [EmailAddress]
        [Display(Name = "Customer email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Year of birth is required!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "1960 - 2000")]
        [CustomerValidation]
        public int? YearOfBirth { get; set; }
    }
}
