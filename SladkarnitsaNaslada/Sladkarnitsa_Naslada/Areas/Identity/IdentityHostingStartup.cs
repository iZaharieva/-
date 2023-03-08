using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sladkarnitsa_Naslada.Data;
using Sladkarnitsa_Naslada.Entities;

[assembly: HostingStartup(typeof(Sladkarnitsa_Naslada.Areas.Identity.IdentityHostingStartup))]
namespace Sladkarnitsa_Naslada.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}