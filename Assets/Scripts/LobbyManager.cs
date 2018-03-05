using System.Collections;
using System.Collections.Generic;

using Hashtable = ExitGames.Client.Photon.Hashtable;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
  public class LobbyManager : Photon.PunBehaviour {

    public byte MaxPlayersPerRoom = 4;



    void Awake () {
      PhotonNetwork.automaticallySyncScene = true;
    }

    void Start () {

    }

    void Update () {

    }

    public void JoinRandomMatch () {
      PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed (object[] codeAndMsg) {
      Debug.Log("ルーム入室に失敗しました");
      PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = MaxPlayersPerRoom }, null);
    }

    public override void OnJoinedRoom () {
      Debug.Log("ルームに入りました");
      PhotonNetwork.LoadLevel("GameRoom");
    }

  }

}
