using System.Collections.Generic;
using Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace data
{
    
    [CreateAssetMenu(fileName = "BrickPrefab", order = 3)]
    public class BrickModel : ScriptableObject,ISubject
    {
    // Start is called before the first frame update
    public GameObject brickGameObject;

    [SerializeField] private BrickModelHandller handler;
    public int brickPoint;
    public List<IObsserver> obsservers;
    public Vector2 position;
    public string brickIndexName;

    
    public void AttachGameObjectsToModels()
    {
        handler.thisModel = this;
    }
    
    public BrickModel(List<IObsserver> obsservers)
    {
        this.obsservers = obsservers;
    }
    public void Add(IObsserver obsserver)
    {
        obsservers.Add(obsserver);
    }

    public void Remove(IObsserver obsserver)
    {
        obsservers.Remove(obsserver);
    }

    public void Notify()
    {
        var obsArray = obsservers.ToArray();
        foreach (var obs in obsArray)
        {
            obs.UpdateIt(this);
        }
    }
    }
}