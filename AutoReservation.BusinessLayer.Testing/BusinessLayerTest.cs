using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_UpdateAuto()
        {
            
            Auto auto=Target.FindAuto(1);
            Auto auto2 = Target.FindAuto(1);
            auto2.Marke = "Fiat Panda";
            Target.UpdateAuto(auto2, auto);
            Assert.AreEqual("Fiat Panda", Target.FindAuto(1).Marke);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Kunde kunde = Target.FindKunde(1);
            Kunde kunde2 = Target.FindKunde(1);
            kunde2.Nachname = "Meier";
            Target.UpdateKunde(kunde2, kunde);
            Assert.AreEqual("Meier", Target.FindKunde(1).Nachname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Reservation reservation = Target.FindReservation(2);
            Reservation reservation2 = Target.FindReservation(2);
            reservation2.KundeId = 1;
            Target.UpdateReservation(reservation2, reservation);
            Assert.AreEqual(1, Target.FindReservation(2).KundeId);
        }
    }
}
