using Interfaces;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "BallPrefab", order = 4)]
    public class BallModel : ScriptableObject,IObsserver
    {
        public GameObject ballSample;
        public float velocity;
        public void UpdateIt()
        {
        
        }
    }
}