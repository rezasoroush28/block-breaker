using Interfaces;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "BallPrefab", order = 4)]
    public class BallModel : ScriptableObject
    {
        [SerializeField] private BallCollisionHandler handler;
        public GameObject ballSample;
        public float velocity;
    }
}