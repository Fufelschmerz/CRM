namespace ApiControllers.Abstractions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;

    public interface IHasInvalidModelStateActionResult
    {
        Func<ModelStateDictionary, IActionResult> InvalidModelState { get; }
    }
}
