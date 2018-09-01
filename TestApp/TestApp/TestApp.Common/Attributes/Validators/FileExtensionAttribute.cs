using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestApp.Common.Attributes.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public FileExtensionAttribute(params string[] validExtensions)
        {
            this.extensions = validExtensions.Select(ve => ve.ToLower()).ToArray();
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            if (file == null)
            {
                return true;
            }

            if (file.ContentLength < 0)
            {
                return false;
            }

            string fileExtension = Path.GetExtension(file.FileName);

            if (extensions.Contains(fileExtension))
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("File type must be {0}", string.Join(", ", extensions));
        }
    }
}
