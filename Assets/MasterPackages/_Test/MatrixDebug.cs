using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixDebug : MonoBehaviour
{
    [SerializeField] Transform T1 = null, T11 = null, T111 = null;

    Vector3 localVectorT111 = Vector3.one;
    Vector3 fromGlobalToLVT111;
    Vector3 fromT1ToLVT111;
    Vector3 fromT11ToLVT111;
    Vector3 fromT111ToLVT111;


    Matrix4x4 M1 = new Matrix4x4(new Vector4(0, 0, -1), new Vector4(0, 1, 0), new Vector4(-1, 0, 0), Vector4.one);

    private void Start()
    {
        Debug.Log("T1 :\n" + T1.localToWorldMatrix);
        //Debug.Log("T1 :\n" + MatrixApproximation(T1.worldToLocalMatrix, 3));
        Debug.Log("T11 :\n" + T11.localToWorldMatrix);
        //Debug.Log("T11 :\n" + MatrixApproximation(T11.worldToLocalMatrix, 3));
        Debug.Log("T111 :\n" + T111.localToWorldMatrix);
        //Debug.Log("T111 :\n" + MatrixApproximation(T111.worldToLocalMatrix, 3));
    }

    private void OnDrawGizmosSelected()
    {
        Vector4 LocalPoint = new Vector4(localVectorT111.x, localVectorT111.y, localVectorT111.z, 1);

        Gizmos.color = Color.yellow;

        Gizmos.color = Color.red;
        fromGlobalToLVT111 = T111.localToWorldMatrix * LocalPoint;
        Gizmos.DrawLine(Vector3.zero, fromGlobalToLVT111);

        Gizmos.color = Color.green;
        fromT1ToLVT111 = T111.localToWorldMatrix * T1.localToWorldMatrix.inverse * LocalPoint;
        Gizmos.DrawLine(Vector3.zero, fromT1ToLVT111);

        Gizmos.color = Color.blue;

    }
}