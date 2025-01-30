using System.Collections.Generic;
using UnityEngine;

public class ResourceSorter : MonoBehaviour
{
    [SerializeField] Warehouse _warehouse;

    private List<Resource> _scannedResources = new();

    public void GetResources(List<Resource> resources)
    {
        _scannedResources = resources;

        Debug.Log(_scannedResources.Count);

        ResourceSorting();

        _scannedResources.Clear();
    }

    private void ResourceSorting()
    {
        List<Resource> resourses = new();

        foreach(Resource resource in _scannedResources)
        {
            if (!_warehouse.FreeResources.Contains(resource) && !_warehouse.OccupiedResources.Contains(resource))
            {
                resourses.Add(resource);
            }
        }

        _warehouse.GetResources(resourses);
    }
}