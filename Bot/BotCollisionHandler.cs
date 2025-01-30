using System;
using UnityEngine;

public class BotCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bot _bot;

    private Resource _targetResourse;

    public event Action<Resource> TouchedResourse;
    public event Action TouchedBase;

    private void OnEnable()
    {
        _bot.TakeMission += GetTargetResource;
    }

    private void OnDisable()
    {
        _bot.TakeMission -= GetTargetResource;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resource resourse))
        {
            if (resourse == _targetResourse)
            {
                TouchedResourse?.Invoke(resourse);
            }
        }
        else if (other.gameObject.TryGetComponent(out Base mainBase))
        {
            TouchedBase?.Invoke();
        }
    }

    private void GetTargetResource(Resource resource)
    {
        _targetResourse = resource;
    }
}