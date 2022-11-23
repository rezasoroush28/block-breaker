using System;
using System.Collections.Generic;
using data;
using Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public void FindTheCollider(GameObject collidedBlock)
        {
            
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
                        block.brickIndexName = i.ToString() + " " + j.ToString();
                        block.brickGameObject.name = block.brickIndexName; 
                        block.AttachGameObjectsToModels();
                        block.position.x = boundries[1].x + (stepX * j);
                        block.position.y = boundries[1].y + (stepY * i);
                        blocks.Add(block);
                       _level.rows[i].bricks[j] = block;
                        
                        countedBlocks++; }
                    else
                    {
                         continue;
                    }
                }
            }
            //positions Handlled;
            //name handled;
        }

        public void UpdateIt(BrickModel notifyingBlock)
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

        
    }
    
    
}