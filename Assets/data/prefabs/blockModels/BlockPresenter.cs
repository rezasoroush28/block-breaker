using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace data.prefabs.blockModels
{
    public class BlockPresenter :  ISubject
    {
        //private BrickModel _data;
        private GameObject _block;
        public int point;
        public PresenterAttacher attacher;
        public List<IObsserver> obsservers;
        public string blockIndexName;
        public Vector2 position;
        public BlockPresenter(BlocksHandler handler , int i , int j)
        {
            
            obsservers = new List<IObsserver>();
            handler.AddObsserverToEachBlock(this);
            this.blockIndexName = i.ToString() + " " + j.ToString();
            //blockData.presenterForThisBlock = this;
            handler.allBlockPresenters.Add(this);
            
            
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

        public void HandleTheAttacher(BrickModel data)
        {
            data.attacher.thisPresenter = this;
            var presenter = data.attacher.thisPresenter;
        }
    }
}