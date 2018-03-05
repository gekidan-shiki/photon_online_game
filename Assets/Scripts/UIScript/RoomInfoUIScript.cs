using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
	public class RoomInfoUIScript : Photon.MonoBehaviour {

		public Text RoomMemberCountText;

		public Room room = PhotonNetwork.room;

	  void Start () {
		
	  }
	
	  void Update () {
		  RoomMemberCountText.text = "ルーム内人数 " + room.playerCount.ToString();
	  }
  }	
}

