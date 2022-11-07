using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "LevelModel" , order = 1)]
    public class LevelModel : ScriptableObject
    {
        [System.Serializable]
        public struct RowData
        {
            public BrickPrefab[] bricks;
        
        }

        private struct BricksLocations
        {
            public struct MyStruct
            {
                
            }
        }
        public RowData[] rows ;
        public GameObject ballSample;
        public GameObject hoverSample;

        [TextArea] [SerializeField]  string comment = "points for every star";
        public int[] pointCount = new int[3];
    }
}