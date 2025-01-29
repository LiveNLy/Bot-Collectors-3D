using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private MovePoint _movePoint;
    [SerializeField] private BasePoint _basePoint;
    [SerializeField] private BotCollisionHandler _collisionHandler;

    private bool _isGotMission = false;
    private bool _isGotResource = false;
    private Resourñe _gatheredResourse;

    public bool GotMission => _isGotMission;
    public bool GotResource => _isGotResource;

    private void OnEnable()
    {
        _collisionHandler.TouchedResourse += GetResource;
        _collisionHandler.TouchedBase += GetToBase;
    }

    private void Update()
    {
        Move();
        GatherResource();
    }

    private void OnDisable()
    {
        _collisionHandler.TouchedResourse -= GetResource;
        _collisionHandler.TouchedBase -= GetToBase;
    }

    public void GetMission(Resourñe resourse)
    {
        _isGotMission = true;
        _movePoint.transform.position = resourse.transform.position;
    }

    private void GetToBase()
    {
        _isGotMission = false;
        _isGotResource = false;
        _gatheredResourse = null;
        _movePoint.transform.position = transform.position;
    }

    private void GetResource(Resourñe resourse)
    {
        _gatheredResourse = resourse;
        _gatheredResourse.IsCarryed = true;
        _isGotResource = true;
    }

    private void GatherResource()
    {
        if (_gatheredResourse != null)
            _gatheredResourse.transform.position = transform.position;
    }

    private void Move()
    {
        if (_isGotResource || !_isGotMission || !_movePoint.IsResourceThere)
        {
            transform.position = Vector3.Lerp(transform.position, _basePoint.transform.position, _speed * Time.deltaTime);
            transform.LookAt(_basePoint.transform);
        }
        else if (_isGotMission && _movePoint.IsResourceThere)
        {
            transform.position = Vector3.Lerp(transform.position, _movePoint.transform.position, _speed * Time.deltaTime);
            transform.LookAt(_movePoint.transform);
        }
    }
}