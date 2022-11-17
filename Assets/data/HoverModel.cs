using Interfaces;
using UnityEngine;

namespace data
{
    public class HoverModel : ScriptableObject,IObsserver
    {
        public GameObject hoverSample;
        public float velocity;
        public void UpdateIt()
        {
        
        }
    }
}