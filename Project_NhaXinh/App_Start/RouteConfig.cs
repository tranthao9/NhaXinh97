using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_NhaXinh
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			
			routes.MapRoute(
				name: "Search",
				url: "tim-kiem",
				defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);
			routes.MapRoute(
				name: "Category",
				url: "danh-muc/{MetaTitle}-{id}",
				defaults: new { controller = "Home", action = "Category", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);
			routes.MapRoute(
				name: "Room",
				url: "phong/{MetaTitle}-{id}",
				defaults: new { controller = "RoomView", action = "PhongKhach", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);
			routes.MapRoute(
				name: "News",
				url: "tin-tuc",
				defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);
			routes.MapRoute(
				name: "Content Detail",
				url: "tin-tuc/{MetaTitle}-{id}",
				defaults: new { controller = "Content", action = "Detail", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);
			routes.MapRoute(
				name: "Tags",
				url: "tag/{id}",
				defaults: new { controller = "Content", action = "Tag", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);
			routes.MapRoute(
				name: "Home",
				url: "NhaXinh",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				namespaces: new[] { "Project_NhaXinh.Controllers" }
				);


			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

		}
	}
}
