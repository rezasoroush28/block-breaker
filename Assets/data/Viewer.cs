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
        private BlocksHandler _block;

        public void GenerateWholeLevel()
        {
            _ball = new BallHandler(ballData);
            _hover = new HoverHandler(hoverData);
            _block = new BlocksHandler(level, _ball, _hover, this);
            _block.PositionTheBlocks();

            
        }
        private void Awake()
        {
            GenerateWholeLevel();
        }

        public void SpawnTheBlock(GameObject blockGameObject , Vector2 pose)
        {
            var position = new Vector3(pose.x, pose.y, 0f);
            Instantiate(blockGameObject, position,blockGameObject.transform.rotation,parent);
        }
        

        
    }
}