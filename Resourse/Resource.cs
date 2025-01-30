using System;
using UnityEngine;

public class Resource : MonoBehaviour 
{
    public event Action<Resource> ReleaseResource;

    public void ActionAfterHit()
    {
        ReleaseResource?.Invoke(this);
    }
}