using System.Collections.Generic;
using data;
using Interfaces;
using UnityEngine;

namespace Present
{
    
    public class BlocksPresenter : IObsserver
    {
        private LevelModel _level;
        private BallHandler _ball;
        private HoverHandler _hover;
        private Viewer _viewer;
        public Vector2[] boundries;
        public List<BrickModel> blocks;
        public int countedBlocks = 0;
        public int gainedPoints;
        public BlocksPresenter(LevelModel level, BallHandler ball, HoverHandler hover, Viewer viewer)
        {
            this._level = level;
            this._ball = ball;
            _hover = hover;
            this._viewer = viewer;
        }
        //public List<Dictionary<GameObject, Vector2>> bricksList;


        public void AddObsserverToEachBlock(BrickModel block)
        {
            block.Add(_ball);
            block.Add(_hover);
            block.Add(this);
        }

        public void PositionTheBlocks()
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
                        var block = ScriptableObject.CreateInstance<BrickModel>();
                        AddObsserverToEachBlock(block);
                        block.brickPoint = _level.rows[i].bricks[j].brickPoint;
                        block.brickGameObject = _level.rows[i].bricks[j].brickGameObject;
                        block.position.x = boundries[1].x + (stepX * j);
                        block.position.y = boundries[1].y + (stepY * i);
                        block.brickIndexName = i.ToString() + " " + j.ToString();
                        _level.rows[i].bricks[j] = block;
                        blocks.Add(block);
                        countedBlocks++;
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
            countedBlocks--;
            gainedPoints++;
        }
    }
    
    
}