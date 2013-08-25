using Funds4Kids.Helpers;
using FundsForKids.Helpers;
using Ninject.Modules;
using Ninject.Web.Common;

namespace FundsForKids.Ninject
{
    public class FundsFKidsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Setup Injections
            //Bind<Funds4KidsContext>().ToSelf();
            Bind<IPaymentsManager>().To<PaymentsManager>().InRequestScope();
            Bind<IEventsManager>().To<EventsManager>().InRequestScope();
        }
    }
}