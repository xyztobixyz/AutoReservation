using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        
        [OperationContract]
        AutoDto FindAuto(int id);
        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);
        [OperationContract]
        [FaultContract(typeof(AutoDto))]
        AutoDto UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        AutoDto DeleteAuto(AutoDto auto);
        List<AutoDto> Autos
        {
            [OperationContract]
            get;
        }

        
        [OperationContract]
        KundeDto FindKunde(int id);
        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);
        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        KundeDto UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        KundeDto DeleteKunde(KundeDto kunde);
        List<KundeDto> Kunden
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        ReservationDto FindReservation(int id);
        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);
        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original);
        [OperationContract]
        ReservationDto DeleteReservation(ReservationDto reservation);
        List<ReservationDto> Reservationen
        {
            [OperationContract]
            get;
        }
    }
}
