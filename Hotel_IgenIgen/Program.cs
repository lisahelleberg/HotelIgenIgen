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
            ListAlleHoteller();
        }

        private static void ListAlleHoteller()
        {
            using (var db = new HotelContext()) 
            {
                var HotelList1 = from h in db.Hotel
                                 select h;

                foreach (var h in HotelList1)
                {
                    Console.WriteLine($"Hotelnummer: {h.Hotel_No}, hotelnavn: {h.Name}, hoteladresse: {h.Address}");
                }
            }
        }

        
    }
}
