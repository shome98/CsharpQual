using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub
{
    public class HotelBill
    {
        public string BillNo { get; set; }
        public double BillAmount { get; set; }
        public string Status { get; set; }
    }
    public class Program
    {
        public static List<HotelBill> billList = new List<HotelBill>();
        public List<HotelBill> GetBillDetails(string billNo)
        {
            var newList = new List<HotelBill>();
            foreach (var bill in billList)
            {
                if (bill.BillNo.Equals(billNo))
                {
                    newList.Add(bill);
                }
            }
            return newList;
        }
        public List<HotelBill> UpdateBillStatus(string billNo, string status)
        {
            var newList = new List<HotelBill>();
            foreach (var bill in billList)
            {
                if (bill.BillNo == billNo)
                {
                    bill.Status = status;
                    newList.Add(bill);
                }
            }
            return newList;
        }
        public List<HotelBill> SortBilllByStatus()
        {
            var newList = billList.OrderByDescending(bill => bill.Status).ToList();
            return newList;
        }

        public static void Main(string[] args)
        {
            HotelBill hb = new HotelBill() { BillNo = "H01", BillAmount = 980, Status = "Paid" };
            billList.Add(hb);
            int choice;
            Program obj = new Program();
            do
            {
                Console.WriteLine("1. Get bill details");
                Console.WriteLine("2. Update Bill Status");
                Console.WriteLine("3.Sort Bill By Status");
                Console.WriteLine("4. Exit");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter bill Number");
                            string billNo = Console.ReadLine();
                            var billDetails = obj.GetBillDetails(billNo);
                            if (billDetails.Count > 0)
                            {
                                Console.WriteLine($"BillNo\tBillAmount\tStatus");
                                foreach (var bill in billDetails)
                                {
                                    Console.WriteLine($"{bill.BillNo}\t{bill.BillAmount}\t{bill.Status}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid bill Number");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter bill Number");
                            string getbillNo = Console.ReadLine();
                            Console.WriteLine("Enter bill status");
                            string billStatus = Console.ReadLine();
                            var getbillDetails = obj.UpdateBillStatus(getbillNo, billStatus);
                            if (getbillDetails.Count > 0)
                            {
                                Console.WriteLine($"BillNo\tBillAmount\tStatus");
                                foreach (var bill in getbillDetails)
                                {
                                    Console.WriteLine($"{bill.BillNo}\t{bill.BillAmount}\t{bill.Status}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid bill Number");
                            }
                            break;
                        case 3:
                            var sbillDetails = obj.SortBilllByStatus();
                            Console.WriteLine($"BillNo\tBillAmount\tStatus");
                            foreach (var bill in sbillDetails)
                            {
                                Console.WriteLine($"{bill.BillNo}\t{bill.BillAmount}\t{bill.Status}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                        default:
                            Console.WriteLine("Enter valid choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("invalid  choice");
                }
            } while (choice != 4);
        }
    }

}
