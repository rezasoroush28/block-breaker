using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace data
{
    public class BlockPresenter : ISubject
    {
        public GameObject blockGameObject;
        private int _point;
        public PresenterAttacher attacher;
        public List<IObsserver> obsservers;
        public string blockIndexName;
        public int blockPoint;
        public Vector2 position;
        public BlockPresenter(GameObject blockGameObject, int point)
        {
            this.blockGameObject = blockGameObject;
            this._point = point;
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
            attacher.thisPresenter = this;
        }
    }
}