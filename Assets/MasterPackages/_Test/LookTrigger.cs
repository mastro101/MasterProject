using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTrigger : MonoBehaviour
{
    [SerializeField] Transform obj = null;
    [SerializeField] [Range(0, 1)] float treshold = 0.5f;

    Vector2 lookDirection;
    Vector2 differenceVector;
    Vector2 differenceVectorDirection;
    float dotOfLookAndObj;

    private void OnDrawGizmos()
    {
        lookDirection = transform.up / transform.up.magnitude;
        differenceVector = obj.position - transform.position;
        differenceVectorDirection = differenceVector / differenceVector.magnitude;
        dotOfLookAndObj = lookDirection.x * differenceVectorDirection.x + lookDirection.y * differenceVectorDirection.y;

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + VectorUtility.FromV2ToV3XYZ(differenceVectorDirection));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + VectorUtility.FromV2ToV3XYZ(differenceVectorDirection) * dotOfLookAndObj);

        if (dotOfLookAndObj > treshold)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + VectorUtility.FromV2ToV3XYZ(lookDirection));
    }

    float GetDotProduct(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }
}