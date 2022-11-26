using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace data
{
    public class BlockPresenter : ISubject
    {
        private GameObject _brickGameObject;
        public BrickModelAttacher attacher;
        public List<IObsserver> obsservers;
        public string brickIndexName;
        public Vector2 position;
        public BlockPresenter(GameObject brickGameObject, BrickModelAttacher attacher)
        {
            _brickGameObject = brickGameObject;
            
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
        
        public void AttachGameObjectsToPresenter()
        {
            attacher.thisModel = this;
        }
    }
}