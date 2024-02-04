using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpQualifier30thjan.ConTvSolution
{
    internal class InstallationDetails:Installation
    {
        public void GetCustomerFeedback()
        {
            // DateTime expectedDate = DateTime.ParseExact(ExpectedDate,"MM/dd/YYYY",CultureInfo invariantCulture);
            DateTime expectedDate = DateTime.Parse(ExpectedDate);
            DateTime installDate = DateTime.Parse(InstalledDate);
            if(DateTime.Compare(expectedDate, installDate) < 0)
            {
                Feedback = "Very Good";
            }
           if(DateTime.Compare(expectedDate,installDate) ==0) 
            {
                Feedback = "Good";
            }
            if ((installDate-expectedDate).Days<=3)
            {
                Feedback = "Average";
            }
            if ((installDate - expectedDate).Days >= 3)
            {
                Feedback = "Poor";
            }

        }
        public double CalculateRating() { 
            
            switch(Feedback)
            {
                case "Very Good":
                    Rating += Rating * 0.5;
                    break;
                case "Good":
                    Rating += Rating * 0.2;
                    break;
                case "Average":
                    Rating -= Rating * 0.2;
                    break;
                case "Poor":
                    Rating -= Rating * 0.5;
                    break;

            }
            return Rating;
        }
    }
}
