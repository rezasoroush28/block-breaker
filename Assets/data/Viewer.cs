using System;
using Present;
using UnityEngine;

namespace data
{
    public class Viewer : MonoBehaviour
    {
        public Transform parent;
        public LevelModel level;
        public BallModel ballData;
        public HoverModel hoverData;
        private BallHandler _ball;
        private HoverHandler _hover;
        private BlocksPresenter _block;

        public void GenerateWholeLevel()
        {
            _ball = new BallHandler(ballData);
            _hover = new HoverHandler(hoverData);
            _block = new BlocksPresenter(level, _ball, _hover, this);
            _block.PositionTheBlocks();

            foreach (var block in _block.blocks)
            {
                Vector3 pose = new Vector3(block.position.x, block.position.y, 0f);
                Instantiate(block.brickGameObject, pose,block.brickGameObject.transform.rotation,parent);
            }
        }
        private void Awake()
        {
            GenerateWholeLevel();
        }
        

        
    }
}