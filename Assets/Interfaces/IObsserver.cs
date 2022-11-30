using data;
using data.prefabs.blockModels;

namespace Interfaces
{
    public interface IObsserver
    {
        public void UpdateIt(BlockPresenter whoIsCalling);
    }
}