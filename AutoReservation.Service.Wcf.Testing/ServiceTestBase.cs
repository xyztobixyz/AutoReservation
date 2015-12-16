using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void Test_GetAutos()
        {
            //ListDto von autos erstellen
            Assert.Inconclusive( , Target.Autos);
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            Assert.Inconclusive( , Target.Kunden);
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            Assert.Inconclusive( , Target.Reservationen);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            Auto auto = new StandardAuto();
            auto.Id = 5;
            auto.Marke = "Auti S6";
            Assert.Inconclusive(auto.Marke, Target.FindAuto(3).Marke);
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            Kunde kunde = new Kunde();
            kunde.Nachname = "Zufall";
            Assert.Inconclusive(kunde.Nachname, Target.FindKunde(4).Nachname);
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            Reservation reservation = new Reservation();
            reservation.KundeId = 1;
            reservation.AutoId = 1;
            Assert.Inconclusive(reservation.AutoId, Target.FindReservation(1).Auto);
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            AutoDto auto = new AutoDto();
            Target.InsertAuto(auto);
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }
    }
}
