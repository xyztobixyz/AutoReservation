using AutoReservation.BusinessLayer;
using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;

namespace AutoReservation.Service.Wcf
{
    public partial class AutoReservationService : IAutoReservationService
    {

        private AutoReservationBusinessComponent BusinessComponent;
        public AutoReservationService()
        {
            BusinessComponent = new AutoReservationBusinessComponent();
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }
    }
}