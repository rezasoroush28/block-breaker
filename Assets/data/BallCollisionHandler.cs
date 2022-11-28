using System;
using UnityEngine;

namespace data
{
    public class BallCollisionHandler : MonoBehaviour
    {
        public Viewer viewer;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag($"block"))
            {
                var attacher = other.GetComponent<PresenterAttacher>();
                attacher.thisPresenter.Notify();
            }

            var collidPose = other.ClosestPointOnBounds(transform.position);
            var normal = collidPose - transform.position;
            normal = new Vector2(normal.x, normal.y);
            var velocity = transform.GetComponent<Rigidbody2D>().velocity; 
            transform.GetComponent<Rigidbody2D>().velocity = Mirror(velocity, normal);

        }

        private Vector2 Mirror(Vector2 v1, Vector2 normal)
        {
            var n = normal / normal.magnitude;
            v1 -= Vector2.Dot(n, v1) * n;
            return v1;
        }

        
    }
}