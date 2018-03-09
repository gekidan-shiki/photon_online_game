using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
  public class PlayerManager : Photon.PunBehaviour {

    public static GameObject LocalPlayerInstance;

    public bool isPlayerDemon = false;
    public bool isPlaying = false;

    public float playerHP = 10f;

    GameMaster _gameMaster;

    void Awake () {
      if (photonView.isMine) {
        PlayerManager.LocalPlayerInstance = this.gameObject;
      }
      DontDestroyOnLoad(this.gameObject);
    }

    void Start () {

      CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();
      if (_cameraWork != null) {
        if (photonView.isMine) {
          _cameraWork.OnStartFollowing();
        }
      } else {
        Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.",this);
      }

      _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();

    }

    void Update () {
      if (!photonView.isMine) {
        return;
      }
      if (isPlaying != _gameMaster.masterBePlaying) {
        isPlaying = _gameMaster.masterBePlaying;
      }

    }

    void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
      if (stream.isWriting) {
        stream.SendNext(playerHP);
        stream.SendNext(isPlaying);
      } else {
        this.playerHP = (float)stream.ReceiveNext();
        this.isPlaying = (bool)stream.ReceiveNext();
      }
    }


  }

}
