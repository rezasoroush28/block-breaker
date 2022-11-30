using System;
using System.Collections.Generic;
using data;
using data.prefabs.blockModels;
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
        public List<BlockPresenter> AllBlockPresenters;
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
            var stepX = -(boundries[0].x - boundries[1].x)/_level.rows[1].bricks.Length;
            var stepY = -(boundries[0].y - boundries[1].y) / _level.rows.Length;
            var rows = _level.rows;
            AllBlockPresenters = new List<BlockPresenter>();
            //var cul = level.rows[0];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].bricks.Length; j++)
                {
                    if (_level.rows[i].bricks[j] != LevelModel.BlockCategories.None)
                    {
                        var blockData = _level.rows[i].bricks[j];
                        var blockPresenter = new BlockPresenter(DefineTheBlock(blockData).brickGameObject, DefineTheBlock(blockData).brickPoint);
                        blockPresenter.HandleTheAttacher(DefineTheBlock(blockData));
                        
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
            foreach (var block in AllBlockPresenters)
            {
                if (block.blockIndexName == blockName)
                {
                    Object.Destroy(block.blockGameObject);
                }
            }
        }

        public BrickModel DefineTheBlock(LevelModel.BlockCategories blockCategory )
        {
            switch (blockCategory)
            {
                case LevelModel.BlockCategories.Normal:
                {
                    return _level.normalBlock;
                    break;
                }
                case LevelModel.BlockCategories.Fire:
                {
                    return _level.fireBlock;
                    break;
                }
                case LevelModel.BlockCategories.Freez:
                {
                    return _level.freezBlock;
                    break;
                }
            }
        }
        
        

        
        
    }
    
    
}