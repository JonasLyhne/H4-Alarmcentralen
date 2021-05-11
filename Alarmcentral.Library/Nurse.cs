using System;
using System.Threading;

namespace Alarmcentral.Library
{
    /// <summary>
    /// This class simulates a nurse, who can do consultations
    /// for non critical patients.
    /// </summary>
    public class Nurse : Worker, INurse
    {
        public Call MoveCriticalPatientToDoctorQueue()
        {
            return Call;
        }

        /// <summary>
        /// Checks if patient is a critical patient.
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public Call CheckIfPatientIsCritical(Call call)
        {
            TakeCall(call);
            if (this.Call.Patient.IsCritical)
            {
                return call;
            }
            else
            {
                NurseConsultation();
            }

            return null;
        }

        /// <summary>
        /// Simulates a nurse consultation.
        /// </summary>
        public void NurseConsultation()
        {
            var consultationTime = new Random().Next(0, 100) > 94 ? 1250 : new Random().Next(249, 501);
            Thread.Sleep(consultationTime);
            FinishConsultation();
        }
    }
}