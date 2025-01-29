using System;
using UnityEngine;

public class BaseCollisionHandler : MonoBehaviour
{
    public event Action<Resourñe> ResourseCollecting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resourñe resourse))
        {
            resourse.IsCarryed = false;
            ResourseCollecting?.Invoke(resourse);
        }
    }
}