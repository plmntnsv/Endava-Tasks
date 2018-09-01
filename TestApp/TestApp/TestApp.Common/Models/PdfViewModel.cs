using System.ComponentModel.DataAnnotations;
using System.Web;
using TestApp.Common.Attributes.Validators;

namespace TestApp.Common.Models
{
    public class PdfModel
    {
        [Required(ErrorMessage = "No file selected.")]
        [FileSize]
        [FileExtension("pdf")]
        public HttpPostedFileBase PdfFile { get; set; }
    }
}
