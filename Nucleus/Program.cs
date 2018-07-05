using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

using Nucleus.Data;

namespace Nucleus
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // Add any custom services here
                services.AddSingleton<IRepository, PeopleRepository>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
