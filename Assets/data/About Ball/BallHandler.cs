using data.blockModels;
using data.level_handler;
using data.prefabs.blockModels;
using Interfaces;
using UnityEngine;

namespace data.About_Ball
{
    public class BallHandler : IObsserver
    {
        
        private Viewer _viewer;
        private BallData _normalBallData;
        private BallData _freezBallData;
        private BallData _fireBallData;
        private BallData _activeBallData;
        public BallHandler(LevelModel levelModel, Viewer viewer)
        {
            var levelModel1 = levelModel;
            _normalBallData = levelModel1.normalBall;
            _fireBallData = levelModel1.fireBall ;
            _freezBallData = levelModel1.freezBall;
            _viewer = viewer;
        }


        public void FinishTheGame()
        {
            _viewer.EndIt();
        }
        public void GenerateTheNormalBallForFirstTime()
        {
            _activeBallData =_viewer.SpawnTheBall(_normalBallData, GenerateAVelocity()*_normalBallData.velocity);
            _activeBallData.thisBallHandler = this;
        }
        public void GenerateTheNormalBall()
        {
            _activeBallData =_viewer.SpawnTheNewBall(_normalBallData);
            _activeBallData.thisBallHandler = this;
        }

        public void GenerateFireBall()
        {
            _activeBallData = _viewer.SpawnTheNewBall(_fireBallData);
            _activeBallData.thisBallHandler = this;
        }
        
        public void GenerateFreezeBall()
        {
            _activeBallData =_viewer.SpawnTheNewBall(_freezBallData);
            _activeBallData.thisBallHandler = this;
        }

        public Vector2 GenerateAVelocity()
        {
            var deg =Random.Range(45, 125);
            var u = new Vector2(Mathf.Cos(deg), Mathf.Sin(deg));
            return u;
        }


        public void RecognizeTheCall(BlockPresenter caller)
        {
            var cat = caller.thisBlockCategories;
            switch (cat)
            {
                case LevelModel.BlockCategories.Fire:
                {
                    GenerateFireBall();
                    break;
                }
                case LevelModel.BlockCategories.Freez:
                {
                    GenerateFreezeBall();
                    break;
                }
            }
        }

        public void UpdateIt(BlockPresenter whoIsCalling)
        {
            RecognizeTheCall(whoIsCalling);
        }
    }
}