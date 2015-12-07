using AutoReservation.Common.Interfaces;
using System.ServiceModel;

namespace AutoReservation.Ui.Factory
{
    class RemoteDataAccessServiceFactory : IServiceFactory
    {
        public IAutoReservationService GetService()
        {
            return new ChannelFactory<IAutoReservationService>("AutoReservationService").CreateChannel();
        }
    }
}
