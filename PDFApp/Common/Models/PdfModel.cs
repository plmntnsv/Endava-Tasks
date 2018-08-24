using Common.Attributes.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Models
{
    public class PdfModel
    {
        [Required]
        public string Name { get; set; }

        [ValidatePdfFileExtension]
        [ValidatePdfFileSize]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}
