
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf
{
    public partial class AutoReservationService : IAutoReservationService
    {
        public List<KundeDto> Kunden()
        {
            WriteActualMethod();
            return BusinessComponent.Kunden().ConvertToDtos();
        }

        public KundeDto FindKunde(int id)
        {
            WriteActualMethod();
            return BusinessComponent.FindKunde(id).ConvertToDto();
        }

        public KundeDto InsertKunde(KundeDto kundeDto)
        {
            WriteActualMethod();
            return BusinessComponent.InsertKunde(kundeDto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto UpdateKunde(KundeDto modifiedDto, KundeDto originalDto)
        {
            WriteActualMethod();
            try
            {
                return BusinessComponent.UpdateKunde(
                        modifiedDto.ConvertToEntity(),
                        originalDto.ConvertToEntity()
                    ).ConvertToDto();
            }
            catch (LocalOptimisticConcurrencyException<Kunde>)
            {
                throw new FaultException<KundeDto>(modifiedDto);
            }
        }

        public KundeDto DeleteKunde(KundeDto kundeDto)
        {
            WriteActualMethod();
            return BusinessComponent.DeleteKunde(kundeDto.ConvertToEntity()).ConvertToDto();
        }
    }
}
