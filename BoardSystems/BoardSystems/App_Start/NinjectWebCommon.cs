[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BoardSystems.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BoardSystems.App_Start.NinjectWebCommon), "Stop")]

namespace BoardSystems.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using BoardSystems.Data;
    using BoardSystems.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using WebApiContrib.IoC.Ninject;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);


            GlobalConfiguration.Configuration.DependencyResolver =
                new NinjectResolver(kernel);

              return kernel;
            
           
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
#if DEBUG
            kernel.Bind<IMailService>().To<MockMailService>().InRequestScope();
#else
            kernel.Bind<IMailService>().To<MailService>().InRequestScope();
#endif      //allowing for depency injections
            kernel.Bind<MessageBoardContext>().To<MessageBoardContext>().InRequestScope(); //you want only one context object because it's heavy. No need to recreate.
            kernel.Bind<IMessageBoardRepository>().To<MessageBoardRepository>().InRequestScope();
        }        
    }
}
