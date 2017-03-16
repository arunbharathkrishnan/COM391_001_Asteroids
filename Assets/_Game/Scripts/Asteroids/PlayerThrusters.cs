using UnityEngine;
using System.Collections;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class PlayerThrusters : MonoBehaviour {

		[SerializeField]
		private Animator thrusterMain;

		[SerializeField]
		private Animator thrusterLeft;

		[SerializeField]
		private Animator thrusterRight;

		//===================================================
		// UNITY METHODS
		//===================================================

		// Awake.
		
		void Awake() {
		}

		// Update.
		
		void Update() {
			float inputX = Input.GetAxis( "Horizontal" );
			float inputY = Mathf.Clamp( Input.GetAxis( "Vertical" ), 0, 1 );

			if( inputX < 0 ) {
				thrusterLeft.SetBool( "Thrust", false );
				thrusterRight.SetBool( "Thrust", true );
			} else if( inputX > 0 ) {
				thrusterLeft.SetBool( "Thrust", true );
				thrusterRight.SetBool( "Thrust", false );
			} else {
				thrusterLeft.SetBool( "Thrust", false );
				thrusterRight.SetBool( "Thrust", false );
			}

			if( inputY > 0 ) {
				thrusterMain.SetBool( "Thrust", true );
			} else {
				thrusterMain.SetBool( "Thrust", false );
			}
		}

	}
}