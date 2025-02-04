using System;
using UnityEngine;

public class BaseCollisionHandler : MonoBehaviour
{
    [SerializeField] ResourceAllocator _resourceAllocator;

    public event Action<Resource> ResourseCollecting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resource resourse) && _resourceAllocator.OccupiedObjects.Contains(resourse))
        {
            ResourseCollecting?.Invoke(resourse);
            resourse.ActionAfterHit();
        }
    }
}