namespace Alarmcentral.Library
{
    public interface INurse : IWorker
    {
        /// <summary>
        /// Method to check if the patient is critical.
        /// If so, the patient has to be moved to the doctors queue.
        /// </summary>
        /// <returns></returns>
        Call MoveCriticalPatientToDoctorQueue();

        Call CheckIfPatientIsCritical(Call call);

        void NurseConsultation();
    }
}