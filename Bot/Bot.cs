using System;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Transform _basePoint;
    [SerializeField] private BotCollisionHandler _collisionHandler;
    [SerializeField] private GrabPoint _grabPoint;

    private bool _isGotMission = false;
    private bool _isGotResource = false;
    private Resource _gatheredResourse;

    public bool GotMission => _isGotMission;
    public bool GotResource => _isGotResource;

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
        _isGotResource = false;
        _gatheredResourse = null;
    }

    private void GetResource(Resource resourse)
    {
        _gatheredResourse = resourse;
        _isGotResource = true;
        Stoping?.Invoke();
        Moving?.Invoke(_basePoint.position);
    }

    private void GatherResource()
    {
        if (_gatheredResourse != null)
            _gatheredResourse.transform.position = _grabPoint.transform.position;
    }
}