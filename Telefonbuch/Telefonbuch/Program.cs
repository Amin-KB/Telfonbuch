using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Telefonbuch.Models;
using Telefonbuch.Services;

namespace Telefonbuch
{
    internal class Program
    {

       static ConsoleColor color_f1 =ConsoleColor.DarkGreen;
        static ConsoleColor color_f3 = ConsoleColor.DarkGreen;
        static ConsoleColor color_f2 =ConsoleColor.White;
        static int sublistIndex = 0;
        static void Main(string[] args)
        {
            Menu();
        }
        /// <summary>
        /// erstellt einen TblTelefon object
        /// </summary>
        static void Create()
        {
            var telefonnumber = new TblTelefon();
            do
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Anrede: ");
                Console.ResetColor();   
                telefonnumber.Anrede = Console.ReadLine();
            } while (telefonnumber.Anrede == default);
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vorname: ");
                Console.ResetColor();
                telefonnumber.Vorname = Console.ReadLine();
            } while (telefonnumber.Vorname == default);
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nachname: ");
                Console.ResetColor();
                telefonnumber.Nachname = Console.ReadLine();
            } while (telefonnumber.Nachname == default);
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ort: ");
                Console.ResetColor();
                telefonnumber.Ort = Console.ReadLine();
            } while (telefonnumber.Ort == default);
            do
            {               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Telefon Nummmer: ");
                Console.ResetColor();
                telefonnumber.Telefon = Console.ReadLine();
            } while (telefonnumber.Telefon == default);
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email: ");
                Console.ResetColor();
                telefonnumber.Email = Console.ReadLine();
            } while (telefonnumber.Email == default);
            Telefonbuch.Services.TelefonService.SendPersonToDb(telefonnumber);
        }
        /// <summary>
        /// Sucht und bekommt eine oder null TblTelefun Object und schickt die object weiter
        /// </summary>
        static void Search()
        {
           
                string vorname = "";
            string nachname = "";
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vorname: ");
                Console.ResetColor();   
                vorname = Console.ReadLine();
            } while (vorname == default);
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nachname: ");
                Console.ResetColor();
                nachname = Console.ReadLine();
            } while (nachname == default);




            var info = Telefonbuch.Services.TelefonService.GetTelefonByName(vorname, nachname);
            if (info == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keine Info wurde gefunden");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Id: ");
                Console.ResetColor();
                Console.WriteLine(info.PersonId);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Anrede: ");
                Console.ResetColor();
                Console.WriteLine(info.Anrede);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Vorname: ");
                Console.ResetColor();
                Console.WriteLine(info.Vorname);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nachname: ");
                Console.ResetColor();
                Console.WriteLine(info.Nachname);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ort: ");
                Console.ResetColor();
                Console.WriteLine(info.Ort);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tefonnummer: ");
                Console.ResetColor();
                Console.WriteLine(info.Telefon);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Email: ");
                Console.ResetColor();
                Console.WriteLine(info.Email);
            }
        }

        /// <summary>
        /// druckt Attributevon nur eone TbltTelefun object
        /// </summary>
        /// <returns></returns>
        static TblTelefon Print()
        {
            string vorname = "";
            string nachname = "";
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vorname: ");
                Console.ResetColor();
                vorname = Console.ReadLine();
            } while (vorname == default);
            do
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Nachname: ");
                Console.ResetColor();
                nachname = Console.ReadLine();
            } while (nachname == default);
            var info = Telefonbuch.Services.TelefonService.GetTelefonByName(vorname, nachname);
            if (info == null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Keine Info wurde gefunden");
                Console.ResetColor();
                return null;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Id: ");
                Console.ResetColor();
                Console.WriteLine(info.PersonId);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Anrede: ");
                Console.ResetColor();
                Console.WriteLine(info.Anrede);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Vorname: ");
                Console.ResetColor();
                Console.WriteLine(info.Vorname);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nachname: ");
                Console.ResetColor();
                Console.WriteLine(info.Nachname);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ort: ");
                Console.ResetColor();
                Console.WriteLine(info.Ort);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tefonnummer: ");
                Console.ResetColor();
                Console.WriteLine(info.Telefon);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Email: ");
                Console.ResetColor();
                Console.WriteLine(info.Email);
                return info;


            }
        }
        /// <summary>
        /// barbeitet auf die TblTelefun object
        /// </summary>
        static void Edit()
        {
            var telefonnumber = Print();
            if (telefonnumber != null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wollen Sie die Datei bearbeiten Y/N: ");
                Console.ResetColor();
                string answer = Console.ReadLine();

                if (answer.ToUpper().Contains("Y"))
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Anrede: ");
                        Console.ResetColor();
                        telefonnumber.Anrede = Console.ReadLine();
                    } while (telefonnumber.Anrede == default);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Vorname: ");
                        Console.ResetColor();
                        telefonnumber.Vorname = Console.ReadLine();
                    } while (telefonnumber.Vorname == default);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nachname: ");
                        Console.ResetColor();
                        telefonnumber.Nachname = Console.ReadLine();
                    } while (telefonnumber.Nachname == default);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ort: ");
                        Console.ResetColor();
                        telefonnumber.Ort = Console.ReadLine();
                    } while (telefonnumber.Ort == default);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Telefon Nummmer: ");
                        Console.ResetColor();
                        telefonnumber.Telefon = Console.ReadLine();
                    } while (telefonnumber.Telefon == default);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Email: ");
                        Console.ResetColor();
                        telefonnumber.Email = Console.ReadLine();
                    } while (telefonnumber.Email == default);
                    Telefonbuch.Services.TelefonService.EditingInfoInDb(telefonnumber);
                }
               
            }

            else
            {
                return;
            }


        }

        /// <summary>
        /// Stöniert die TblTelefun object
        /// </summary>
    static void Delete()
        {
            var telefonnumber = Print();
            if (telefonnumber != null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wollen Sie die Datei Löschen Y/N: ");
                Console.ResetColor();
                string answer = Console.ReadLine();

                if (answer.ToUpper().Contains("Y"))
                    Telefonbuch.Services.TelefonService.DeleteFromDb(telefonnumber);
            }
           
            else
                return;
          
        }
        /// <summary>
        /// Listet alle objecte in DbSets TblTelefon
        /// </summary>
        static void Listing()
        {
            
                var telefonnumbers = Services.TelefonService.SelectAllElement();
            var sublist = GenericService.Partition(telefonnumbers, 2);
            if (sublistIndex > 0)
            {
                color_f2 = ConsoleColor.DarkGreen;
            }
            if (sublistIndex == 0)
            {
                color_f2 = ConsoleColor.White;
            }
            if (sublistIndex == sublist.Count - 1)
            {
                color_f1 = ConsoleColor.White;
            }
            if (sublistIndex < sublist.Count - 1)
            {
                color_f1 = ConsoleColor.DarkGreen;
            }
            foreach (var telefonnumber in sublist[sublistIndex])
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Id: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.PersonId);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Anrede: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.Anrede);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Vorname: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.Vorname);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Nachname: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.Nachname);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ort: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.Ort);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Tefonnummer: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.Telefon);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Email: ");
                    Console.ResetColor();
                    Console.WriteLine(telefonnumber.Email);
                }
            Console.WriteLine("*****************");

            Console.ForegroundColor= ConsoleColor.DarkYellow;  
            Console.WriteLine("page: "+(sublistIndex+1));
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = color_f1;
            Console.WriteLine("Next.....F1");

            Console.ResetColor();
            Console.ForegroundColor = color_f2;
            Console.WriteLine("Back.....F2");

            Console.ResetColor();

            Console.ForegroundColor = color_f3;
            Console.WriteLine("Exit.....F3");

            Console.ResetColor();
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1 && sublistIndex <= sublist.Count)
            {
                Console.Clear();
                if (sublistIndex >= sublist.Count - 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("es gibt kein mehrere Elemente: ");
                    Console.ResetColor();
                    return;
                }
                sublistIndex++;
                Listing();
            }


            if (key.Key == ConsoleKey.F2 && sublistIndex <= sublist.Count && sublistIndex == 0)
            {
                Console.Clear();


                Listing();
            }
            if (key.Key == ConsoleKey.F2 && sublistIndex <= sublist.Count && sublistIndex != 0)
            {
                Console.Clear();
                sublistIndex--;
                Listing();
            }

            if (key.Key == ConsoleKey.F3)
            {

                return;
            }



        }
        private static void Menu()
        {
            
            byte index = 0;
            bool loop = false;
            do
            {
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("0----Exit");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1----Erstellen");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2----Auflisten");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("3----Suchen");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("4----Bearbeiten");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("5----Stönieren");
                Console.ResetColor();



                loop = byte.TryParse(Console.ReadLine(), out index);
                Console.Clear();
                switch (index)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    case 1:
                        Create();
                        break;
                    case 2:
                        Listing();
                        break;
                    case 3:
                        Search();
                        break;
                    case 4:
                        Edit();
                        break;
                    case 5:
                        Delete();
                        break;
                }

            } while (!loop || index != 0);
        }
        
    }
}

