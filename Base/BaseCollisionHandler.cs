using System;
using UnityEngine;

public class BaseCollisionHandler : MonoBehaviour
{
    public event Action<Resour�e> ResourseCollecting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resour�e resourse))
        {
            resourse.IsCarryed = false;
            ResourseCollecting?.Invoke(resourse);
        }
    }
}