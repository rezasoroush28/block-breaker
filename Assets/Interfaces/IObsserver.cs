using data;
using data.blockModels;

namespace Interfaces
{
    public interface IObsserver
    {
        public void UpdateIt(BlockPresenter whoIsCalling);
    }
}