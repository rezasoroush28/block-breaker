using System;
using data.prefabs.blockModels;
using UnityEngine;

namespace data
{
    public class BallCollisionHandler : MonoBehaviour
    {
        public Viewer viewer;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"block"))
            {
                var attacher = other.GetComponent<BlockData>();
                var name = attacher.presenterForThisBlock.blockIndexName;
                attacher.presenterForThisBlock.Notify();
            }

            var collidPose = other.ClosestPoint(transform.position);
            var normal = collidPose - (Vector2)transform.position;
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