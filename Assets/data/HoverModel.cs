using Interfaces;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "HoverPrefab", order = 5)]
    public class HoverModel : ScriptableObject
    {
        public GameObject hoverSample;
        public float velocity;
        public void UpdateIt()
        {
        
        }
    }
}