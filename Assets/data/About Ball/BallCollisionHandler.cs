using data.blockModels;
using UnityEngine;

namespace data.About_Ball
{
    public class BallCollisionHandler : MonoBehaviour
    {
        //public Viewer viewer;
        private Rigidbody2D _rb;
        private BallData _ballData;
        public Viewer theViewer;
        private void Start()
        {
            _ballData = gameObject.GetComponent<BallData>();
            _rb = transform.GetComponent<Rigidbody2D>();
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("end"))
            {
                Destroy(transform.gameObject);
                _ballData.thisBallHandler.FinishTheGame();
                
            }


            var position = transform.position;
            var collidPose = other.ClosestPoint(position);
            var normal = collidPose - (Vector2)position;
            normal = new Vector2(normal.x, normal.y);
            var velocity = _rb.velocity; 
            var mirror = Mirror(velocity, normal);
            _rb.velocity = new Vector2(mirror.x, mirror.y);
            if (other.CompareTag($"block"))
            {
                var attacher = other.GetComponent<BlockData>();
                //var name = attacher.presenterForThisBlock.blockIndexName;
                attacher.presenterForThisBlock.Notify();
            }
            
            

        }

        private Vector2 Mirror(Vector2 v1, Vector2 normal)
        {
            var n = normal.normalized;
            v1 -= Vector2.Dot(n, v1) * n *2f;
            return v1;
        }
    }
}