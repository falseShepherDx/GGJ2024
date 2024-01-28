using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class B_Humor : MonoBehaviour
{
    NavMeshAgent nvm;
    public Animator anim;
    public bool isLaughed = false;

    void Start()
    {
        nvm = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("A");
            Humoric_Shot();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("S");
            Dead();
        }
    }

    void Humoric_Shot()
    {
        isLaughed = true;
        nvm.speed = 0;
        anim.SetBool("laugh" ,true);
    }
    void Dead()
    {
        nvm.speed = 0;
        anim.SetBool("dead", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == this.gameObject.tag)
        {
            Debug.Log("as");
            Destroy(other.gameObject,0.1f);
            Humoric_Shot();
        }
    }
}
