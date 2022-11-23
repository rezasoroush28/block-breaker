using Interfaces;

namespace data
{
    public class HoverHandler : IObsserver
    {
        private HoverModel _hoverData;

        public HoverHandler(HoverModel hoverData)
        {
            this._hoverData = hoverData;
        }

        public void UpdateIt(BrickModel notifyingBlock)
        {
        
        }
    }
}