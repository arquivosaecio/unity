﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CriaPlayer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(Conn.instance.jogador[Conn.instance.id].name , new Vector3(Random.Range(1,8) , 2 , Random.Range(1,8) ) , Quaternion.identity , 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
