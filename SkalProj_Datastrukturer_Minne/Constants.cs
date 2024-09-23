using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class Constants
    {
        public static readonly string[] ExamineListMenuOptions =
        {
        "Press +(exact name) to add name to the List",
        "Press -(exact name) to remove name from the List",
        "Press the digit 0 to exit to the Main Menu"
    };

        public static readonly string[] ExamineQueueMenuOptions =
           {
        "Press +(exact name) to add name to the Queue",
        "Press - to remove FIFO name from the Queue",
        "Press the digit 0 to exit to the Main Menu"
    };
    }
}