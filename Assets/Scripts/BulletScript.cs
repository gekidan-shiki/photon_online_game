using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
	[RequireComponent(typeof(Rigidbody))]
	public class BulletScript : MonoBehaviour {

		[SerializeField]
		public float m_moveForce = 1000.0f;

		[SerializeField]
		private float m_destroyedTime = 3.0f;

		private Rigidbody m_rigidbody = null;

		void Awake () {
			m_rigidbody = this.gameObject.GetComponent<Rigidbody>();
		}

	  void Start () {
			m_rigidbody.AddForce(this.gameObject.transform.forward * m_moveForce);
			GameObject.Destroy(gameObject, m_destroyedTime);
	  }

		void OnTriggerEnter (Collider col) {
			GameObject.Destroy(gameObject);
		}
  }	
}

