using Interfaces;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "BrickPrefab", order = 3)]
    public class BrickModel : ScriptableObject,ISubject

    {
    // Start is called before the first frame update
    public GameObject brickGameObject;
    [SerializeField] private int brickPoint;
    public Vector2 position;

    public int ReturnTHePoint(GameObject brickgo)
    {
        return brickPoint;
    }

    public void Add(IObsserver obsserver)
    {
        
    }

    public void Remove(IObsserver obsserver)
    {
        
    }

    public void Notify()
    {
        throw new System.NotImplementedException();
    }
    }
}