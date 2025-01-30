using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private BaseCollisionHandler _baseCollisionHandler;

    private List<Resource> _freeResources = new();
    private List<Resource> _occupiedResources = new();

    public List<Resource> FreeResources => _freeResources;
    public List<Resource> OccupiedResources => _occupiedResources;

    private void OnEnable()
    {
        _baseCollisionHandler.ResourseCollecting += RemoveCollectedResources;
    }

    private void OnDisable()
    {
        _baseCollisionHandler.ResourseCollecting -= RemoveCollectedResources;
    }

    public void UnfreedResources(Resource resourse)
    {
        _occupiedResources.Add(resourse);
        _freeResources.Remove(resourse);
    }

    public void GetResources(List<Resource> resources)
    {
        foreach (Resource resource in resources)
        {
            _freeResources.Add(resource);
        }
    }

    private void RemoveCollectedResources(Resource resource)
    {
        _occupiedResources.Remove(resource);
    }
}