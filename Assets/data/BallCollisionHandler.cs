using System;
using data.prefabs.blockModels;
using UnityEngine;

namespace data
{
    public class BallCollisionHandler : MonoBehaviour
    {
        public Viewer viewer;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            

            var collidPose = other.ClosestPoint(transform.position);
            var normal = collidPose - (Vector2)transform.position;
            normal = new Vector2(normal.x, normal.y);
            var velocity = transform.GetComponent<Rigidbody2D>().velocity; 
            var mirror = Mirror(velocity, normal);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(mirror.x, mirror.y);
            
            if (other.CompareTag($"block"))
            {
                var attacher = other.GetComponent<BlockData>();
                var name = attacher.presenterForThisBlock.blockIndexName;
                attacher.presenterForThisBlock.Notify();
            }

        }

        private Vector2 Mirror(Vector2 v1, Vector2 normal)
        {
            var n = normal.normalized;
            v1 -= Vector2.Dot(n, v1) * n *2f;
            return v1;
        }

        private void Update()
        {
            var v = _rb.velocity;
            Debug.Log(v);
        }
    }
}