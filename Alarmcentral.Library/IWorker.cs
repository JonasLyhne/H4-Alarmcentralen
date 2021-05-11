namespace Alarmcentral.Library
{
    public interface IWorker
    {
        // void ConsultPatient(Patient patient);

        void CallPatient(string number); // TODO: ReThink This

        void TakeCall(Call call);

        void CheckQueues(); // TODO: This may suck?

        bool IsWorking();

        void FinishConsultation();
    }
}