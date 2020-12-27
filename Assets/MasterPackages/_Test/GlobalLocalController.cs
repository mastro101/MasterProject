using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLocalController : MonoBehaviour
{
    [SerializeField] Transform obj1= null;
    [SerializeField] Transform obj2 = null;
    [SerializeField] Vector3 vector = Vector3.one;

    private void OnDrawGizmos()
    {
        if (obj2)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(obj2.position, obj2.position + GlobalToLocal(obj2, vector));
            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, LocalToGlobal(vector, obj2.position, obj2.up, obj2.forward));
            if (obj1)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(Vector3.zero, LocalToLocal(vector, obj2, obj1));
            }
        }
    }

    Vector3 LocalToGlobal(Vector3 v, Vector3 center, Vector3 upV, Vector3 forwardLook)
    {
        Vector3 up = upV.normalized;
        Vector3 right = Vector3.Cross(up, forwardLook).normalized;
        Vector3 forward = Vector3.Cross(right, up).normalized;

        Matrix4x4 matrix4X4 = new Matrix4x4(right, up, forward, VectorUtility.NewVector4(center, 1));

        return matrix4X4 * VectorUtility.NewVector4(v, 1);
    }

    Vector3 LocalToGlobal(Transform t, Vector3 v)
    {
        return t.localToWorldMatrix * VectorUtility.NewVector4(v, 1);
    }

    Vector3 GlobalToLocal(Transform t, Vector3 v)
    {
        Vector3 x = t.right * v.x;
        Vector3 y = t.up * v.y;
        Vector3 z = t.forward * v.z;

        return x + y + z;

        //return t.localToWorldMatrix.inverse * VectorUtility.NewVector4(v, 1);
    }

    Vector3 LocalToLocal(Vector3 v, Transform t1, Transform t2, float w = 1)
    {
        return t1.localToWorldMatrix * t2.localToWorldMatrix.inverse * VectorUtility.NewVector4(v, w);
    }

    //Vector2 LocalToGlobal(Vector2 v, Vector3 center, Vector2 up)
    //{
    //    Vector2 vUp = up.normalized;
    //    Vector2 vRight = Vector3.Cross(up, Vector3.forward).normalized;

    //    Vector2 diffV = VectorUtility.FromV3ToV2XY(transform.position) - v;
    //    float x = Vector2.Dot(diffV, vRight);
    //    float y = Vector2.Dot(diffV, vUp);

    //    return new Vector2(x, y);
    //}
    
    //Vector3 LocalToGlobal(Vector3 v, Vector3 center, Vector3 up, Vector3 forwardLook)
    //{
    //    Vector2 vUp = up.normalized;
    //    Vector2 vRight = Vector3.Cross(vUp, forwardLook).normalized;
    //    Vector3 vForward = Vector3.Cross(vRight, vUp).normalized;

    //    float x = Vector3.Dot(v, vRight);
    //    float y = Vector3.Dot(v, vUp);
    //    float z = Vector3.Dot(v, vForward);

    //    return new Vector3(x, y, z);
    //}

    //Vector2 LocalToGlobal(Transform t)
    //{
    //    return LocalToGlobal(t.position, t.up);
    //}
}