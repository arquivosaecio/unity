using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class vCamConf : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineVirtualCamera vCam;
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.m_Follow = Move.alvo.transform;
        vCam.m_LookAt = Move.alvo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
