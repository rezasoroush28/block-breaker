using System;
using System.Collections.Generic;
using data.About_Ball;
using data.About_Hover;
using data.level_handler;
using Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace data.blockModels
{
    
    public class BlocksHandler : IObsserver
    {
        private LevelModel _level;
        private BallHandler _ball;
        private HoverHandler _hover;
        private Viewer _viewer;
        public Vector2[] boundries;
        public List<BlockPresenter> allBlockPresenters;
        public int countedBlocks = 0;
        public int gainedPoints;
        private GameObject _boundery;
        public BlocksHandler(LevelModel level, BallHandler ball, HoverHandler hover, Viewer viewer, GameObject canves)
        {
            _boundery = canves;
            this._level = level;
            this._ball = ball;
            _hover = hover;
            this._viewer = viewer;
        }
        //public List<Dictionary<GameObject, Vector2>> bricksList;


        public void AddObsserverToEachBlock(BlockPresenter blockPresenter)
        {
            blockPresenter.AddIt(_ball);
            blockPresenter.AddIt(_hover);
            blockPresenter.AddIt(this);
        }

        public void SetFinishLine()
        {
            _viewer.HandleTheFifnishLine(_level.bound);
        }

        public void FindTheBlock(String collidedBlockName, List<BlockPresenter> remainedBlocks)
        {
            foreach (var inCheckBlock in remainedBlocks)
            {
               // if (inCheckBlock.blockGameObject.name == collidedBlockName)
                {
                    inCheckBlock.Notify();
                    remainedBlocks.Remove(inCheckBlock);
                }
            }
        }
        public void HandelThePresenters()
        {
            var pose = _boundery.transform;
            var rt = (RectTransform)pose;
            var rect = rt.rect;
            var height = rect.height ;
            var width = rect.width;
            var position1 = pose.position;
            var position = new Vector2(position1.x, position1.y)+ Vector2.up * height / 2 + Vector2.left* width/2;
            var startPoint = position;
            
            //starting point handled
            
            
            var stepX = width/_level.rows[1].bricks.Length;
            var stepY =  height/ _level.rows.Length;
            var rows = _level.rows;
            allBlockPresenters = new List<BlockPresenter>();
            //var cul = level.rows[0];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].bricks.Length; j++)
                {
                    if (_level.rows[i].bricks[j] != LevelModel.BlockCategories.None)
                    {
                        var blockData = DefineTheBlock(_level.rows[i].bricks[j]);
                        var blockPresenter = new BlockPresenter(this , i , j , blockData.blockCat);
                        blockPresenter.position = startPoint + Vector2.right * j * stepX + Vector2.down * i * stepY;
                        blockData.presenterForThisBlock = blockPresenter;
                        var block = _viewer.SpawnTheBlock(blockData , blockPresenter);
                        allBlockPresenters.Add(blockPresenter);
                        Debug.Log(_viewer.GiveMeTheName(block));



                        //every time the attacher in the model changes and atc...
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
            Object.Destroy(GameObject.Find(blockName));
        }

        public BlockData DefineTheBlock(LevelModel.BlockCategories blockCategory)
        {
            
            BlockData blockData = null;
            switch (blockCategory)
            {
                    
                case LevelModel.BlockCategories.Normal:
                {
                    blockData = _level.normalBlock;
                    break;
                }
                case LevelModel.BlockCategories.Fire:
                {
                    blockData = _level.fireBlock;
                    break;
                }
                case LevelModel.BlockCategories.Freez:
                {
                    blockData = _level.freezBlock;
                    break;
                }

                    
                    
            }
            //var block =_viewer.SpawnTheBlock(blockData);
            return blockData;
        }

       
        
        

        
        
    }
    
    
}