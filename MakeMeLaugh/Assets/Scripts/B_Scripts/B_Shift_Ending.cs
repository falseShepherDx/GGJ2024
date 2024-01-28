using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class B_Shift_Ending : MonoBehaviour
{
    public TextMeshProUGUI _timeText;

    private int hour = 0;
    private int minute = 0;
    private float timeDelay = 1f; 
    public  Transform workersParent;
    int childCount;

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

        }
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
