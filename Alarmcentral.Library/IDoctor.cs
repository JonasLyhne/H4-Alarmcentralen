namespace Alarmcentral.Library
{
    public interface IDoctor : IWorker
    {
        void DoctorConsultation(Call call);
    }
}