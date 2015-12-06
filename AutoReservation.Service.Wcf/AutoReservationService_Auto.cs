
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
        public List<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                return BusinessComponent.Autos().ConvertToDtos();
            }
        }

        public AutoDto FindAuto(int id)
        {
            WriteActualMethod();
            return BusinessComponent.FindAuto(id).ConvertToDto();
        }

        public AutoDto InsertAuto(AutoDto autoDto)
        {
            WriteActualMethod();
            return BusinessComponent.InsertAuto(autoDto.ConvertToEntity()).ConvertToDto();
        }

        public AutoDto UpdateAuto(AutoDto modifiedDto, AutoDto originalDto)
        {
            WriteActualMethod();
            try
            {
                return BusinessComponent.UpdateAuto(
                        modifiedDto.ConvertToEntity(),
                        originalDto.ConvertToEntity()
                    ).ConvertToDto();
            }
            catch (LocalOptimisticConcurrencyException<Auto>)
            {
                throw new FaultException<AutoDto>(modifiedDto);
            }
        }

        public AutoDto DeleteAuto(AutoDto autoDto)
        {
            WriteActualMethod();
            return BusinessComponent.DeleteAuto(autoDto.ConvertToEntity()).ConvertToDto();
        }
    }
}
