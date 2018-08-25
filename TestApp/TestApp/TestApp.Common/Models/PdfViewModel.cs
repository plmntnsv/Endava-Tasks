using System.ComponentModel.DataAnnotations;
using System.Web;
using TestApp.Common.Attributes.Validators;

namespace TestApp.Common.Models
{
    public class PdfModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "No file selected.")]
        [PdfFileExtencionValidator]
        [PdfFileSizeValidator]
        public HttpPostedFileBase PdfFile { get; set; }
    }
}
