namespace Interfaces
{
    public interface IObsserver
    {
        public void UpdateIt(ISubject whoIsCalling);
    }
}