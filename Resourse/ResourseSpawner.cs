using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class ResourseSpawner : MonoBehaviour
{
    [SerializeField] private Resourñe _prefab;
    [SerializeField] private int _poolDefaultCapacity = 5;
    [SerializeField] private int _poolMaxSize = 12;
    [SerializeField] private BaseCollisionHandler _collisionHandler;
    [SerializeField] private float _secondsTillSpawn = 7;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    private ObjectPool<Resourñe> _pool;

    private void Awake()
    {
        _wait = new WaitForSeconds(_secondsTillSpawn);

        _pool = new ObjectPool<Resourñe>(
            actionOnGet: (res) => SetObject(res),
            createFunc: () => InstantiateObject(),
            actionOnRelease: (res) => res.gameObject.SetActive(false),
            actionOnDestroy: (res) => Destroy(res),
            collectionCheck: true,
            defaultCapacity: _poolDefaultCapacity,
            maxSize: _poolMaxSize);
    }

    private void OnEnable()
    {
        _collisionHandler.ResourseCollecting += ReleaseObject;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnObject());
    }

    private void OnDisable()
    {
        _collisionHandler.ResourseCollecting += ReleaseObject;
    }

    public void ReleaseObject(Resourñe resource)
    {
        _pool.Release(resource);
    }

    private void GetObject()
    {
        _pool.Get();
    }

    private void SetObject(Resourñe resource)
    {
        resource.transform.position = SetPosition();
        resource.HasBeenScaned = false;
        resource.gameObject.SetActive(true);
    }

    private Vector3 SetPosition()
    {
        Vector3 position = transform.position;
        float minRandomX = -15f;
        float maxRandomX = 15f;
        float minRandomZ = -11f;
        float maxRandomZ = 11f;

        position.x = transform.position.x - Random.Range(minRandomX, maxRandomX);
        position.z = transform.position.z - Random.Range(minRandomZ, maxRandomZ);
        position.y = transform.position.y - 4.5f;

        return position;
    }

    private Resourñe InstantiateObject()
    {
        return Instantiate(_prefab);
    }

    private IEnumerator SpawnObject()
    {
        while (enabled)
        {
            GetObject();
            yield return _wait;
        }
    }
}