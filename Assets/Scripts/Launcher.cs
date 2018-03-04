using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
	public class Launcher : Photon.PunBehaviour {

    string _gameVersion = "1";
		bool isConnecting;

		public byte MaxPlayersPerRoom = 4;

		void Awake () {
			PhotonNetwork.autoJoinLobby = false;
		}

	  void Start () {
		
	  }
	
	  void Update () {
		
	  }

		// this method gets called when autoJoinLobby() is false, and connect to Photon.
		public override void OnConnectedToMaster () {
			if (isConnecting) {
				PhotonNetwork.JoinLobby();
				SceneManager.LoadScene("Lobby");
			}
		}

		public override void OnJoinedLobby () {
			if (isConnecting) {
				Debug.Log("Lobbyに入りました");
		  	//PhotonNetwork.JoinRandomRoom();
			}
		}

		public void Connect () {
			isConnecting = true;
			if (PhotonNetwork.connected) {
				PhotonNetwork.JoinLobby();
				SceneManager.LoadScene("Lobby");
			} else {
				PhotonNetwork.ConnectUsingSettings(_gameVersion);
			}
		}
  }
	
}
