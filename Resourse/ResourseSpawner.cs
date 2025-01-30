using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class ResourseSpawner : MonoBehaviour
{
    [SerializeField] private Resource _prefab;
    [SerializeField] private int _poolDefaultCapacity = 5;
    [SerializeField] private int _poolMaxSize = 12;
    [SerializeField] private float _secondsTillSpawn = 7;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    private ObjectPool<Resource> _pool;

    private void Awake()
    {
        _wait = new WaitForSeconds(_secondsTillSpawn);

        _pool = new ObjectPool<Resource>(
            actionOnGet: (res) => PlaceResource(res),
            createFunc: () => InstantiateResource(),
            actionOnRelease: (res) => res.gameObject.SetActive(false),
            actionOnDestroy: (res) => Destroy(res),
            collectionCheck: true,
            defaultCapacity: _poolDefaultCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnResource());
    }

    public void ReleaseResource(Resource resource)
    {
        _pool.Release(resource);
        resource.ReleaseResource -= ReleaseResource;
    }

    private void GetResource()
    {
        _pool.Get();
    }

    private void PlaceResource(Resource resource)
    {
        resource.transform.position = SetPosition();
        resource.gameObject.SetActive(true);
        resource.ReleaseResource += ReleaseResource;
    }

    private Vector3 SetPosition()
    {
        Vector3 position = transform.localPosition;
        float minRandomX = -15f;
        float maxRandomX = 15f;
        float minRandomZ = -10f;
        float maxRandomZ = 10f;

        position.x = transform.position.x - Random.Range(minRandomX, maxRandomX);
        position.z = transform.position.z - Random.Range(minRandomZ, maxRandomZ);
        position.y = transform.position.y - 4.5f;

        return position;
    }

    private Resource InstantiateResource()
    {
        return Instantiate(_prefab);
    }

    private IEnumerator SpawnResource()
    {
        while (enabled)
        {
            GetResource();
            yield return _wait;
        }
    }
}