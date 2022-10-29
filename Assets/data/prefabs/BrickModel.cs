using UnityEngine;

namespace data.prefabs
{
    [CreateAssetMenu(fileName = "BrickModel" , order = 1)]
    public class BrickModel : ScriptableObject
    {
        [SerializeField] private GameObject brickSample;
    }
}