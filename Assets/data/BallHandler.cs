using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace data
{
    public class BallHandler : IObsserver
    {
        private BallModel _ball;

        public BallHandler(BallModel ball)
        {
            _ball = ball;
        }

        public void UpdateIt()
        {
        
        }
    };

    class Program
    {
    
    
    }
}