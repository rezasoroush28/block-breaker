using UnityEngine;

namespace data.About_Hover
{
    public class HoverData : MonoBehaviour
    {
        public float movivngVelocity;
        public GameObject thisGameObject;

        public Vector2 Pose
        {
            get
            {
                return transform.position;
            }
            set
            {
                transform.position = (Vector2)value;
            }
        }
    }
    
    
}