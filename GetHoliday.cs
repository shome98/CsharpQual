using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpQualifier30thjan
{
    internal class GetHoliday
    {
        public static Dictionary<string, float> hotelDetails = new Dictionary<string, float>()
        {
            {"The Hay Adams",3.0f },
            {"Montage Kapalua Bay", 4.0f},
            {"Jungle Resort", 4.5f},
            {"Mandarin Oriental", 5.0f},
            {"The Greenwich Hotel", 5.0f}
        };
        public static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Search By item");
                Console.WriteLine("2.Update hotel rating");
                Console.WriteLine("3.Sort hotels by name");
                Console.WriteLine("4.Exit");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the hotel name");
                            string searchHotelName = Console.ReadLine();
                            var searchResult = SearchHotel(searchHotelName);
                            if (searchResult.Count > 0)
                            {
                                Console.WriteLine($"{searchResult.Keys.First()}{searchResult.Values.First()}");
                            }
                            else
                            {
                                Console.WriteLine("Hotel Not Found");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the hotel name");
                            string updateHotelName = Console.ReadLine();
                            Console.WriteLine("Enter the rating");
                            float updatedRating;
                            if (float.TryParse(Console.ReadLine(), out updatedRating))
                            {
                                var updateResult = UpdateHotelRating(updateHotelName, updatedRating);
                                if (updateResult.Count > 0)
                                {
                                    Console.WriteLine($"{updateResult.Keys.First()}{updateResult.Values.First()}");
                                }
                                else
                                {
                                    Console.WriteLine("Hotel Not Found");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid rating input");
                            }
                            break;
                        case 3:
                            var sortedHotels = SortByHotelName();
                            foreach (var hotel in sortedHotels)
                            {
                                Console.WriteLine($"{hotel.Key}{hotel.Value}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (choice != 4);
        }

        private static Dictionary<string,float> SortByHotelName()
        {
            var sortedHotels=hotelDetails.OrderBy(hotel=>hotel.Key).ToDictionary(hotel=>hotel.Key,hotel=>hotel.Value);  
            return sortedHotels;
        }

        private static Dictionary<string,float> UpdateHotelRating(string? updateHotelName, float updatedRating)
        {
            if (hotelDetails.ContainsKey(updateHotelName))
            {
                hotelDetails[updateHotelName] = updatedRating;
                return new Dictionary<string, float> { { updateHotelName, updatedRating } };
            }
            else
            {
                return new Dictionary<string, float>();
            }
        }

        private static Dictionary<string,float> SearchHotel(string? searchHotelName)
        {
            if (hotelDetails.ContainsKey(searchHotelName))
            {
                return new Dictionary<string, float> { { searchHotelName, hotelDetails[searchHotelName] } };
            }
            else
            {
                return new Dictionary<string , float>();
            }
        }
    }
}
