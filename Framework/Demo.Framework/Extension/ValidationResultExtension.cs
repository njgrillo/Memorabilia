using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Framework.Extension
{
    public static class ValidationResultExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState, string prefix)
        {
            if (result.IsValid)
                return;

            foreach (ValidationFailure error in result.Errors)
            {
                string key = prefix.IsNullOrEmpty() ? error.PropertyName : $"{prefix}.{error.PropertyName}";
                if (modelState.ContainsKey(key))
                {
                    modelState[key].Errors.Add(error.ErrorMessage);
                }
                else
                {
                    modelState.AddModelError(key, error.ErrorMessage);
                    modelState.SetModelValue(key, new ValueProviderResult((error.AttemptedValue ?? string.Empty).ToString(), CultureInfo.CurrentCulture));
                }
            }
        }
    }
}
