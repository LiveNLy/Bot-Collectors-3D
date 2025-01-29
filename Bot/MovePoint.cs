using UnityEngine;

public class MovePoint : MonoBehaviour
{
    private bool _isResourceThere = false;

    public bool IsResourceThere => _isResourceThere;

    private void Update()
    {
        CheckResource();
    }

    private void CheckResource()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Resourñe resourse))
                _isResourceThere = true;
            else
                _isResourceThere = false;
        }
    }
}