using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] ResourceSorter _resourceSorter;

    private List<Resource> _scannedResources = new();
    private float _radius = 30f;
    private Coroutine _scannerCoroutine;
    private WaitForSeconds _scannDelay = new WaitForSeconds(1);

    private void Start()
    {
        _scannerCoroutine = StartCoroutine(Scanning());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private IEnumerator Scanning()
    {
        while (enabled)
        {
            GetResources();

            yield return _scannDelay;
        }
    }

    private void GetResources()
    {
        _scannedResources.Clear();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Resource resourse))
            {
                _scannedResources.Add(resourse);
            }
        }

        _resourceSorter.GetResources(_scannedResources);
    }
}