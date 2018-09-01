using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestApp.Common.Attributes.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int maxByteSize; 

        public FileSizeAttribute(int size = 3145728)// 3mb
        {
            this.maxByteSize = size;
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

            if (file.ContentLength > maxByteSize)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("File must be less than {0}mb.", (maxByteSize / 1000 / 1000));
        }
    }
}
