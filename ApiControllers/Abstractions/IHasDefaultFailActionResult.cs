namespace ApiControllers.Abstractions
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public interface IHasDefaultFailActionResult
    {
        Func<Exception, IActionResult> Fail { get; }
    }
}
