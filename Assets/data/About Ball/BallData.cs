using UnityEngine;

namespace data.About_Ball
{
    public class BallData : MonoBehaviour
    {
        public GameObject thisGameObject;
        public float velocity;
        public Viewer viewer;


        public void SetTheViewer(Viewer theViewer)
        {
            viewer = theViewer;
        }
        public Vector2 Pose
        {
            get
            {
                var pose = (Vector2)transform.position;
                return pose;
            }
            set
            {
                transform.position = value;
            }
        }

        public Vector2 Direction
        {
            get
            {
                var direction = (Vector2)transform.GetComponent<Rigidbody2D>().velocity.normalized;
                return direction;
            }
            set
            {
                transform.GetComponent<Rigidbody2D>().velocity = value;
            }
        }
    }
}