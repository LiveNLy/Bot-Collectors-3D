using System.Collections.Generic;
using UnityEngine;

public class ResourceAllocator : Allocator<Resource>
{
    [SerializeField] private ResourceStorage _resourceStorage;

    public List<Resource> FreeObjects => _freeObjects;
    public List<Resource> OccupiedObjects => _occupiedObjects;

    private void OnEnable()
    {
        _resourceStorage.ResourceCollected += RemoveCollectedResources;
    }

    private void OnDisable()
    {
        _resourceStorage.ResourceCollected -= RemoveCollectedResources;
    }

    public void UnfreedResources(Resource resourse)
    {
        _occupiedObjects.Add(resourse);
        _freeObjects.Remove(resourse);
    }

    public void GetResources(List<Resource> resources)
    {
        foreach (Resource resource in resources)
        {
            _freeObjects.Add(resource);
        }
    }

    private void RemoveCollectedResources(Resource resource)
    {
        _occupiedObjects.Remove(resource);
    }
}