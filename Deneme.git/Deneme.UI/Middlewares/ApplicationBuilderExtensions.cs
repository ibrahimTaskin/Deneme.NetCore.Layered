using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Deneme.UI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        //Node package larımız Core da wwwroot altında toplanmadığı için nereden bağlanacağını burada belirtiyoruz.
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules"); //node_modules klasörünü root stringine bağladık.
            var provider = new PhysicalFileProvider(path);

            var option=new StaticFileOptions();
            option.RequestPath = "/node_modules";
            option.FileProvider = provider;

            app.UseStaticFiles(option);

            return app;
        }
    }
}
