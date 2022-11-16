using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "LevelModel" , order = 1)]
    public class LevelModel : ScriptableObject
    {
        [System.Serializable]
        public struct RowData
        {
            public BrickModel[] bricks;
        
        }

        private struct BricksLocations
        {
            public struct MyStruct
            {
                
            }
        }
        public RowData[] rows ;
        public Vector2[] boundries = new Vector2[2];
        //to find boundries;
        
        [TextArea] [SerializeField]  string comment = "points for every star";
        public int[] pointCount = new int[3];
    }
}