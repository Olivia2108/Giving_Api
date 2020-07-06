using MessagingAlertSender.Data;
using Ninject.Modules;

namespace MessagingAlertSender
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<DataContext>().To<DataContext>();
            //Bind<ILaonCamSolRepository>().To<LaonCamSolRepository>();
            //Bind<ITwoFactorAuthIntegrationService>().To<TwoFactorAuthIntegrationService>();
            //Bind<IStaffMIS>().To<StaffMIS>();
        }
    }
}
