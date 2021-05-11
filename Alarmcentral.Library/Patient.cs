using System;

namespace Alarmcentral.Library
{
    public class Patient
    {
        public string Number { get; set; }

        public bool IsCritical { get; set; }

        public DateTime TimeCalled { get; set; }

        public bool IsBeingConsulted { get; set; }
    }
}