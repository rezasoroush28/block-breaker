namespace Interfaces
{
    public interface ISubject
    {
        public void AddIt(IObsserver obsserver);
        public void Remove(IObsserver obsserver);
        public void Notify();
    }
}