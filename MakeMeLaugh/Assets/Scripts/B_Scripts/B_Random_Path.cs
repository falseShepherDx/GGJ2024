using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class B_Random_Path : MonoBehaviour
{
    public static Vector3 Point_Ge(Vector3 Start_Point, float Radius)
    {
        Vector3 Dir = Random.insideUnitSphere * Radius;
        Dir += Start_Point;
        NavMeshHit Hit_;
        Vector3 Final_Pos = Vector3.zero;
        if (NavMesh.SamplePosition(Dir, out Hit_, Radius, 1))
        {
            Final_Pos = Hit_.position;
        }
        return Final_Pos;
    }
}
