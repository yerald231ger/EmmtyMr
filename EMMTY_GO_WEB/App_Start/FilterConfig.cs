﻿using System.Web;
using System.Web.Mvc;

namespace EMMTY_GO_WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

}
