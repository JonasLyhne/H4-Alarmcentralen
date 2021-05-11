using System;

namespace Alarmcentral.Library
{
    public class Call
    {
        public Patient Patient { get; private set; }
        public string CallerNumber { get; set; }
        public bool CallerIsOnTheLine { get; set; }
        
        public Call(Patient patient)
        {
            Patient = patient;
            CallerNumber = patient.Number;
            CallerIsOnTheLine = CallerStaysOnTheLine();
        }

        private bool CallerStaysOnTheLine()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100) > 90;
        }
        
    }
}