using System;
using UnityEngine;

namespace data
{
    public class BallCollisionHandler : MonoBehaviour
    {
        public Viewer viewer;
        
        private void OnTriggerEnter(Collider other)
        {
            var handler = other.GetComponent<BrickModelHandller>();
            handler.thisModel.Notify();
        }
    }
}