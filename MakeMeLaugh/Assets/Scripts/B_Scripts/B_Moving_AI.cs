using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))] 

public class B_Moving_AI : MonoBehaviour
{
    [SerializeField] private float radius = 20f;
    [SerializeField] private bool debug_Bool;

    NavMeshAgent my_Agent;
    Vector3 next_Pos;
    void Start()
    {
        my_Agent = GetComponent<NavMeshAgent>();
        next_Pos = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(next_Pos, transform.position) <= 1.5f)
        {
            next_Pos = B_Random_Path.Point_Ge(transform.position, radius);
            my_Agent.SetDestination(next_Pos);
        }
        
    }
    private void OnDrawGizmos()
    {
        if (debug_Bool == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, next_Pos);
        }

    }
}
