using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace EXeption
{
    public class Presone
    {
        

        public string InputRoom{ get; set; } 
        public string InputName { get; set; } 

        public DateTime TimeIn { get; set; }  
        public DateTime TimeOff { get; set;} 

        public TimeSpan TotalTime { get; set; }

        public Presone(string inputRoom, string inputName, DateTime timeIn, DateTime timeOff, TimeSpan totalTime)
        {
            InputRoom = inputRoom;
            InputName = inputName;
            TimeIn = timeIn;
            TimeOff = timeOff;
            TotalTime = totalTime;
        }
        

        public string  GetFulldetail()
        {
            return $" User Name: {this.InputName}\n Room Numbre: {this.InputRoom}\n Date/Time Entre {this.TimeIn}\n Date/Time Exit the room {this.TimeOff}\n Total in the room {this.TotalTime} ";
        } 

    }
}