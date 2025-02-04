using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStorage : MonoBehaviour
{
    [SerializeField] private BaseCollisionHandler _baseCollisionHandler;

    private List<Resource> _collectedResources = new();

    public event Action<int> TextChanging;
    public event Action<Resource> ResourceCollected;

    private void OnEnable()
    {
        _baseCollisionHandler.ResourseCollecting += CollectResource;
    }

    private void OnDisable()
    {
        _baseCollisionHandler.ResourseCollecting -= CollectResource;
    }

    private void CollectResource(Resource resource)
    {
        ResourceCollected?.Invoke(resource);
        TextChanging?.Invoke(_collectedResources.Count);
        _collectedResources.Add(resource);
    }
}