using data.blockModels;
using data.level_handler;
using Interfaces;
using UnityEngine;

namespace data.About_Hover
{
    public class HoverHandler : IObsserver
    {
        private LevelModel _level;
        private HoverData _hoverData;
        private Viewer _viewer;

        public HoverHandler(LevelModel level, Viewer viewer)
        {
            _level = level;
            _viewer = viewer;
            _hoverData = level.hoverData;
        }

        public GameObject GenerateTheHover()
        {
            var go =_viewer.SpawnTheHover(_hoverData);
            return go;
        }

        public float HandleTheInput()
        {
            var deltaX =_viewer.HandleTheInput();
            float moving = _hoverData.movivngVelocity * deltaX;
            return moving;
        }

        public void UpdateIt(BlockPresenter whoIsCalling)
        {
            
        }
    }
}