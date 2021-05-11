using System.Threading;

namespace Alarmcentral.Library
{
    public abstract class Worker : IWorker
    {
        private bool isWorking = false;

        public Call Call; // The patient that the worker is currently consulting.
        
        /// <summary>
        /// Method used to call patient.
        /// Simulates the delay there would be when calling the patient.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public void CallPatient(string number)
        {
            Thread.Sleep(100);
        }

        /// <summary>
        /// Method used used to initiate the call between the
        /// healthcare worker, and the patient.
        /// </summary>
        /// <param name="call"></param>
        public void TakeCall(Call call)
        {
            isWorking = true;
            if (call.CallerIsOnTheLine)
            {
                Call = call;
            }
            else
            {
                CallPatient(call.CallerNumber);
                Call = call;
            }
        }

        public void CheckQueues()
        {
            
        }

        /// <summary>
        /// Used to check if worker is working.
        /// </summary>
        /// <returns>boolean indication if worker is working</returns>
        public bool IsWorking()
        {
            return this.isWorking;
        }

        /// <summary>
        /// Method used to finish the workers consultation.
        /// Sets the workers patient to null, and isWorking to false.
        /// </summary>
        public void FinishConsultation()
        {
            isWorking = false;
            Call = null;
        }
    }
}