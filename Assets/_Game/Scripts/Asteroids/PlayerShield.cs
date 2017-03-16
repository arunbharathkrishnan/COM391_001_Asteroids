using UnityEngine;
using System.Collections;
using System;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class PlayerShield : MonoBehaviour {

		[SerializeField]
		private GameObject shield;

		[SerializeField]
		private float duration = 1.0f;

		[SerializeField]
		private bool isInvincible;
		public bool IsInvincible {
			get { return isInvincible; }
			private set { isInvincible = value; }
		}

		// Awake.
		
		void Awake() {
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Shows she shield.
		
		public void Show() {
			shield.SetActive( true );
			SetInvincible( true );

			CancelInvoke( "DisableGameObject" );
			Invoke( "DisableShield", duration );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		// Sets invincible and the animation state.
		
		private void SetInvincible( bool value ) {
			isInvincible = value;
		}

		// Disables the shield.
		
		private void DisableShield() {
			SetInvincible( false );
			Invoke( "DisableGameObject", 1.0f );
		}

		// Disables the game object.
		
		private void DisableGameObject() {
			shield.SetActive( false );
		}


	

	}
}