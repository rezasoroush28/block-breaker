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
            var pelocity = GetComponent<Rigidbody2D>().velocity;
            var normal = transform.position - other.transform.position;
            var nelocity = Vector2.Reflect(pelocity, normal);
            transform.GetComponent<Rigidbody2D>().velocity = nelocity;
        }
    }
}