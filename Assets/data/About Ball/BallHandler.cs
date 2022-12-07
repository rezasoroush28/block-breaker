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
        public BallHandler(LevelModel levelModel, Viewer viewer)
        {
            var levelModel1 = levelModel;
            _normalBallData = levelModel1.normalBall;
            _fireBallData = levelModel1.fireBall ;
            _freezBallData = levelModel1.freezBall;
            _viewer = viewer;
        }

        public void GenerateTheNormalBall()
        {
            _viewer.SpawnTheBall(_normalBallData, GenerateAVelocity()*_normalBallData.velocity);
        }

        public void GenerateFireBall()
        {
            _viewer.SpawnTheBall(_fireBallData, GenerateAVelocity()*_fireBallData.velocity);
        }
        
        public void GenerateFreezeBall()
        {
            _viewer.SpawnTheBall(_freezBallData, GenerateAVelocity()*_fireBallData.velocity);
        }

        public Vector2 GenerateAVelocity()
        {
            var deg =Random.Range(45, 125);
            var u = new Vector2(Mathf.Cos(deg), Mathf.Sin(deg));
            return u;
        }

        public void UpdateIt(BlockPresenter whoIsCalling)
        {
            
        }
    }
}