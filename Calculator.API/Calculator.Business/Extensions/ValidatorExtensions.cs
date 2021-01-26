// // <copyright file="ValidatorExtensions.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>ValidatorExtensions.cs</summary>

using System.Linq;
using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using FluentValidation;

namespace Calculator.Business.Extensions
{
  public static class ValidatorExtensions
  {
    public static async Task ValidateOrThrowInvalidAsync<T>(this IValidator<T> validator, T model)
    {
      var result = await validator.ValidateAsync(model);

      if (!result.IsValid)
      {
        var errors = result.Errors
          .GroupBy(x => x.PropertyName)
          .ToDictionary(x => x.Key, z => z.Select(v => v.ErrorMessage));
        
        throw new ValidationModelException(errors);
      }
    }
  }
}