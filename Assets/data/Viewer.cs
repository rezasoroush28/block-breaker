using System;
using data.prefabs.blockModels;
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
            _block.HandelThePresenters();
            

            
        }
        private void Awake()
        {
            
            GenerateWholeLevel();
            _ball.GenerateTheNormalBall();
        }

        public GameObject SpawnTheBlock(BlockData blockData ,BlockPresenter blockPresenter)
        {
            var goData = Instantiate(blockData, parent);
            goData.presenterForThisBlock = blockPresenter;
            var go = goData.gameObject;
            go.name = blockPresenter.blockIndexName;
            go.transform.position = blockPresenter.position;
            //goData.GetComponent<BlockData>().presenterForThisBlock = blockPresenter;
            return go;
        }

        public string GiveMeTheName(GameObject block)
        {
            var indexName =block.GetComponent<BlockData>().presenterForThisBlock.blockIndexName;
            return indexName;
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