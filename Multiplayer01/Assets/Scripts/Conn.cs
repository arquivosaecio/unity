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
    public GameObject[] jogador;
    [SerializeField]
    public int id;

    //[SerializeField]
    //private Text txtNick;

    // Start is called before the first frame update

    public static Conn instance; // Fazendo a minha classe Conn.cs ficar vísivel a todas as fases do jogo

    void Awake() {
        if(instance == null){ // instância não foi inicializada? "o arquivo está oculto?"
            instance = this; // torne o arquivo visível
            DontDestroyOnLoad(this.gameObject); // manter a classe viva por toda a execução do jogo
        }else{
            Destroy(gameObject); // destruir as outras, não a minha
        }
    }

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true;
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
        //txtNick.text = PhotonNetwork.NickName;
        //painelS.SetActive(false); // ocultar e descocultar paineis...
        // String nome , coordenadas criação objeto, ângulos criação objeto, grupo = 0
        //PhotonNetwork.Instantiate(jogador.name , new Vector3(0 , Random.Range(1,8) , 0) , Quaternion.Euler(45,45,45) , 0);
        //PhotonNetwork.Instantiate(jogador[id].name , new Vector3(Random.Range(1,8) , 2 , Random.Range(1,8) ) , Quaternion.identity , 0);
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void SetID(int Id){
        id = Id;
        print("Set ID = ");
        print(id);
    }

}
