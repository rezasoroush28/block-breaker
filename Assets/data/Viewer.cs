using System;
using UnityEngine;

namespace data
{
    public class Viewer : MonoBehaviour
    {
        public LevelModel level;
        public BallModel ballData;
        public HoverModel hover;
        private BallHandler _ball;
        private void Awake()
        {
            _ball = new BallHandler(ballData);
        }
    }
}