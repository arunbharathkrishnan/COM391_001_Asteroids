using UnityEngine;
using System.Collections;
using System;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class PlayerDeath : MonoBehaviour {

		public event Action EventDieComplete;

		[SerializeField]
		private GameObject explosionPrefab;

		[SerializeField]
		private float duration = 1.0f;

		[SerializeField]
		private AudioClip deathSound;

		private GameObject explosionGO;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {

		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Die. Show explosion and dispatch complete when done.
		
		public void Die() {
			explosionGO = Instantiate( explosionPrefab, transform.position, Quaternion.identity ) as GameObject;
			AudioManager.Instance.PlaySFX( deathSound );
			Invoke( "DieComplete", duration );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		// Dispatches event when dieath anim is complete.
		
		private void DieComplete() {
			Destroy( explosionGO );

			if( EventDieComplete != null ) {
				EventDieComplete();
			}
		}

	}
}