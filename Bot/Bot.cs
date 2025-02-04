using System;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Transform _basePoint;
    [SerializeField] private BotCollisionHandler _collisionHandler;
    [SerializeField] private GrabPoint _grabPoint;

    private bool _isGotMission = false;
    private Resource _gatheredResourse;

    public bool GotMission => _isGotMission;

    public event Action<Vector3> Moving;
    public event Action<Resource> TakeMission;
    public event Action Stoping;

    private void OnEnable()
    {
        _collisionHandler.TouchedResourse += GetResource;
        _collisionHandler.TouchedBase += GetToBase;
    }

    private void Update()
    {
        GatherResource();
    }

    private void OnDisable()
    {
        _collisionHandler.TouchedResourse -= GetResource;
        _collisionHandler.TouchedBase -= GetToBase;
    }

    public void GetMission(Resource resourse)
    {
        Stoping?.Invoke();
        _isGotMission = true;
        TakeMission?.Invoke(resourse);
        Moving?.Invoke(resourse.transform.position);
    }

    private void GetToBase()
    {
        _isGotMission = false;
        _gatheredResourse = null;
    }

    private void GetResource(Resource resourse)
    {
        _gatheredResourse = resourse;
        Stoping?.Invoke();
        Moving?.Invoke(_basePoint.position);
    }

    private void GatherResource()
    {
        if (_gatheredResourse != null)
            _gatheredResourse.transform.position = _grabPoint.transform.position;
    }
}