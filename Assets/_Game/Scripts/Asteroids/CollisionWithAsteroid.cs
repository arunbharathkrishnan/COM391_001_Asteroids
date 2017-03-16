using UnityEngine;
using System.Collections;
using System;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class CollisionWithAsteroid : MonoBehaviour {

		public event Action<Asteroid> EventCollision;

		// Awake.
		
		void Awake() {

		}


		// Called when colliders interact.
		
		void OnTriggerEnter2D( Collider2D collider ) {
			// convert tag to lowercase for less errors.
			string tag = collider.tag.ToLower();

			// check collision against lasers and ship. Dispatch event if collision.
			if( tag == Tags.Asteroid ) {
				Asteroid asteroid = collider.gameObject.GetComponentInParent<Asteroid>();

				// disptach event.
				if( EventCollision != null ) {
					EventCollision( asteroid );
				}
			}
		}

		

	}
}