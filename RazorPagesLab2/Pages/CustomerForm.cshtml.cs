using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLab2.Models;

namespace RazorPagesLab2.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public Customer customerInfo { get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();
            } else
            {
                Message = "Error on input data.";
            }
        }
    }
}
