using GaussClub.BLL.Contracts;
using GaussClub.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Validations
{
    public class UniqueSlugAttribute : ValidationAttribute
    {
        private readonly string _slug;
        public UniqueSlugAttribute(string slug, IUniversityService)
        {
            _slug = slug;
        }
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            string name = value.ToString();
            var property = validationContext.ObjectType?.GetProperty(_slug);
            if (property != null)
            {
                var idValue = property.GetValue(validationContext.ObjectInstance, null);
                var entity = Universu;

                if (entity != null)
                {
                    return new ValidationResult(GetErrorMessage(value.ToString()));
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string name)
        {
            return $"Name {name} is already in use.";
        }
    }
}
