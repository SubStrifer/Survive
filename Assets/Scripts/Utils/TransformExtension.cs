using System.Linq;
using UnityEngine;

/// <summary>
/// Adds extra methods to the Transform class.
/// </summary>
public static class TransformExtension
{

    /// <summary>
    /// Destroys all children of this transform. Skips children listed in params skip.
    /// </summary>
    /// <param name="skip">Children to skip</param>
    public static void DestroyChildren(this Transform transform, params string[] skip)
    {
        foreach (Transform child in transform)
        {
            if (skip.Any(s => s == child.name))
                continue;

            GameObject.Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Rotates the transform so it looks at target position in 2D space.
    /// </summary>
    /// <param name="target">Position to look at</param>
    public static void LookAt2D(this Transform transform, Vector3 target)
    {
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    /// <summary>
    /// Rotates the transform so it looks at target position in 2D space.
    /// </summary>
    /// <param name="target">Transform to look at</param>
    public static void LookAt2D(this Transform transform, Transform target)
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


}
