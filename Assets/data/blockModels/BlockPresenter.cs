using System.Collections.Generic;
using data.level_handler;
using data.prefabs.blockModels;
using Interfaces;
using UnityEngine;

namespace data.blockModels
{
    public class BlockPresenter :  ISubject
    {
        //private BrickModel _data;
        private GameObject _block;
        public int point;
        public LevelModel.BlockCategories thisBlockCategories;
        //public PresenterAttacher attacher;
        public List<IObsserver> obsservers;
        public string blockIndexName;
        public Vector2 position;
        public BlockPresenter(BlocksHandler handler , int i , int j, LevelModel.BlockCategories thisBlockCategories)
        {
            
            obsservers = new List<IObsserver>();
            handler.AddObsserverToEachBlock(this);
            this.blockIndexName = i.ToString() + " " + j.ToString();
            //blockData.presenterForThisBlock = this;
            handler.allBlockPresenters.Add(this);
            this.thisBlockCategories = thisBlockCategories;
            
            
            //HandleTheAttacher(data);
        }

        public void AddIt(IObsserver obsserver)
        {
            obsservers.Add(obsserver);
        }

        public void Remove(IObsserver obsserver)
        {
            obsservers.Remove(obsserver);
        }

        public void Notify()
        {
            foreach (var obs in obsservers )
            {
                obs.UpdateIt(this);  
            }
        }
    }
}