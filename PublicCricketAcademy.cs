using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpQualifier30thjan.Public_Cricket_Academy
{
    internal class PublicCricketAcademy
    {
        public static List<int> PlayerList = new List<int>();

        public void AddScoreDetails(int runScored)
        {
            PlayerList.Add(runScored);
        }
        public double GetAvergaeRunsSecured()
        {
            if (PlayerList.Count == 0)
            {
                return 0;
            }
            else
            {
                var sum = PlayerList.Sum();
                return Math.Floor((sum / PlayerList.Count));
            }
        }
    }
}
