using System.Collections;
using System.Collections.Generic;
using data.prefabs.blockModels;
using Interfaces;
using UnityEngine;

namespace data
{
    public class BallHandler : IObsserver
    {
        private Viewer _viewer;
        private BallModel _normalBallData;
        private BallModel _freezBallData;
        private BallModel _fireBallData;
        public BallHandler(BallModel normalBallData, BallModel fireBallData, BallModel freezBallData , Viewer viewer)
        {
            _normalBallData = normalBallData;
            _fireBallData = fireBallData;
            _freezBallData = freezBallData;
            _viewer = viewer;
        }

        public void GenerateTheNormalBall()
        {
            _viewer.SpawnTheBall(_normalBallData.ballSample , GenerateAVelocity()*_normalBallData.velocity);
        }

        public void GenerateFireBall()
        {
            _viewer.SpawnTheBall(_fireBallData.ballSample , GenerateAVelocity()*_fireBallData.velocity);
        }
        
        public void GenerateFreezeBall()
        {
            _viewer.SpawnTheBall(_freezBallData.ballSample , GenerateAVelocity()*_fireBallData.velocity);
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