using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class MinhaCam : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private CinemachineVirtualCamera vCam;
    [SerializeField]
    private Camera camera;
    void Start()
    {
        Instantiate(camera);
        Instantiate(vCam);
        Debug.Log("Cameras Criadas...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
