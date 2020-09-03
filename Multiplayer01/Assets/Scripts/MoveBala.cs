using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MoveBala : MonoBehaviour
{
    [SerializeField]
    private Rigidbody bala;
    // Start is called before the first frame update
    void Start()
    {
        bala = GetComponent<Rigidbody>();
        bala.AddRelativeForce(Vector3.forward * 5 , ForceMode.Impulse);
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().IsMine){
            this.GetComponent<PhotonView>().RPC("MataBala",RpcTarget.All);
            col.GetComponent<Move>().Danos(10);
        }
    }
    [PunRPC]
    void MataBala(){
        Destroy(this.gameObject);
    }

}
