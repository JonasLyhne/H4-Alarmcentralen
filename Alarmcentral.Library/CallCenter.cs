using System;
using System.Collections.Generic;
using System.Threading;

namespace Alarmcentral.Library
{
    public class CallCenter
    {
        public Queue<Call> NurseQueue {get; set; } = new Queue<Call>();
        public Queue<Call> UrgentQueue {get; set; } = new Queue<Call>();
        public Queue<Call> DoctorQueue {get; set; } = new Queue<Call>();
        private PatientFactory patientFactory = new PatientFactory();
        public int NumberOfDeadPatients { get; }
        
        // public List<Call> NurseQueue { get; set; } = new List<Call>();
        // public List<Call> UrgentQueue { get; set; } = new List<Call>();
        // public List<Call> DoctorQueue { get; set; } = new List<Call>();

        public void AddCall()
        {
            var call = new Call(patientFactory.CreatePatient());

            if (IsCallUrgent())
            {
                UrgentQueue.Enqueue(call);
            } else NurseQueue.Enqueue(call);
            
        }

        /// <summary>
        /// Used to check if there are any calls in the urgent queue.
        /// </summary>
        /// <returns></returns>
        public bool CheckUrgentQueue()
        {
            return UrgentQueue.Count > 0;
        }

        /// <summary>
        /// Used to move a call do the doctor queue
        /// </summary>
        /// <param name="call"></param>
        public void MoveCallToDoctorQueue(Call call)
        {
            DoctorQueue.Enqueue(call);
        }

        /// <summary>
        /// Simulates a 112 urgent call.
        /// </summary>
        /// <returns></returns>
        private bool IsCallUrgent()
        {
            return new Random().Next(0, 100) > 80;
        }
        
    }
}