using System;
using System.Collections.Generic;

#nullable disable

namespace Telefonbuch.Models
{
    public partial class TblTelefon
    {
        public int PersonId { get; set; }
        public string Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Ort { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
