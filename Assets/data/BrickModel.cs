using System.Collections.Generic;
using Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace data
{
    
    [CreateAssetMenu(fileName = "BrickPrefab", order = 3)]
    public class BrickModel : ScriptableObject
    {
    // Start is called before the first frame update
    public GameObject brickGameObject;
    public int brickPoint;
    }
}