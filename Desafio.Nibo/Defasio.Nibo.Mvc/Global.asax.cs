using Autofac;
using Autofac.Integration.Mvc;
using Defasio.Nibo.Application.UseCases.ExcluirTransacoes;
using Defasio.Nibo.Application.UseCases.GetTransacoes;
using Defasio.Nibo.Application.UseCases.ImportOfx;
using Defasio.Nibo.Application.UseCases.ParseOFX;
using Defasio.Nibo.Application.UseCases.Upload;
using Defasio.Nibo.Mvc.App_Start;
using Desafio.Nibo.Infrastructure;
using Desafio.Nibo.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Defasio.Nibo.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>().WithParameter("injectActionMethodParameters", true);
            builder.Register<IUploadFile>(c => new UploadFile());
            
            builder.Register<IImportOfxFile>(c => new ImportOfxFile(new ParseOFXContent(), new ExtratoRepository(new OfxDbContext())));

            builder.Register<IGetTransacoesUseCase>(c => new GetTransacoesUseCase(new ExtratoRepository(new OfxDbContext())));
            builder.Register<IExcluirTransacoesUseCase>(c => new ExcluirTransacoesUseCase(new ExtratoRepository(new OfxDbContext())));


            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InjectActionInvoker();
            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}
