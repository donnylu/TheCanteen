using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;
using TheCanteen.Controllers;
using TheCanteen.Models;
using TheCanteen.Models.Canteen;
using Unity.Mvc5;

namespace TheCanteen.App_Start
{
	public class Bootstrapper
	{
		public static IUnityContainer Initialize()
		{
			var container = BuildUnityContainer();
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			return container;
		}
		private static IUnityContainer BuildUnityContainer()
		{
			var container = new UnityContainer();

			// register all your components with the container here  
			//This is the important line to edit  
			container.RegisterType<ICanteenContext, CanteenContext>();

			//http://www.enterpriseframework.com/post/how-to-asp-net-mvc-with-microsoft-identity-and-unity-bootstrapper
			container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
			container.RegisterType<UserManager<ApplicationUser>>();
			container.RegisterType<DbContext, ApplicationDbContext>();
			container.RegisterType<ApplicationUserManager>();
			container.RegisterType<AccountController>(new InjectionConstructor());

			RegisterTypes(container);
			return container;
		}
		public static void RegisterTypes(IUnityContainer container)
		{

		}
	}
}