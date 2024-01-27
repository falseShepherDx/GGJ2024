using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class B_Shift_Ending : MonoBehaviour
{
    public TextMeshProUGUI saatText;

    private int saat = 4;
    private int dakika = 30;
    private float zamanGecikmesi = 1f; // 1 saniye
    public  Transform workersParent;
    int childCount;

    void Start()
    {
        InvokeRepeating("SaatýGuncelle", 0f, zamanGecikmesi);
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
    void SaatýGuncelle()
    {
        dakika++;

        if (dakika == 60)
        {
            dakika = 0;
            saat++;
        }

        if (saat == 12)
        {
            saat = 0;
        }

        if (saat == 5 && dakika == 0)
        {
            GameEnder();
        }

        GuncelSaatGoster();
    }

    void GuncelSaatGoster()
    {
        string saatMetni = string.Format("{0:00}:{1:00}", saat, dakika);
        saatText.text = saatMetni;
    }


}
