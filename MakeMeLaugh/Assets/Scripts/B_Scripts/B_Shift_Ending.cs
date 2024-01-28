using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class B_Shift_Ending : MonoBehaviour
{
    public TextMeshProUGUI _timeText;

    private int hour = 4;
    private int minute = 50;
    private float timeDelay = 1f; 
    public  Transform workersParent;
    int childCount;
    int laughedWorked = 0;

    void Start()
    {
        InvokeRepeating("UpdateHour", 0f, timeDelay);
        Transform parentTransform = workersParent;

    }
    void GameEnder()
    {
        childCount = workersParent.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = workersParent.GetChild(i);
            Animator childAnim = childTransform.GetComponent<Animator>();
            NavMeshAgent childNavMesh = childTransform.GetComponent<NavMeshAgent>();
            childNavMesh.speed = 0;
            childAnim.SetBool("dead", true);
            if (childTransform.GetComponent<B_Humor>().isLaughed == true) laughedWorked++;
        }

        if (laughedWorked != workersParent.childCount) StartCoroutine(TryAgain());
        else StartCoroutine(LevelComplate());
       
    }

   IEnumerator TryAgain()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

    IEnumerator LevelComplate()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void UpdateHour()
    {
        minute++;

        if (minute == 60)
        {
            minute = 0;
            hour++;
        }

        if (hour == 12)
        {
            hour = 0;
        }

        if (hour == 5 && minute == 0)
        {
            timeDelay = 0;
            GameEnder();
        }

        ShowCurrentTime();
    }

    void ShowCurrentTime()
    {
        string timeText = string.Format("{0:00}:{1:00}", hour, minute);
        _timeText.text = timeText;
    }


}
