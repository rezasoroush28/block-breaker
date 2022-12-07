using System;
using data.About_Ball;
using data.About_Hover;
using data.level_handler;
using data.prefabs.blockModels;
using UnityEngine;
using UnityEngine.Serialization;

namespace data
{
    public class Viewer : MonoBehaviour
    {

        private GameObject _theHover;
        private Vector2 _hovrPose;
        private HoverData _hoverData;
        
        public Transform parent;
        public Vector2 ballPose;
        public LevelModel level;
        
        
        //public HoverModel hoverData;
        private BallHandler _ball;
        private HoverHandler _hover;
        private BlocksHandler _block;
        

        private void Start()
        {
           // _hoverData = theHover.GetComponent<HoverData>();
           // _hoverData.thisGameObject = theHover;
        }

        public void GenerateWholeLevel()
        {
            _ball = new BallHandler(level, this);
            _hover = new HoverHandler(level,this);
            _block = new BlocksHandler(level, _ball, _hover, this);
            _block.HandelThePresenters();
            _ball.GenerateTheNormalBall();
             _hover.GenerateTheHover();

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
            var goData = Instantiate(ballData,parent);
            var go = goData.gameObject;
            go.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        public GameObject SpawnTheHover(HoverData hoverData)
        {
            //var pose = hoverData.thisGameObject.transform.position;
            _hoverData = Instantiate(hoverData, parent);
            _hovrPose = hoverData.Pose;
            _theHover = _hoverData.gameObject;
            return _theHover;

        }


        public float HandleTheInput()
        {
            var deltaX =Input.GetAxis("Mouse X");
            return deltaX;
        }

        private void Update()
        {
            var pose = _theHover.transform.position;
            pose.x += _hover.HandleTheInput();
            _theHover.transform.position = pose;
        }
    }
}