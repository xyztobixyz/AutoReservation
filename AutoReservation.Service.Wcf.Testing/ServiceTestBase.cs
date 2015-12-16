using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
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
            Assert.AreEqual(3, Target.Autos().Count);
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            Assert.AreEqual(4, Target.Kunden().Count);
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            Assert.AreEqual(3, Target.Reservationen().Count);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            Assert.AreEqual(Target.FindAuto(2).Marke, Target.Autos().Find(dto => dto.Id == 2).Marke);
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            Assert.AreEqual(Target.FindKunde(2).Vorname, Target.Kunden().Find(dto => dto.Id == 2).Vorname);
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            Assert.AreEqual(Target.FindReservation(2).Auto.Marke, Target.FindAuto(2).Marke);
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            Assert.IsNull(Target.FindReservation(10));
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            var test = new AutoDto();
            test.Id = 10;
            test.AutoKlasse = AutoKlasse.Mittelklasse;
            test.Marke = "WOW Auto! Much Auto!";

            var oldCount = Target.Autos().Count;
            Target.InsertAuto(test);
            Assert.AreEqual(oldCount + 1, Target.Autos().Count);
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            var test = new KundeDto();
            test.Id = 10;
            test.Vorname = "Der";
            test.Nachname = "Hanslii";
            test.Geburtsdatum = DateTime.Today;

            var oldCount = Target.Kunden().Count;
            Target.InsertKunde(test);
            Assert.AreEqual(oldCount + 1, Target.Kunden().Count);
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            ReservationDto test = new ReservationDto();
            test.ReservationNr = 10;
            test.Auto = Target.Autos()[0];
            test.Kunde = Target.Kunden()[0];
            test.Bis = DateTime.Now;
            test.Von = DateTime.Today;

            var oldCount = Target.Reservationen().Count;
            Target.InsertReservation(test);
            Assert.AreEqual(oldCount + 1, Target.Reservationen().Count);
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            var modified = Target.Autos()[0];
            var original = Target.Autos()[0];

            modified.Marke = "Duckling";
            Target.UpdateAuto(modified, original);

            Assert.AreEqual(Target.Autos()[0].Marke, "Duckling");
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            var modified = Target.Kunden()[0];
            var original = Target.Kunden()[0];

            modified.Vorname = "Sepplii";
            Target.UpdateKunde(modified, original);

            Assert.AreEqual(Target.Kunden()[0].Vorname, "Sepplii");
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            var modified = Target.Reservationen()[0];
            var original = Target.Reservationen()[0];
            var time = DateTime.Today;

            modified.Bis = time;
            Target.UpdateReservation(modified, original);

            Assert.AreEqual(Target.Reservationen()[0].Bis.Ticks, time.Ticks);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            var original = Target.FindAuto(1);
            var modified = Target.FindAuto(1);
            var modified2 = Target.FindAuto(1);

            modified.Marke = "TESSt";
            modified2.Marke = "asdf";

            Target.UpdateAuto(modified, original);
            Target.UpdateAuto(modified2, original);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            var original = Target.FindKunde(1);
            var modified = Target.FindKunde(1);
            var modified2 = Target.FindKunde(1);

            modified.Vorname = "TESSt";
            modified2.Vorname = "asdf";

            Target.UpdateKunde(modified, original);
            Target.UpdateKunde(modified2, original);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            var original = Target.FindReservation(1);
            var modified = Target.FindReservation(1);
            var modified2 = Target.FindReservation(1);

            modified.Von = DateTime.Today;
            modified2.Von = DateTime.Today.AddDays(1);

            Target.UpdateReservation(modified, original);
            Target.UpdateReservation(modified2, original);
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Target.DeleteKunde(Target.FindKunde(1));
            Assert.AreEqual(3, Target.Kunden().Count);
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Target.DeleteAuto(Target.FindAuto(1));
            Assert.AreEqual(2, Target.Autos().Count);
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Target.DeleteReservation(Target.FindReservation(2));
            Assert.IsNull(Target.FindReservation(2));
        }
    }
}
