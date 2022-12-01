//using System.Data.SqlClient;
//using System.Linq;
//using System.Reflection;
//using System.Security.Claims;
//using CodingSample.Model;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Rewrite;
//using Microsoft.AspNetCore.Server.Kestrel.Core;
//using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Net.Http.Headers;

//namespace CodingSample
//{
//    public class Startup
//    {
//        const int maxFileSize = 104857600; // 100 MB

//        public Startup(IConfiguration configuration, IWebHostEnvironment env)
//        {
//            Configuration = configuration;
//        }

//        private string GetAssemblyVersion()
//        {
//            return GetType().Assembly.GetName().Version.ToString();
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddScoped(db =>
//                new SqlConnection("Server=localhost;Database=bploans;Trusted_Connection=true"));
//            services.AddScoped<IDbService, DbService>();
//            services.AddSingleton<ListHelper>();

//            // If using Kestrel:
//            services.Configure<KestrelServerOptions>(options =>
//            {
//                options.AllowSynchronousIO = true;
//            });

//            // If using IIS:
//            services.Configure<IISServerOptions>(options =>
//            {
//                options.AllowSynchronousIO = true;
//            });

//            services.AddControllersWithViews();
//            services.AddSpaStaticFiles(configuration =>
//            {
//                configuration.RootPath = "ClientApp/build";
//            });

//            services.AddAuthorization();
//            //services.AddSwaggerDocs();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//            app.UseSpaStaticFiles(new StaticFileOptions()
//            {
//                OnPrepareResponse = ctx =>
//                {
//                    // ensure that cache busting javascript bundles get properly updated for all client sessions
//                    if (ctx.File.Name == "index.html" || ctx.Context.Request.Path.Value?.Contains("service-worker.js") == true)
//                    {
//                        ctx.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
//                        ctx.Context.Response.Headers.Add("Expires", "-1");
//                    }
//                }
//            });
//            app.UseRouting();

//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller}/{action=Index}/{id?}");
//            });

//            app.UseRewriter(new RewriteOptions().AddRedirect("index.html", "/"));

//            app.UseSpaStaticFiles(new StaticFileOptions()
//            {
//                OnPrepareResponse = ctx =>
//                {
//                    if (ctx.Context.Request.Path.StartsWithSegments("/static"))
//                    {
//                        // Cache all static resources for 1 year (versioned filenames)
//                        var headers = ctx.Context.Response.GetTypedHeaders();
//                        headers.CacheControl = new CacheControlHeaderValue
//                        {
//                            Public = true,
//                            MaxAge = TimeSpan.FromDays(365)
//                        };
//                    }
//                    else
//                    {
//                        // Do not cache explicit `/index.html` or any other files.  See also: `DefaultPageStaticFileOptions` below for implicit "/index.html"
//                        var headers = ctx.Context.Response.GetTypedHeaders();
//                        headers.CacheControl = new CacheControlHeaderValue
//                        {
//                            Public = true,
//                            MaxAge = TimeSpan.FromDays(0)
//                        };
//                    }
//                }
//            });

//            app.UseSpa(spa =>
//            {
//                spa.Options.SourcePath = "ClientApp";
//                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions()
//                {
//                    OnPrepareResponse = ctx =>
//                    {
//                        // Do not cache implicit `/index.html`.  See also: `UseSpaStaticFiles` above
//                        var headers = ctx.Context.Response.GetTypedHeaders();
//                        headers.CacheControl = new CacheControlHeaderValue
//                        {
//                            Public = true,
//                            MaxAge = TimeSpan.FromDays(0)
//                        };
//                    }
//                };

//                if (env.IsDevelopment())
//                {
//                    spa.UseReactDevelopmentServer(npmScript: "start");
//                }
//            });
//        }
//    }
//}
