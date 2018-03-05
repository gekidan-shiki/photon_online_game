using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Com.MyCompany.MyGame
{
	public class GameMaster : Photon.MonoBehaviour {

		// this object manages "KeyObject" array.
		// this manages situation who is winner.

		static public GameMaster Instance;


	  void Start () {
			// GameMaster prefab is instantiate only by MasterClient.
			if (PhotonNetwork.isMasterClient) {
				Instance = this;
			}
	
	  }
	
	  void Update () {
		
	  }

  }	
}

