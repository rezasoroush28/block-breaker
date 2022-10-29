using System.Collections;
using System.Collections.Generic;
using data.prefabs;
using UnityEngine;
using Random = System.Random;


public class GameSceneHandler : MonoBehaviour
{
    [SerializeField] private LevelModel brickSettingData; 
    [SerializeField] private BrickModel brickSahapeData;
    [SerializeField] private Vector2[] boundries;
    List<GameObject>[] allBricksArray;
    public void OrgnizeTheData()
    {
        
        
        for (int i = 0; i < brickSettingData.rows.Length; i++)
        {
            for (int j = 0; j < brickSettingData.rows[i].bricks.Length; j++)
            {
                
            }
        }
    }

    public  List<T> Randomize<T>(List<T> list)
    {
        List<T> randomizedList = new List<T>();
        Random rnd = new System.Random();
        while (list.Count > 0)
        {
            int index = rnd.Next(0, list.Count);
            randomizedList.Add(list[index]);
            list.RemoveAt(index);
        }

        return randomizedList;
    }




}