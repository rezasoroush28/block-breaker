using System;
using data.prefabs.blockModels;
using UnityEngine;
using UnityEngine.Serialization;

namespace data
{
    [CreateAssetMenu(fileName = "LevelModel" , order = 1)]
    public class LevelModel : ScriptableObject
    {
        public BlockData fireBlock;
        public BlockData normalBlock;
        public BlockData freezBlock;
        public GameObject bound;
        
        
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