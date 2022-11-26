using System;
using System.Collections.Generic;
using data;
using Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Present
{
    
    public class BlocksHandler : IObsserver
    {
        private LevelModel _level;
        private BallHandler _ball;
        private HoverHandler _hover;
        private Viewer _viewer;
        public Vector2[] boundries;
        public List<BrickModel> blocks;
        public int countedBlocks = 0;
        public int gainedPoints;
        public BlocksHandler(LevelModel level, BallHandler ball, HoverHandler hover, Viewer viewer)
        {
            this._level = level;
            this._ball = ball;
            _hover = hover;
            this._viewer = viewer;
        }
        //public List<Dictionary<GameObject, Vector2>> bricksList;


        public void AddObsserverToEachBlock(BrickModel block)
        {
            block.AddIt(_ball);
            block.AddIt(_hover);
            block.AddIt(this);
        }

        

        public void FindTheBlock(String collidedBlockName, List<BrickModel> remainedBlocks)
        {
            foreach (var inCheckBlock in remainedBlocks)
            {
                if (inCheckBlock.brickIndexName == collidedBlockName)
                {
                    inCheckBlock.Notify();
                    remainedBlocks.Remove(inCheckBlock);
                    
                }
            }
        }
        public void PositionTheBlocks()
        {
            boundries = new[] { _level.boundries[0], _level.boundries[0] };
            var stepX = -(boundries[0].x - boundries[1].x);
            var stepY = -(boundries[0].y - boundries[1].y);
            var rows = _level.rows;
            blocks = new List<BrickModel>();
            //var cul = level.rows[0];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].bricks.Length; j++)
                {
                    if (_level.rows[i].bricks[j] != null)
                    {
                        var block = ScriptableObject.CreateInstance<BrickModel>();
                        //AddObsserverToEachBlock(block);
                        //just sticking to making the blocks
                        block.brickPoint = _level.rows[i].bricks[j].brickPoint;
                        block.brickGameObject = new GameObject();
                        block.brickGameObject = _level.rows[i].bricks[j].brickGameObject;
                        block.brickIndexName = i.ToString() + " " + j.ToString();
                        block.brickGameObject.name = block.brickIndexName;
                        block.attacher = _level.rows[i].bricks[j].attacher;
                        block.AttachGameObjectsToModels();
                        block.position.x = boundries[0].x + (stepX * j);
                        block.position.y = boundries[0].y + (stepY * i);
                        //_level.rows[i].bricks[j] = block;
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

        public void UpdateIt(BlockPresenter notifyingBlock)
        {
            countedBlocks--;
            gainedPoints++;
            DestroyTheBlock(notifyingBlock.brickIndexName);
        }

        public void DestroyTheBlock(string blockName)
        {
            foreach (var block in blocks)
            {
                if (block.brickIndexName == blockName)
                {
                    Object.Destroy(block.brickGameObject);
                }
            }
        }


        public void UpdateIt()
        {
            
        }
    }
    
    
}