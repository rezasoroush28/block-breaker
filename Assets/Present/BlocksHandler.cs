using System.Collections.Generic;
using data;
using Interfaces;
using UnityEngine;

namespace Present
{
    
    public class BlocksHandler : IObsserver
    {
        public LevelModel level;
        public Vector2[] boundries = new Vector2[2];
        //public List<Dictionary<GameObject, Vector2>> bricksList;
        
        
        

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
                    if (level.rows[i].bricks[j].brickGameObject != null)
                    {
                        level.rows[i].bricks[j].position.x = boundries[1].x + (stepX * j);
                        level.rows[i].bricks[j].position.y = boundries[1].y + (stepY * i); 
                    }
                    else
                    {
                         continue;
                    }
                }
            }
            //positions Handlled;
        }

        public void UpdateIt()
        {
            
        }
    }
    
    
}