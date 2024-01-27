using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Humor : MonoBehaviour
{
    public GameObject[] humor_Objects;
    void Start()
    {
        Chose_Random_Object();  
    }

    void Chose_Random_Object()
    {
        Vector3 objectPos = new Vector3(transform.position.x, transform.position.y  , transform.position.z);
        int randomIndex = Random.Range(0, humor_Objects.Length);

        GameObject humor_Object = Instantiate(humor_Objects[randomIndex], objectPos, transform.rotation);
        humor_Object.transform.parent = this.gameObject.transform;
        humor_Object.GetComponent<BoxCollider>().enabled = false;
    }
   
}
