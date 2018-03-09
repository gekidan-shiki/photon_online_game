using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
  public class RoomInfoUIScript : Photon.PunBehaviour {

    public Text RoomMemberCountText;
    public Text KeyObjectCountText;

    public Room room;

    int activeKeyObjectCount = 0;

    GameMaster _gameMaster;

    void Start () {
      room = PhotonNetwork.room;
      _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Update () {
      RoomMemberCountText.text = "ルーム内人数 " + room.PlayerCount.ToString();
      KeyObjectCountText.text = "オブジェクト残り " + _gameMaster.activeKeyObjectsCount.ToString();
    }


  }	
}

