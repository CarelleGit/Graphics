using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineFreeLook camera;
    private void Update()
    {
        transform.rotation = Quaternion.AngleAxis(camera.m_XAxis.Value, Vector3.up);
    }




}
