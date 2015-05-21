﻿using System.Web;
using System.Web.Mvc;
using Ucoin.Framework.Web;

namespace Ucoin.Conference.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MaintenanceModeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
