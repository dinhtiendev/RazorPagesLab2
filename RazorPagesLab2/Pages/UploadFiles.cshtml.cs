using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesLab2.Pages
{
    public class UploadFilesModel : PageModel
    {
        private IHostingEnvironment _environment;

        public UploadFilesModel(IHostingEnvironment enviroment)
        {
            _environment = enviroment;
        }

        [Required(ErrorMessage = "Please choose at least one file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "prg,jpg,jpeg,gif")]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public async Task OnPostAsync()
        {
            foreach (var FileUpload in FileUploads)
            {
                var file = Path.Combine(_environment.ContentRootPath, "Image", FileUpload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await FileUpload.CopyToAsync(fileStream);
                }
            }
        }
    }
}
