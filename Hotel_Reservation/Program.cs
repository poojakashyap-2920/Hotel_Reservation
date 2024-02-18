using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel_Reservation
{
    public class Program
    {
        private static string hotelname;
        private static double rate;
        private static double weekendreward;
        private static double weekendregular;
        private static double weekregular;
        private static double weekreward;
        public static List<HotelPoco> list = new List<HotelPoco>();

        public string WeekendRateRegular { get; set; }

        public static void Main(string[] args)
        {

            Console.WriteLine(" ***** Welcome to hotel Reservation *****\n");
            // Console.WriteLine("enter hotel name");
            hotelname = ValidInput("enter hotel name", "message");

          //  Console.WriteLine("enter hotel rate");
            rate = double.Parse(ValidIntegerValue("enter hotel rate",1));

           // Console.WriteLine("enter weekendRegular");
            weekendregular = double.Parse(ValidIntegerValue("enter weekendRegular", 4));

          //  Console.WriteLine("enter weekendReward");
            weekendreward = double.Parse(ValidIntegerValue("enter weekendReward", 4));

           // Console.WriteLine("enter weekRegular");
            weekregular = double.Parse(ValidIntegerValue("enter weekRegular", 4));

         //   Console.WriteLine("enter weekReward");
            weekreward = double.Parse(ValidIntegerValue("enter weekReward", 4));

            HotelPoco ob = new HotelPoco()
            {
                HotelName = hotelname,
                HotelRate = rate,
                WeekendRateRegular = weekendregular,
                WeekendRateReward = weekendreward,
                WeekRegular = weekregular,
                WeekReward = weekreward
            };
            list.Add(ob);
            Console.WriteLine("****** Hotel detail Added successfully..******\n");
            while (true)
            {
                Console.WriteLine("1. Add Hotel Detail\n" +
                                  "2. Show Hotel Detail\n" +
                                  "3. Book Hotel");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ob.HotelDetailAdd();

                        break;

                    case 2:
                        ob.HotelShow(list);
                        Console.WriteLine("***** Hotel detail *****\n");
                        break;

                    case 3:
                        ob.BookHotel(list);
                        Console.WriteLine("");
                        break;
                }
            }

            string ValidInput(string prompt, string message)
            {
                string input;
                while (true)
                {
                    Console.WriteLine(prompt);
                    input = Console.ReadLine();
                    try
                    {
                        if (input == null)
                        {
                            Console.WriteLine("input is null value");
                        }
                        else
                        {
                            if (!Regex.IsMatch(input, @"^[A-Z][a-zA-Z]{4,15}$"))
                            {
                                throw new Exception("input start with Uppercase minimum 5 and maximum  15 character");
                            }
                            else { Console.WriteLine(input); }
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalis input" + e.Message);
                    }
                }
                return input;
            }

            string ValidIntegerValue(string prompt, int len)
            {
                string input;
                while (true)
                {
                    Console.WriteLine(prompt);
                    input = Console.ReadLine();
                    try
                    {
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Please provide input");
                            continue; // Continue the loop to prompt again
                        }

                        if (!Regex.IsMatch(input, @"^[1-9]\d{0,3}$")) // Modified regex to disallow leading zeros
                        {
                            throw new FormatException("Only integer values with a maximum of 4 digits are allowed.");
                        }
                        break;
                    }
                       
                    
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input" + e.Message);
                    }

                }
                return input;
            }




        }
    }
}