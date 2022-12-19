using System;
using data.About_Ball;
using data.About_Hover;
using data.blockModels;
using data.level_handler;
using data.prefabs.blockModels;
using UnityEngine;
using UnityEngine.Serialization;

namespace data
{
    public class Viewer : MonoBehaviour
    {

        
        private GameObject _theHover;
        private HoverData _theHoverData;

        private BallData _theBallData;
        
        public Transform parent;
        public Vector2 ballPose;
        public LevelModel level;
        
        
        //public HoverModel hoverData;
        private BallHandler _ballHandler;
        private HoverHandler _hoverHandler;
        private BlocksHandler _blockhHandler;
        

        private void Start()
        {
           // _hoverData = theHover.GetComponent<HoverData>();
           // _hoverData.thisGameObject = theHover;
        }

        public void GenerateWholeLevel()
        {
            _ballHandler = new BallHandler(level, this);
            _hoverHandler = new HoverHandler(level,this);
            _blockhHandler = new BlocksHandler(level, _ballHandler, _hoverHandler, this);
            _blockhHandler.HandelThePresenters();
            _ballHandler.GenerateTheNormalBallForFirstTime();
             _hoverHandler.GenerateTheHover();

        }
        private void Awake()
        {
            
            GenerateWholeLevel();
            
            
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

        public  void SpawnTheBall(BallData ballData , Vector2 velocity)
        {
            var pose = ballData.thisGameObject.transform.position;
            _theBallData = Instantiate(ballData,parent);
            var go = _theBallData.gameObject;
            _theBallData.thisGameObject = go;
            go.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        public void SpawnTheNewBall(BallData newBallData)
        {
            var pose = _theBallData.Pose;
            var dir = _theBallData.Direction;
            Destroy(_theBallData.thisGameObject);
            SpawnTheBall(newBallData , dir * newBallData.velocity);
        }

        public GameObject SpawnTheHover(HoverData hoverData)
        {
            //var pose = hoverData.thisGameObject.transform.position;
            _theHoverData = Instantiate(hoverData, parent);
           // _hovrPose = hoverData.Pose;
           _theHoverData.thisGameObject = _theHoverData.gameObject;
           _theHover = _theHoverData.thisGameObject;
            return _theHover;
        }


        public float HandleTheInput()
        {
            var deltaX =Input.GetAxis("Mouse X");
            return deltaX;
        }

        private void Update()
        {
            
            var pose = _theHoverData.thisGameObject.transform.position;
            pose.x += _hoverHandler.HandleTheInput();
            _theHoverData.thisGameObject.transform.position = pose;
        }
        
        
       
    }
}