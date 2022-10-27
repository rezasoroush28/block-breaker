using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelModel" , order = 1)]
public class LevelModel : ScriptableObject
{
    //This is Level 1
    public abstract class Brick
    {
        //int health
        //bool isAvailable
    }
    
    
    [System.Serializable] public class BrickRows
    { 
        [SerializeField] private List<Brick> _listRows;
    }

    [SerializeField] private List<BrickRows> allBricks;


}
