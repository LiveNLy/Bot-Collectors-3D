using UnityEngine;

public class BaseScanerForResourses : MonoBehaviour
{
    private float _radius = 30f;

    public Resourñe GetResourse()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Resourñe resourse) == false)
                continue;

            if (resourse.HasBeenScaned)
                continue;

            resourse.HasBeenScaned = true;

            return resourse;
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}