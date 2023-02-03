using System;
using System.Collections.Generic;
using System.Text;

namespace FindYourSeatsApplication.Controller
{
    class degreeConverter
    {
        public string calcDegrees(double Getdecimal)
        {
            double getCurrentDec = Getdecimal;
            float num = (int)Math.Floor(Math.Abs(getCurrentDec));
            if (getCurrentDec < 0)
            {
                getCurrentDec = getCurrentDec * -1;

            }
            double newDeg = getCurrentDec - num;
            Console.WriteLine("Degrees: " + num);

            double getMinutes = newDeg;
            double newMinutes = Math.Truncate(getMinutes * 60);
            Console.WriteLine("Minutes: " + newMinutes);


            double getSecs = newDeg;
            double getTotal = Math.Truncate((newDeg - newMinutes/60) *3600);
            
            Console.WriteLine("Seconds: " + getTotal);

            string together = num.ToString() + " " + newMinutes.ToString() + " " + getTotal.ToString();
            Console.WriteLine(together);
            return (together);
            
        }
    }
             
 }
