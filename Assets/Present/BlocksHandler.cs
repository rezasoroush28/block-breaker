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
        public List<BlockPresenter> blocks;
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


        public void AddObsserverToEachBlock(BlockPresenter block)
        {
            block.AddIt(_ball);
            block.AddIt(_hover);
            block.AddIt(this);
        }

        

        public void FindTheBlock(String collidedBlockName, List<BlockPresenter> remainedBlocks)
        {
            foreach (var inCheckBlock in remainedBlocks)
            {
                if (inCheckBlock.blockGameObject.name == collidedBlockName)
                {
                    inCheckBlock.Notify();
                    remainedBlocks.Remove(inCheckBlock);
                    
                }
            }
        }
        public void PositionTheBlocks()
        {
            
            boundries = new[] { _level.boundries[0], _level.boundries[1] };
            var stepX = -(boundries[0].x - boundries[1].x)/_level.rows.Length;
            var stepY = -(boundries[0].y - boundries[1].y) / _level.rows[1].bricks.Length;
            var rows = _level.rows;
            blocks = new List<BlockPresenter>();
            //var cul = level.rows[0];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].bricks.Length; j++)
                {
                    if (_level.rows[i].bricks[j] != null)
                    {
                        var blockData = _level.rows[i].bricks[j];
                        var blockPresenter = new BlockPresenter(new GameObject(),new int());
                        blockPresenter.obsservers = new List<IObsserver>();
                        AddObsserverToEachBlock(blockPresenter);
                        var tempModelName = blockData.brickGameObject.name;
                        //to have refrence to the model gameobject name;
                        
                        blockPresenter.blockPoint = blockData.brickPoint;
                        blockPresenter.blockGameObject = blockData.brickGameObject;
                        blockPresenter.attacher = blockData.attacher;
                        blockPresenter.blockGameObject.name= i.ToString() + " " + j.ToString();
                        blockPresenter.AttachGameObjectsToPresenter();
                        blockPresenter.position = new Vector2();
                        blockPresenter.position.x = boundries[0].x  + (stepX * j);
                        blockPresenter.position.y = boundries[0].y + (stepY * i);
                        _viewer.SpawnTheBlock(blockPresenter.blockGameObject , blockPresenter.position);
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
            DestroyTheBlock(notifyingBlock.blockIndexName);
        }

        public void DestroyTheBlock(string blockName)
        {
            foreach (var block in blocks)
            {
                if (block.blockIndexName == blockName)
                {
                    Object.Destroy(block.blockGameObject);
                }
            }
        }
        
    }
    
    
}