using System;
using System.Threading;

namespace Alarmcentral.Library
{
    public class Doctor : Worker, IDoctor
    {
        /// <summary>
        /// Simulates a doctor consultation.
        /// </summary>
        /// <param name="call"></param>
        public void DoctorConsultation(Call call)
        {
            TakeCall(call);
            var consultationTime = new Random().Next(0, 100) > 94 ? 1250 : new Random().Next(249, 501);
            Thread.Sleep(consultationTime);
            FinishConsultation();
        }
    }
}