﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_IgenIgen
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListAlleHoteller();
            ListAlleKunder();
        }

        private static void ListAlleHoteller()
        {
            using (var db = new HotelContext()) 
            {
                var HotelList1 = from h in db.Hotel
                                 select h;

                foreach (var h in HotelList1)
                {
                    Console.WriteLine($"Hotelnummer: {h.Hotel_No}, Hotelnavn: {h.Name}, Hoteladresse: {h.Address}");
                }
            }
        }

        private static void ListAlleKunder()
        {
            using (var db = new HotelContext())
            {
                var HotelList2 = from g in db.Guest
                                 select g;

                foreach (var g in HotelList2)
                {
                    Console.WriteLine($"Gæstenummer: {g.Guest_No}, Navn: {g.Name}, Adresse: {g.Address}");
                }
            }
        }

    }
}
