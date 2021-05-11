using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Alarmcentral.Library;

namespace Alarmcentral.Console
{
    using System;

    class Program
    {
        public static CallCenter callCenter = new CallCenter();
        /// <summary>
        /// In here is where the Emergency call center simulation will run.
        /// Time scaling will be 1 to 10, meaning that 6 sec will correspond to 1 min.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            for (int i = 0; i < 10; i++)
            {
                callCenter.AddCall();
            }
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var nurses = new List<INurse>();
            var doctors = new List<IDoctor>();

            for (int i = 0; i < 6; i++)
            {
                nurses.Add(new Nurse());
            }

            for (int i = 0; i < 2; i++)
            {
                doctors.Add(new Doctor());
            }
            
            var callerThread = new Thread(PatientCallsTask);
            callerThread.Start();

            foreach (var nurse in nurses)
            {
                
            }

            do
            {
                // Thread.Sleep(1000);
                // Console.WriteLine($"Nurse Queue {callCenter.NurseQueue.Count}");
                // Console.WriteLine($"Urgent Queue {callCenter.UrgentQueue.Count}");
              
            } while (stopWatch.Elapsed < TimeSpan.FromMinutes(5));

        }

        /// <summary>
        /// This method is used to add Patient Calls to the queues in Callcenter.
        /// Adds a Call every 500ms
        /// When called the thread will be stuck in an infinite loop.
        /// </summary>
        /// <param name="callback"></param>
        static void PatientCallsTask(object callback)
        {
            do
            {
                callCenter.AddCall();
                Console.WriteLine("I added a patient");
                Thread.Sleep(500);
            } while (true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        static void NursingProcess(object callback)
        {
            Nurse nurse = new Nurse();
            do
            {
                Call call;
                if (callCenter.CheckUrgentQueue())
                {
                    call = callCenter.UrgentQueue.Dequeue();
                    var patient = nurse.CheckIfPatientIsCritical(call);
                    
                } else if (callCenter.NurseQueue.Count > 0)
                {
                    call = callCenter.NurseQueue.Dequeue();
                    call = nurse.CheckIfPatientIsCritical(call);
                }
                

            } while (true);
        }
    }
}
