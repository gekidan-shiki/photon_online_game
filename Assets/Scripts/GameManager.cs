using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
	public class GameManager : Photon.PunBehaviour {

		static public GameManager Instance;
		public GameObject playerPrefab;

	  void Start () {
			Instance = this;
			if ( !PhotonNetwork.connected ) {
				SceneManager.LoadScene("Launcher");
				return;
			}
			if (playerPrefab == null) {
				Debug.LogError("プレハブがない");
			} else {
				if (PlayerManager.LocalPlayerInstance == null) {
					PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
				} else {
					Debug.Log("Ignoring scene load for "+ SceneManagerHelper.ActiveSceneName);
				}
			}
	  }
	
	  void Update () {
		
	  }

		public override void OnLeftRoom () {
			SceneManager.LoadScene("Lobby");
		}

		public void LeaveRoom () {
			PhotonNetwork.LeaveRoom();
		}
  }	
}
