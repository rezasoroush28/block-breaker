using System;
using UnityEngine;

namespace data
{
    public class BallCollisionHandler : MonoBehaviour
    {
        public Viewer viewer;
        
        private void OnTriggerEnter(Collider other)
        {

            var attacher = other.GetComponent<PresenterAttacher>();
            attacher.thisPresenter.Notify();
        }
    }
}