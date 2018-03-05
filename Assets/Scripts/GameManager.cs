using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
	public class GameManager : Photon.PunBehaviour {

		static public GameManager Instance;

		public GameObject playerPrefab;
		public GameObject GameStartButton;
		public GameObject playerStartPos;
		public GameObject demonStartPos;

		GameObject myPlayer;

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
          myPlayer = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
				} else {
					Debug.Log("Ignoring scene load for "+ SceneManagerHelper.ActiveSceneName);
				}
			}

			if (!PhotonNetwork.isMasterClient) {
				GameStartButton.SetActive(false);
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

		public void OnClick_GameStartButton () {
      GameStartFunc();
		}

		public void GameStartFunc () {
			myPlayer.transform.position = demonStartPos.transform.position;
			myPlayer.GetComponent<PlayerManager>().isPlayerDemon = true;
			GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
			for (int i = 0; i < Players.Length; i++) {
				Players[i].GetComponent<PlayerManager>().isPlayingFlg = true;
			}
		}
  }	
}
