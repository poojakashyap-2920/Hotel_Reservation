using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Hotel_Reservation
{
    public class HotelPoco
    {
      
        public string HotelName { get; set; }
        public double HotelRate { get; set; }
        public double WeekendRateRegular { get; set; }
        public double WeekendRateReward { get; set; }
        public double WeekRegular { get; set; }
        public double WeekReward { get; set; }

      public void HotelDetailAdd()
        {
            Hotel_Reservation.Program.Main(new string[] { });
           

        }
        int i = 1;
        private object dictval;

        public void HotelShow(List<HotelPoco> list)
        {
            
            foreach (HotelPoco hotel in list)
            {
                Console.WriteLine($"HotelName: {hotel.HotelName}\nHotelRate: {hotel.HotelRate}\nWeekendRegular: {hotel.WeekendRateRegular}\nWeekendReward: {hotel.WeekendRateReward}\nWeekRegular: {hotel.WeekRegular}\nWeekReward: {hotel.WeekReward}");
                Console.WriteLine("Hotel" + i + " details\n");
                i++;
            }
           
        }

        public void BookHotel(List<HotelPoco> li)
        {
            Console.WriteLine("Enter customer type: .Regular . Reward");
            string option = Console.ReadLine()?.ToLower();
            switch (option)
            {
                
                case "regular":
                    Console.WriteLine("Enter start date (dd/mm/yyyy):");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter end date (dd/mm/yyyy):");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());

                    Dictionary<string, double> dict = new Dictionary<string, double>();

                    foreach (var hotel in li)
                    {
                        double total = 0;
                        for (DateTime currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
                        {
                            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                total += hotel.WeekendRateRegular;
                            }
                            else
                            {
                                total += hotel.WeekRegular;
                            }
                        }
                        if (dict.ContainsKey(hotel.HotelName))
                        {
                            Console.WriteLine("Duplicate key");
                        }
                        else
                        {
                            dict.Add(hotel.HotelName, total);
                        }
                    }

                  
                  while(true)
                    {
                        Console.WriteLine("1 Cheapest Hotel\n" +
                      "2.Best Rate hotel");
                        int rateoption = Convert.ToInt32(Console.ReadLine());
                       switch(rateoption)
                        {
                            case 1:

                                var cheapestHotel = dict.OrderBy(kv => kv.Value).First();

                                Console.WriteLine($"Cheapest Hotel: {cheapestHotel.Key}, Total Cost: {cheapestHotel.Value}");

                                Console.WriteLine("All Hotel Details:");
                                foreach (var kvp in dict)
                                {
                                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                                }

                                break;

                            case 2:
                                if (dict.Count > 0)
                                {
                                    double highestValue = double.MinValue;
                                    string highestHotelName = null;

                                    foreach (var pair in dict)
                                    {
                                        if (pair.Value > highestValue)
                                        {
                                            highestValue = pair.Value;
                                            highestHotelName = pair.Key;
                                        }
                                    }

                                    if (highestHotelName != null)
                                    {
                                        Console.WriteLine($"Hotel with highest rate: {highestHotelName}, Rate: {highestValue}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Dictionary is empty");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Dictionary is empty");
                                }
                                break;

                        }

                    }


                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;


                case "reward":
                    Console.WriteLine("Enter start date (dd/mm/yyyy):");
                    DateTime startDate1 = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter end date (dd/mm/yyyy):");
                    DateTime endDate1 = DateTime.Parse(Console.ReadLine());

                    Dictionary<string ,double> dict1 = new Dictionary<string ,double>();
                  
                    foreach (var item in li)
                    {
                        double total1 = 0;
                        Console.WriteLine("value" + item.WeekendRateReward);
                        for (DateTime currentDate = startDate1; currentDate < endDate1; currentDate = currentDate.AddDays(1))
                        {
                            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                total1 = total1 + item.WeekendRateReward;
                            }
                            else
                            {
                                total1 += item.WeekReward;
                            }
                        }

                        if (dict1.ContainsKey(item.HotelName))
                            {
                            Console.WriteLine("duplicate key");
                           }
                        else
                        {
                            dict1.Add(item.HotelName, total1);
                        }

                    }
                    /*  var chepestHotel1 = dict1.OrderBy(x=>x.Value).First();
                      Console.WriteLine($"Cheapest Hotel: {chepestHotel1.Key}, Total Cost: {chepestHotel1.Value}");

                      Console.WriteLine("All Hotel Details:");
                      foreach (var revval in dict1)
                      {
                          Console.WriteLine($"{revval.Key} : {revval.Value}");
                      }*/
                    while (true)
                    {
                        Console.WriteLine("1 Cheapest Hotel\n" +
                      "2.Best Rate hotel");
                        int rateoption = Convert.ToInt32(Console.ReadLine());
                        switch (rateoption)
                        {
                            case 1:

                                var chepestHotel1 = dict1.OrderBy(x => x.Value).First();
                                Console.WriteLine($"Cheapest Hotel: {chepestHotel1.Key}, Total Cost: {chepestHotel1.Value}");

                                Console.WriteLine("All Hotel Details:");
                                foreach (var revval in dict1)
                                {
                                    Console.WriteLine($"{revval.Key} : {revval.Value}");
                                }
                                    break;

                            case 2:
                                if (dict1.Count > 0)
                                {
                                    double highestValue = double.MinValue;
                                    string highestHotelName = null;

                                    foreach (var pair in dict1)
                                    {
                                        if (pair.Value > highestValue)
                                        {
                                            highestValue = pair.Value;
                                            highestHotelName = pair.Key;
                                        }
                                    }

                                    if (highestHotelName != null)
                                    {
                                        Console.WriteLine($"Hotel with highest rate: {highestHotelName}, Rate: {highestValue}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Dictionary is empty");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Dictionary is empty");
                                }
                                break;

                        }

                    }

                    break;
             


            }

          
        }

     
        

    }
}
