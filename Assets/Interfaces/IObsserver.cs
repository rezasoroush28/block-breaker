using data;

namespace Interfaces
{
    public interface IObsserver
    {
        public void UpdateIt(BrickModel whoIsCalling);
    }
}