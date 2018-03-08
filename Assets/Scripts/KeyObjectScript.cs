using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
  public class KeyObjectScript : MonoBehaviour {

    public float keyObjectHP = 100f;
    public bool isActive = false;

    GameMaster _gameMaster;

    void Start () {
      _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
      isActive = true;
    }

    void Update () {

    }
  }	
}

