using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelModel" , order = 1)]
public class LevelModel : ScriptableObject
{
    [System.Serializable]
    public struct RowData
    {
        public GameObject[] bricks;
        
    }

    public RowData[] rows ;
}
