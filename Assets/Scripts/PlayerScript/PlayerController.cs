﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
  public class PlayerController : Photon.MonoBehaviour {

    public float playerSpeed = 5;
    public float playerRotation = 90;
    public float playerBulletSpeed = 1000;

    //public GameObject playerBulletPrefab;
    //public GameObject demonBulletPrefab;
    public Transform muzzle;

    void Start () {

    }

    void Update () {
      if (photonView.isMine == false && PhotonNetwork.connected == true) {
        return;
      }
      Move();
      Shoot();
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

    public void Shoot () {
      if (Input.GetKeyDown(KeyCode.Z)) {
        GameObject bullets;
        if (PhotonNetwork.isMasterClient) {
          bullets = PhotonNetwork.Instantiate("DemonBullet", muzzle.transform.position, Quaternion.identity, 0);
        } else {
          bullets = PhotonNetwork.Instantiate("PlayerBullet", muzzle.transform.position, Quaternion.identity, 0);
        }
        Vector3 force;
        force = this.gameObject.transform.forward * playerBulletSpeed;
        bullets.GetComponent<Rigidbody>().AddForce(force);
      }
    }
  }	
}

