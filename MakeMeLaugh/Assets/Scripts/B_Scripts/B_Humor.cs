using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Humor : MonoBehaviour
{
   
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void Humoric_Shot()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == this.gameObject.tag)
        {
            Humoric_Shot();
        }
    }
}
