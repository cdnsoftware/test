using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SampleApCore.Interfaces;
using SampleApProvider;
using Unity.Mvc5;

namespace SampleAp
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            try
            {
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));

                /// mapping the Interface with the implmented provider for injecting the method called
                container.RegisterType<IContactUs, ContactUsProvider>();
                container.RegisterType<ICommon, CommonProvider>();
            }
            catch (Exception ex)
            { 
            }

            return container;
        }
    }
}