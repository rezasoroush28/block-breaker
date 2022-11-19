using System;
using Present;
using UnityEngine;

namespace data
{
    public class Viewer : MonoBehaviour
    {
        public LevelModel level;
        public BallModel ballData;
        public HoverModel hoverData;
        private BallHandler _ball;
        private HoverHandler _hover;
        private BlocksPresenter _block;
        

        private void Awake()
        {
            _ball = new BallHandler(ballData);
            _hover = new HoverHandler(hoverData);
            _block = new BlocksPresenter(level, _ball, _hover, this);
        }
    }
}