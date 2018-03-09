using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Com.MyCompany.MyGame
{
  public class GameMaster : Photon.MonoBehaviour {

    // this object manages "KeyObject" array.
    // this manages situation who is winner.

    static public GameMaster Instance;

    public GameObject KeyObjectPrefab;

    public List<GameObject> keyObjects = new List<GameObject>();

    public int activeKeyObjectsCount = 0;
    public bool masterBePlaying = false;

    // this GameObject array spawn KeyObject.
    public GameObject[] KeyObjectSpawnPos;


    void Start () {
      // GameMaster prefab is instantiate only by MasterClient.
      if (PhotonNetwork.isMasterClient) {
        Instance = this;
      }

    }

    void Update () {

    }

    void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
      if (stream.isWriting) {
        stream.SendNext(activeKeyObjectsCount);
        stream.SendNext(masterBePlaying);
      } else {
        this.activeKeyObjectsCount = (int)stream.ReceiveNext();
        this.masterBePlaying = (bool)stream.ReceiveNext();
      }
    }

    public void CreateKeyObject () {
      for (int i = 0; i < PhotonNetwork.room.PlayerCount + 3; i++) {
        GameObject keyObject = PhotonNetwork.Instantiate("KeyObject", KeyObjectSpawnPos[i].transform.position, Quaternion.identity, 0) as GameObject;
        keyObjects.Add(keyObject);
        activeKeyObjectsCount++;
      }
    }

  }
}

