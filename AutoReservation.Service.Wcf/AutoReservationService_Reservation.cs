
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
        public List<ReservationDto> Reservationen()
        {
            WriteActualMethod();
            return BusinessComponent.Reservations().ConvertToDtos();
        }

        public ReservationDto FindReservation(int id)
        {
            WriteActualMethod();
            return BusinessComponent.FindReservation(id).ConvertToDto();
        }

        public ReservationDto InsertReservation(ReservationDto ReservationDto)
        {
            WriteActualMethod();
            return BusinessComponent.InsertReservation(ReservationDto.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto UpdateReservation(ReservationDto modifiedDto, ReservationDto originalDto)
        {
            WriteActualMethod();
            try
            {
                return BusinessComponent.UpdateReservation(
                        modifiedDto.ConvertToEntity(),
                        originalDto.ConvertToEntity()
                    ).ConvertToDto();
            }
            catch (LocalOptimisticConcurrencyException<Reservation>)
            {
                throw new FaultException<ReservationDto>(modifiedDto);
            }
        }

        public ReservationDto DeleteReservation(ReservationDto ReservationDto)
        {
            WriteActualMethod();
            return BusinessComponent.DeleteReservation(ReservationDto.ConvertToEntity()).ConvertToDto();
        }
    }
}
