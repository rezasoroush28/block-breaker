using System.Collections.Generic;
using data;
using Interfaces;
using UnityEngine;

namespace Present
{
    
    public class BlocksPresenter : IObsserver
    {
        private LevelModel _level;
        private BallModel _ball;
        private HoverModel _hover;
        public Vector2[] boundries;

        public BlocksPresenter(LevelModel level, BallModel ball, HoverModel hover)
        {
            this._level = level;
            this._ball = ball;
            _hover = hover;
        }
        //public List<Dictionary<GameObject, Vector2>> bricksList;
        
        
        

        public void ReturnTheBricks()
        {
            boundries = new[] { _level.boundries[1], _level.boundries[2] };
            var stepX = -(boundries[0].x - boundries[1].x);
            var stepY = -(boundries[0].y - boundries[1].y);
            var rows = _level.rows;
            //var cul = level.rows[0];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].bricks.Length; j++)
                {
                    if (_level.rows[i].bricks[j].brickGameObject != null)
                    {
                        _level.rows[i].bricks[j].position.x = boundries[1].x + (stepX * j);
                        _level.rows[i].bricks[j].position.y = boundries[1].y + (stepY * i);
                        _level.rows[i].bricks[j].brickIndexName = i.ToString() + " " + j.ToString();
                    }
                    else
                    {
                         continue;
                    }
                }
            }
            //positions Handlled;
            //name handled;
        }

        public void UpdateIt()
        {
            
        }
    }
    
    
}