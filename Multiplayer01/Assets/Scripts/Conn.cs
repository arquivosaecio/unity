using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Conn : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject painelL, painelS;
    [SerializeField]
    private InputField nomeJogador, nomeSala;

    [SerializeField]
    private GameObject[] jogador;
    [SerializeField]
    private int id;

    [SerializeField]
    private Text txtNick;

    // Start is called before the first frame update
    void Start(){

    }

    public void Login(){
        PhotonNetwork.NickName = nomeJogador.text;
        PhotonNetwork.ConnectUsingSettings();
        painelL.SetActive(false);
        painelS.SetActive(true);
    }

    public void CriaSala(){
        PhotonNetwork.JoinOrCreateRoom(nomeSala.text , new RoomOptions() , TypedLobby.Default);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     PhotonNetwork.Disconnect();
        // }
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Conectado");
        PhotonNetwork.JoinLobby(); // Entrar na sala de espera
    }

    public override void OnJoinedLobby(){
        Debug.Log("Lobby");
    }

    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("Desconectado");
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Não entrou em nenhuma sala");
        //PhotonNetwork.CreateRoom(null,new RoomOptions());
    }

    public override void OnJoinedRoom(){
        Debug.Log("Entrou em uma sala");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        print(PhotonNetwork.NickName);
        txtNick.text = PhotonNetwork.NickName;
        painelS.SetActive(false);
        // String nome , coordenadas criação objeto, ângulos criação objeto, grupo = 0
        //PhotonNetwork.Instantiate(jogador.name , new Vector3(0 , Random.Range(1,8) , 0) , Quaternion.Euler(45,45,45) , 0);
        PhotonNetwork.Instantiate(jogador[id].name , new Vector3(Random.Range(1,8) , 2 , Random.Range(1,8) ) , Quaternion.identity , 0);
    }

    public void SetID(int Id){
        id = Id;
        print("Set ID = ");
        print(id);
    }

}
