using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Worker_Dedector : MonoBehaviour
{
   public  B_Moving_AI moveingAI;
   
    void Start()
    {
        moveingAI = GetComponentInParent<B_Moving_AI>();
    }

   
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Worker"))
        {
            StartCoroutine(workerClose());
        }
    }

    IEnumerator workerClose()
    {
        Debug.Log("Yakýnda çalýþan var ! ");
      
        moveingAI.nextPos();
        yield return new WaitForSeconds(0.5f);
        
    }
}
