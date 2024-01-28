using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Menu_Camera : MonoBehaviour
{
    public Camera Camera;
    public Transform[] camPoses;
    public float interpolitionDuration;
   [SerializeField] private int index = 1;

    void Start()
    {
        index = 1;
    }

    void Update()
    {
        index = Mathf.Clamp(index, 0,2);
        if (Input.GetKeyDown(KeyCode.A))
        {
            index--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            index++;
        }
        CameraLookLerper(index);
    }

    void CameraLookLerper(int camPos )
    {
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, camPoses[camPos].position, interpolitionDuration);
        Camera.transform.rotation = Quaternion.Lerp(Camera.transform.rotation, camPoses[camPos].rotation, interpolitionDuration);
    }
}
