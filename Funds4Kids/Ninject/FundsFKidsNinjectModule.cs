﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Funds4Kids.Ninject
{
    public class FundsFKidsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Setup Injections
            //Bind<IPawTrailsServiceHelper>().To<PawTrailsServiceHelper>().InRequestScope();
        }
    }
}