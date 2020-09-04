using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField]
    private PhotonView pv;
    [SerializeField]
    public Text nome;
    [SerializeField]
    private GameObject canvasJogador;
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private GameObject posTiro;
    [SerializeField]
    private Image barraVida;
    public static Transform alvo;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        nome.text = pv.Owner.NickName;
        if(pv.IsMine){
            alvo = transform;
        }
    }

    // Update is called once per frame
    float t = 0;
    void Update()
    {
        if(pv.IsMine){
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(new Vector3(0 , 0 , 5 * Time.deltaTime));
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(new Vector3(0 , 0 , -5 * Time.deltaTime));
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Rotate(new Vector3(0 , -20 * Time.deltaTime, 0 ));
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Rotate(new Vector3(0 , 20 * Time.deltaTime, 0 ));
            }
            t += Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space) && t >= 0.5f){
                Tiros();
                t = 0;
            }
            nome.color = Color.red;
        }
        canvasJogador.gameObject.transform.LookAt(Camera.main.transform);
    }
    //[PunRPC]
    private void Tiros(){
        PhotonNetwork.Instantiate(bala.name,posTiro.transform.position,transform.rotation,0);  
        //Instantiate(bala,posTiro.transform.position,transform.rotation); 
    }

    public void Danos(float val){
        pv.RPC("ChamaDano",RpcTarget.AllBuffered,val);
    }

    [PunRPC]
    void ChamaDano(float dano){
        barraVida.fillAmount -= dano/100;
    }
}
