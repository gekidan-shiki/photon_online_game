using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
  public class RoomInfoUIScript : Photon.PunBehaviour {

    public Text RoomMemberCountText;

    public Room room;

    void Start () {
      room = PhotonNetwork.room;
    }

    void Update () {
      RoomMemberCountText.text = "ルーム内人数 " + room.PlayerCount.ToString();
    }
  }	
}

