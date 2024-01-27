using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class B_Random_Path : MonoBehaviour
{
    public static Vector3 Point_Ge(Vector3 Start_Point, float minRadius,float maxRadius)
    {
        Vector3 Dir = Random.insideUnitSphere * Random.Range(minRadius,maxRadius);
        Dir += Start_Point;
        NavMeshHit Hit_;
        Vector3 Final_Pos = Vector3.zero;
        if (NavMesh.SamplePosition(Dir, out Hit_, maxRadius, 1))
        {
            Final_Pos = Hit_.position;
        }
        return Final_Pos;
    }
}

