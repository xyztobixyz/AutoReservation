using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto : DtoBase<AutoDto>
    {
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
        private string _Marke;
        public string Marke
        {
            get { return _Marke; }
            set
            {
                if (_Marke == value)
                {
                    return;
                }
                _Marke = value;
                this.OnPropertyChanged(p => p.Marke);
            }
        }
        private int _Tagestarif;
        public int Tagestarif
        {
            get { return _Tagestarif; }
            set
            {
                if (_Tagestarif == value)
                {
                    return;
                }
                _Tagestarif = value;
                this.OnPropertyChanged(p => p.Tagestarif);
            }
        }
        private int _Basistarif;
        public int Basistarif
        {
            get { return _Basistarif; }
            set
            {
                if (_Basistarif == value)
                {
                    return;
                }
                _Basistarif = value;
                this.OnPropertyChanged(p => p.Basistarif);
            }
        }
        private AutoKlasse _AutoKlasse;
        public AutoKlasse AutoKlasse
        {
            get { return _AutoKlasse; }
            set
            {
                if (_AutoKlasse == value)
                {
                    return;
                }
                _AutoKlasse = value;
                this.OnPropertyChanged(p => p.AutoKlasse);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (Tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && Basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override AutoDto Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasse = AutoKlasse,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasse);
        }
    }
}
