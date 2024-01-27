using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class B_Humor : MonoBehaviour
{
    NavMeshAgent nvm;
    public Animator anim;

    void Start()
    {
        nvm = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            Humoric_Shot();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            Dead();
        }
    }

    void Humoric_Shot()
    {
        nvm.speed = 0;
        anim.SetBool("laugh" ,true);
    }
    void Dead()
    {
        nvm.speed = 0;
        anim.SetBool("dead", true);
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == this.gameObject.tag)
        {
            Humoric_Shot();
        }
    }
}
