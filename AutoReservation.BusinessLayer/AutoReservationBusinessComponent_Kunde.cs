using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public partial class AutoReservationBusinessComponent
    {
        public Kunde FindKunde(int Id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kundes.Find(Id);
            }
        }

        public Kunde InsertKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kundes.Add(kunde);
                context.SaveChanges();
                return kunde;
            }
        }

        public Kunde UpdateKunde(Kunde modified, Kunde original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kundes.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                    return original;
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
            return null;
        }

        public Kunde DeleteKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kundes.Attach(kunde);
                context.Kundes.Remove(kunde);
                context.SaveChanges();
                return kunde;
            }
        }

        public List<Kunde> Kunden()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kundes.ToList();
            }
        }
    }
}
