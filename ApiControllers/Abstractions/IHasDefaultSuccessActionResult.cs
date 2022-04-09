namespace ApiControllers.Abstractions
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public interface IHasDefaultSuccessActionResult
    {
        Func<IActionResult> Success { get; }
    }
}
