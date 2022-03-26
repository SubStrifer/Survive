using UnityEngine;

public class CompassScript : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 direction;

    private void Update() {
        direction.z = playerTransform.eulerAngles.y;
        transform.localEulerAngles = direction;
    }
}
