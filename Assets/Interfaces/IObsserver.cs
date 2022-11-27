using data;

namespace Interfaces
{
    public interface IObsserver
    {
        public void UpdateIt(BlockPresenter whoIsCalling);
    }
}