using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System;

namespace AutoReservation.Common.DataTransferObjects
{
    public class KundeDto : DtoBase<KundeDto>
    {
        private string _Nachname;
        public string Nachname
        {
            get { return _Nachname; }
            set
            {
                if (_Nachname == value)
                {
                    return;
                }
                _Nachname = value;
                this.OnPropertyChanged(p => p.Nachname);
            }
        }
        private string _Vorname;
        public string Vorname
        {
            get { return _Vorname; }
            set
            {
                if (_Vorname == value)
                {
                    return;
                }
                _Vorname = value;
                this.OnPropertyChanged(p => p.Vorname);
            }
        }
        private DateTime _Geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return _Geburtsdatum; }
            set
            {
                if (_Geburtsdatum == value)
                {
                    return;
                }
                _Geburtsdatum = value;
                this.OnPropertyChanged(p => p.Geburtsdatum);
            }
        }
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id == value)
                {
                    return;
                }
                _Id = value;
                this.OnPropertyChanged(p => p.Id);
            }
        }


        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Vorname ist nicht gesetzt.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override KundeDto Clone()
        {
            return new KundeDto
            {
                Id = Id,
                Nachname = Nachname,
                Vorname = Vorname,
                Geburtsdatum = Geburtsdatum
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}",
                Id,
                Nachname,
                Vorname,
                Geburtsdatum);
        }
    }
}
