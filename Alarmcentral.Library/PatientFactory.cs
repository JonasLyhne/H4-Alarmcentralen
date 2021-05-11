using System;

namespace Alarmcentral.Library
{
    // TODO: Refactor EVERYTHING!
    public class PatientFactory
    {
        private Random rnd = new Random();
        
        public Patient CreatePatient() 
        {
            var pt = new Patient();
            pt.Number = GeneratePhoneNumber();
            pt.IsBeingConsulted = false;
            pt.IsCritical = IsPatientCirtical();
            pt.TimeCalled = DateTime.Now;
            return pt;
        }

        private string GeneratePhoneNumber()
        {
            return rnd.Next(10000, 99999).ToString();
        }

        private bool IsPatientCirtical()
        {
            return rnd.Next(0, 100) > 90;
        }
    }
}