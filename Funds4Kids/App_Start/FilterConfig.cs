﻿using System.Web;
using System.Web.Mvc;

namespace Funds4Kids
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}