namespace Interfaces
{
    public interface ISubject
    {
        public void Add(IObsserver obsserver);
        public void Remove(IObsserver obsserver);
        public void Notify();
    }
}