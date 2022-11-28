using Interfaces;

namespace data
{
    public class HoverHandler : IObsserver
    {
        private HoverModel _hoverData;
        private Viewer _viewer;

        public HoverHandler(HoverModel hoverData, Viewer viewer)
        {
            this._hoverData = hoverData;
            _viewer = viewer;
        }

        public void GenerateTheHover()
        {
            _viewer.SpawnTheHover(_hoverData.hoverSample);
        }

        public void UpdateIt(BlockPresenter whoIsCalling)
        {
            
        }
    }
}