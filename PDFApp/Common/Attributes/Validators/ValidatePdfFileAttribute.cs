using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace Common.Attributes.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidatePdfFileExtensionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength <= 0)
            {
                return false;
            }

            string fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension != ".pdf")
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("File type must be .pdf");
        }
    }

    public class ValidatePdfFileSizeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            if (file == null || file.ContentLength <= 0)
            {
                return false;
            }

            int maxByteSize = 3145728; // 3mb
            if (file.ContentLength > maxByteSize)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("File must be less than 3mb.");
        }
    }
}
