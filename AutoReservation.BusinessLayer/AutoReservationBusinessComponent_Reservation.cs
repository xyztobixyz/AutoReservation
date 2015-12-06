using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public partial class AutoReservationBusinessComponent
    {
        public Reservation FindReservation(int Id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservations.Find(Id);
            }
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
                return reservation;
            }
        }

        public Reservation UpdateReservation(Reservation modified, Reservation original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservations.Attach(original);
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

        public Reservation DeleteReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservations.Attach(reservation);
                context.Reservations.Remove(reservation);
                context.SaveChanges();
                return reservation;
            }
        }

        public List<Reservation> Reservations()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservations.ToList();
            }
        }
    }
}
