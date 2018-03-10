using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
  public class PlayerController : Photon.MonoBehaviour {

    public float playerSpeed = 5;
    public float playerRotation = 90;
    public float playerBulletSpeed = 1000;

    public Transform muzzle;

    public GameObject demonBullet;

    void Start () {

    }

    void Update () {
      if (photonView.isMine == false && PhotonNetwork.connected == true) {
        return;
      }
      Move();
      if (Input.GetKeyDown(KeyCode.S)) {
        ControlShoot();
      }
    }

    public void Move () {
      if (Input.GetKey("up")) {
        this.transform.position += this.transform.forward * playerSpeed * Time.deltaTime;
      }
      if (Input.GetKey("down")) {
        this.transform.position -= this.transform.forward * playerSpeed * Time.deltaTime;
      }
      if (Input.GetKey("right")) {
        this.transform.Rotate(new Vector3(0, playerRotation * Time.deltaTime, 0));
      }
      if (Input.GetKey("left")) {
        this.transform.Rotate(new Vector3(0, -playerRotation * Time.deltaTime, 0));
      }
    }

    public void ControlShoot () {
      Vector2 posXZ = new Vector2(muzzle.transform.position.x, muzzle.transform.position.z);
      float angle = transform.eulerAngles.y;
      this.photonView.RPC("Shoot", PhotonTargets.AllViaServer, posXZ, angle);
    }

    [PunRPC]
    private void Shoot (Vector2 i_pos, float i_angle) {
      if (demonBullet == null) {
        Debug.Log("demonBullet is null");
        return;
      }
      Vector3 pos = new Vector3(i_pos.x, 1.0f, i_pos.y);
      Quaternion rot = Quaternion.Euler(0.0f, i_angle, 0.0f);
      GameObject.Instantiate(demonBullet, pos, rot);
    }
  }	
}

