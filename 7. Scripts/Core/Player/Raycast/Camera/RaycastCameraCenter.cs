using UnityEngine;

public sealed class RaycastCameraCenter : MonoBehaviour
{
    [SerializeField]
    private float _distanceRaycast;

    [SerializeField]
    private static Vector3 _pointRaycastHit;
    public static Vector3 PointRaycastHit => _pointRaycastHit;


    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit, _distanceRaycast))
        {
            _pointRaycastHit = rayHit.point;
        }
    }
}
