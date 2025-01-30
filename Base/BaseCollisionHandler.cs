using System;
using UnityEngine;

public class BaseCollisionHandler : MonoBehaviour
{
    public event Action<Resource> ResourseCollecting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resource resourse))
        {
            ResourseCollecting?.Invoke(resourse);
            resourse.ActionAfterHit();
        }
    }
}