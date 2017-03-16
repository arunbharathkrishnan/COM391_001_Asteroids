using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class AsteroidSpawner : MonoBehaviour {

		public event System.Action<int> EventAsteroidDestroyed;

		public int AsteroidsRemaining {
			get { return asteroids.Count; }
		}

		[SerializeField]
		private GameObject asteroidPrefab;

		[SerializeField]
		private float offscreenPadding;

		[SerializeField]
		private int startingAsteroidCount = 1;

		private List<Asteroid> asteroids;

	// Awake.
		
		void Awake() {
			Reset();
		}

	// Spawns the number of asteroids based upon the level.
		
		public void Spawn( int level ) {
			int numAsteroids = startingAsteroidCount + level;
			for( int i = 0; i < numAsteroids; i++ ) {
				CreateAsteroid( asteroidPrefab, GetOffScreenPosition(), GetOffScreenRotation() );
			}
		}

		// Resets this instance.
		
		public void Reset() {
			if( asteroids != null ) {
				for( int i = 0; i < asteroids.Count; i++ ) {
					Destroy( asteroids[ i ].gameObject );
				}
			}
			asteroids = new List<Asteroid>();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		// Gets the off screen position.
		
		private Vector3 GetOffScreenPosition() {
			float posX = 0.0f;
			float posY = 0.0f;
			int startingSide = Random.Range( 0, 4 );
			switch( startingSide ) {
				// top
				case 0:
					posX = Random.value;
					posY = 0.0f;
					posY -= offscreenPadding;
					break;
				// bottom
				case 1:
					posX = Random.value;
					posY = 1.0f;
					posY += offscreenPadding;
					break;
				// left
				case 2:
					posX = 0.0f;
					posY = Random.value;
					posX -= offscreenPadding;
					break;
				// right
				case 3:
					posX = 1.0f;
					posY = Random.value;
					posX += offscreenPadding;
					break;
			}
			return Camera.main.ViewportToWorldPoint( new Vector3( posX, posY, 1.0f ) );
		}

		// Returns a diagonal rotation for the starting asteroids.
		
		private Quaternion GetOffScreenRotation() {
			int angle = 0;
			int startingSide = Random.Range( 0, 4 );
			switch( startingSide ) {
				case 0:
					angle = Random.Range( 20, 70 );
					break;
				case 1:
					angle = -Random.Range( 20, 70 );
					break;
				case 2:
					angle = Random.Range( 110, 160 );
					break;
				case 3:
					angle = -Random.Range( 110, 160 );
					break;
			}
			return Quaternion.Euler( new Vector3( 0.0f, 0.0f, angle ) );
		}

		// Creates the asteroid.
		
		private Asteroid CreateAsteroid( GameObject prefab, Vector3 position, Quaternion rotation ) {
			GameObject asteroidGO = Instantiate( prefab, position, rotation ) as GameObject;
			asteroidGO.transform.SetParent( gameObject.transform );

			Asteroid asteroid = asteroidGO.GetComponent<Asteroid>();
			asteroid.EventDie += OnAsteroidDie;

			asteroids.Add( asteroid );
			return asteroid;
		}

		// <summary>
		
		private void OnAsteroidDie( Asteroid asteroid, int points, Vector3 position, GameObject[] childAsteroids ) {
			asteroids.Remove( asteroid );

			// create children asteroids
			for( int i = 0; i < childAsteroids.Length; i++ ) {
				Quaternion rotation = Quaternion.Euler( new Vector3( 0.0f, 0.0f, Mathf.Floor( Random.Range( 0.0f, 360.0f ) ) ) );
				CreateAsteroid( childAsteroids[ i ], position, rotation );
			}

			// dispatch event
			if( EventAsteroidDestroyed != null ) {
				EventAsteroidDestroyed( points );
			}
		}


	}
}