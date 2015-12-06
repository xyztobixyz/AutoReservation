using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public partial class AutoReservationBusinessComponent
    {
        public Auto FindAuto(int Id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Autoes.Find(Id);
            }
        }

        public Auto InsertAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Autoes.Add(auto);
                context.SaveChanges();
                return auto;
            }
        }

        public Auto UpdateAuto(Auto modified, Auto original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autoes.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                    return original;
                }
                catch(DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
            return null;
        }

        public Auto DeleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Autoes.Attach(auto);
                context.Autoes.Remove(auto);
                context.SaveChanges();
                return auto;
            }
        }

        public List<Auto> Autos()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Autoes.ToList();
            }
        }
    }
}
