using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System;

namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto : DtoBase<ReservationDto>
    {
        private DateTime _Von;
        public DateTime Von
        {
            get { return _Von; }
            set
            {
                if (_Von == value)
                {
                    return;
                }
                _Von = value;
                this.OnPropertyChanged(p => p.Von);
            }
        }
        private DateTime _Bis;
        public DateTime Bis
        {
            get { return _Bis; }
            set
            {
                if (_Bis == value)
                {
                    return;
                }
                _Bis = value;
                this.OnPropertyChanged(p => p.Bis);
            }
        }
        private AutoDto _Auto;
        public AutoDto Auto
        {
            get { return _Auto; }
            set
            {
                if (_Auto == value)
                {
                    return;
                }
                _Auto = value;
                this.OnPropertyChanged(p => p.Auto);
            }
        }
        private KundeDto _Kunde;
        public KundeDto Kunde
        {
            get { return _Kunde; }
            set
            {
                if (_Kunde == value)
                {
                    return;
                }
                _Kunde = value;
                this.OnPropertyChanged(p => p.Kunde);
            }
        }
        private int _ReservationNr;
        public int ReservationNr
        {
            get { return _ReservationNr; }
            set
            {
                if (_ReservationNr == value)
                {
                    return;
                }
                _ReservationNr = value;
                this.OnPropertyChanged(p => p.ReservationNr);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override ReservationDto Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = Auto.Clone(),
                Kunde = Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }
    }
}
