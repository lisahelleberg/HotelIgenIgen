using System;
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
            //ListAlleKunder();
            //ListRoom();
            Reservations();
        }

        // List alle informationer om alle hotellerne
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

        // List alle informationer om alle hotellerne
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
        // List hotelnavn, adresse, samt værelsesinformation(nr, type, pris) om de værelser hotellerne har. 
        private static void ListRoom()
        {
            using (var db = new HotelContext())
            {
                var HotelList3 = from h in db.Hotel
                                 join r in db.Room
                                 on h.Hotel_No equals r.Hotel_No
                                 select new { h.Name, h.Address, r.Room_No, r.Types, r.Price };

                foreach (var item in HotelList3)
                {
                    Console.WriteLine($"Hotelnavn: {item.Name}, adresse: {item.Address}, Værelsesnummer:{item.Room_No}, type: {item.Types}, pris: {item.Price}");
                    Console.WriteLine();
                }
            }
        }

        // List alle de reservationer hver enkelt værelse har.
        private static void Reservations()
        {
            using (var db = new HotelContext())
            {
                var HotelList4 = from b in db.Booking
                                 join h in db.Hotel
                                 on b.Hotel_No equals h.Hotel_No
                                 orderby h.Hotel_No
                                 select new { h.Name, b.Room_No, b.Booking_id, b.Date_From, b.Date_To };

                foreach (var item in HotelList4)
                {
                    Console.WriteLine($"Hotelnavn: {item.Name}, værelsesnummer: {item.Room_No}, BookingID: {item.Booking_id}, \n   fra: {item.Date_From}, til: {item.Date_To}");
                }
            }
        }
    }
}
