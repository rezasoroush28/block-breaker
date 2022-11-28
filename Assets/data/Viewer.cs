using System;
using Present;
using UnityEngine;
using UnityEngine.Serialization;

namespace data
{
    public class Viewer : MonoBehaviour 
    {
        public Transform parent;
        public Vector2 ballPose;
        public LevelModel level;
        [FormerlySerializedAs("ballData")] public BallModel normalBallData;
        public BallModel fireBallData;
        public BallModel freezBallData;
        public HoverModel hoverData;
        private BallHandler _ball;
        private HoverHandler _hover;
        private BlocksHandler _block;

        public void GenerateWholeLevel()
        {
            _ball = new BallHandler(normalBallData , fireBallData , freezBallData , this);
            _hover = new HoverHandler(hoverData,this);
            _block = new BlocksHandler(level, _ball, _hover, this);
            _block.PositionTheBlocks();
            

            
        }
        private void Awake()
        {
            
            GenerateWholeLevel();
            _ball.GenerateTheNormalBall();
        }

        public GameObject SpawnTheBlock(GameObject blockGameObject , Vector2 pose)
        {
            var position = new Vector3(pose.x, pose.y, 0f);
            var go = Instantiate(blockGameObject, position,blockGameObject.transform.rotation,parent);
            return go;
        }

        public  void SpawnTheBall(GameObject ballGameObject , Vector2 velocity)
        {
            var pose = ballGameObject.transform.position;
            var go = Instantiate(ballGameObject, ballPose,ballGameObject.transform.rotation,parent);
            go.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        public void SpawnTheHover(GameObject hoverGameObject)
        {
            var pose = ballPose - new Vector2(0f, -50f);
            var go = Instantiate(hoverGameObject, pose,hoverGameObject.transform.rotation,parent);
        }
        

        
    }
}