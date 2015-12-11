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

        [OperationContract]
        List<AutoDto> Autos();

        
        [OperationContract]
        KundeDto FindKunde(int id);
        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);
        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        KundeDto UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        KundeDto DeleteKunde(KundeDto kunde);

        [OperationContract]
        List<KundeDto> Kunden();

        [OperationContract]
        ReservationDto FindReservation(int id);
        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);
        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original);
        [OperationContract]
        ReservationDto DeleteReservation(ReservationDto reservation);

        [OperationContract]
        List<ReservationDto> Reservationen();
    }
}
