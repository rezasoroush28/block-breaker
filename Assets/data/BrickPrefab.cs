using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "BrickPrefab" , order = 3)]
    public class BrickPrefab : ScriptableObject
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject brickGameObject;
        [SerializeField] private int brickPoint;
        public  Vector2 position;
        public int ReturnTHePoint(GameObject brickgo)
        {
            return brickPoint;
        }
    }
}