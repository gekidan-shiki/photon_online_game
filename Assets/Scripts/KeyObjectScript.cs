using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
  public class KeyObjectScript : Photon.MonoBehaviour {

    public float keyObjectHP = 100f;
    public bool isActive = false;

    GameMaster _gameMaster;

    void Start () {
      _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
      isActive = true;
    }

    void Update () {
      if (isActive) {
        if (keyObjectHP <= 0) {
          _gameMaster.activeKeyObjectsCount -= 1;
          isActive = false;
        }
      } else {
        return;
      }
    }

    void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
      if (stream.isWriting) {
        stream.SendNext(keyObjectHP);
        stream.SendNext(isActive);
      } else {
        this.keyObjectHP = (float)stream.ReceiveNext();
        this.isActive = (bool)stream.ReceiveNext();
      }
    }

    void OnTriggerEnter (Collider col) {
      if (!photonView.isMine) {
        return;
      }
      if (col.gameObject.tag == "Player" || col.gameObject.tag == "Demon") {
        keyObjectHP -= 1f;
      }
    }

    void OnTriggerStay (Collider col) {
      if (!photonView.isMine) {
        return;
      }
      if (col.gameObject.tag == "Player" || col.gameObject.tag == "Demon") {
        keyObjectHP -= 10f * Time.deltaTime;
      }
    }
  }	
}

