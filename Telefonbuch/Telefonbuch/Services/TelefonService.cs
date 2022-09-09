using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telefonbuch.Models;

namespace Telefonbuch.Services
{
    //Kommuniziert mit DatenBank
    public static class TelefonService
    {
        /// <summary>
        /// Sucht die Person Name Vorname und Nachname
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public static TblTelefon GetTelefonByName(string firstname, string lastname)
        {
            using (var db = new DBTelefonbuchContext())
            {
                return db.TblTelefons.Where(x=>x.Vorname == firstname && x.Nachname == lastname).FirstOrDefault();
            }
        }
        /// <summary>
        /// Schischt die erstellte Person an die Datenbank
        /// </summary>
        /// <param name="tblTelefon"></param>
        public static void SendPersonToDb(TblTelefon tblTelefon)
        {
            using (var db = new DBTelefonbuchContext())
            {
                db.TblTelefons.Add(tblTelefon);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Löscht die Person von Datenbank
        /// </summary>
        /// <param name="tblTelefon"></param>
        public static void DeleteFromDb(TblTelefon tblTelefon)
        {
            using (var db = new DBTelefonbuchContext())
            {
                db.TblTelefons.Remove(tblTelefon);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// diese methode erhielt die bearbeitete elemente und ändert die elemente innerhalb Datenbank
        /// </summary>
        /// <param name="tblTelefon"></param>
        public static void EditingInfoInDb(TblTelefon tblTelefon)
        {
            using (var db = new DBTelefonbuchContext())
            {
                var elm=db.TblTelefons.Where(x=>x.PersonId==tblTelefon.PersonId).FirstOrDefault();
                elm.Anrede = tblTelefon.Anrede;
                elm.Vorname = tblTelefon.Vorname;
                elm.Nachname = tblTelefon.Nachname;
                elm.Ort = tblTelefon.Ort;
                elm.Telefon = tblTelefon.Telefon;
                elm.Email = tblTelefon.Email;
               
                db.SaveChanges();
            }
        }

        public static List<TblTelefon> SelectAllElement()
        {
            using (var db = new DBTelefonbuchContext())
            {                         
                    return db.TblTelefons.ToList();          
            }
        }
    }
}
