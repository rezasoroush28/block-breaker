using System.Collections.Generic;
using data;
using UnityEngine;

namespace Present
{
    [CreateAssetMenu(fileName = "BlocksHandler" , order = 2)]
    public class BlocksHandler : ScriptableObject
    {
        [SerializeField] private LevelModel level;
        [SerializeField] private Vector2[] boundries = new Vector2[2];
        public List<Dictionary<GameObject, Vector2>> bricksList;
        
        
        

        public void ReturnTheBricks()
        {
            var stepX = -(boundries[0].x - boundries[1].x);
            var stepY = -(boundries[0].y - boundries[1].y);
            var rows = level.rows;
            //var cul = level.rows[0];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].bricks.Length; j++)
                {
                    bricksList.Add();
                }
            }
        }
    }
    
    
}