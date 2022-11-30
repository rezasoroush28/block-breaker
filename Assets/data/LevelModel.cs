using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace data
{
    [CreateAssetMenu(fileName = "LevelModel" , order = 1)]
    public class LevelModel : ScriptableObject
    {
        [FormerlySerializedAs("FireBlock")] public BrickModel fireBlock;
        public BrickModel normalBlock;
        public BrickModel freezBlock;


        
        public enum BlockCategories
        {
            None,
            Normal,
            Fire,
            Freez
            
        }
        [System.Serializable]
        public struct RowData
        {
            public BlockCategories[] bricks ;
        }

        


        public RowData[] rows ;
        public Vector2[] boundries = new Vector2[2];
        //to find boundries;
        
        [TextArea] [SerializeField]  string comment = "points for every star";
        public int[] pointCount = new int[3];
    }
}