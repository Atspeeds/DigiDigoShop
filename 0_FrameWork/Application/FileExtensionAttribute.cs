using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace _0_FrameWork.Application
{
    public class FileExtensionAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _validExtentions;

        public FileExtensionAttribute(string[] validExtentions)
        {
            _validExtentions = validExtentions;
        }




        public override bool IsValid(object value)
        {
            var file = value as IFormFile;

            if (file is null) return true;

            var formatfile = Path.GetExtension(file.FileName);

            return _validExtentions.Contains(formatfile);

        }
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-fileExtentionLimit", ErrorMessage);
        }

    }
}
