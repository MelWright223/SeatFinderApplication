using System;
using System.Collections.Generic;
using System.Text;

namespace FindYourSeatsApplication.Controller
{
    class degreeConverter
    {
        public int calcDegrees(double Getdecimal)
        {
            double getCurrentDec = Getdecimal;
            int num = (int)Math.Floor(Math.Abs(getCurrentDec));
            if (getCurrentDec < 0)
            {
                getCurrentDec = getCurrentDec * -1;

            }
            
            // Console.WriteLine("Degrees: " + num);
            return num;
            

        }
        public double CalMinutes(double GetDeg, int num) {
            if (GetDeg < 0)
            {
                GetDeg = GetDeg * -1;

            }
            double getMinutes = GetDeg - num;
            
            double newMinutes = Math.Truncate(getMinutes * 60);
           // Console.WriteLine("Minutes: " + newMinutes);
            return newMinutes;
        }

       //public double calSecs(double GetDeg, )
        //{
          //  double getDeg = GetDeg;
            //double getMins = CalMinutes(GetDeg);
            //double getTotal = Math.Truncate((GetDeg - getMins / 60) * 3600);

            //Console.WriteLine("Seconds: " + getTotal);
            //return getTotal;

       // }
           // string together = num.ToString() + " " + newMinutes.ToString() + " " + getTotal.ToString();
            //Console.WriteLine(together);
           // return (together);
            
        
    }
             
 }
