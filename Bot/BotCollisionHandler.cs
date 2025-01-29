using System;
using UnityEngine;

public class BotCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bot _bot;

    public event Action<Resour�e> TouchedResourse;
    public event Action TouchedBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Resour�e resourse))
        {
            if (!resourse.IsCarryed && !_bot.GotResource)
            {
                TouchedResourse?.Invoke(resourse);
            }
        }
        else if (other.gameObject.TryGetComponent(out BasePoint basePoint))
        {
            TouchedBase?.Invoke();
        }
    }
}