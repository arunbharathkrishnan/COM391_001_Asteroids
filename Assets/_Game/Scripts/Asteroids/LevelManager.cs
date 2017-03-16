using UnityEngine;
using System.Collections;
using System;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class LevelManager : MonoBehaviour {

		public event Action<int> EventPoints;
		public event Action EventPlayerDied;
		public event Action EventStarted;

		[SerializeField]
		private int level;
		public int Level {
			get { return level; }
			private set { level = value; }
		}

		[SerializeField]
		private AsteroidSpawner asteroidSpawner;

		[SerializeField]
		private Player player;

		[SerializeField]
		private float startLevelDelay = 3.0f;

		// Awake.
		
		void Awake() {
			asteroidSpawner.EventAsteroidDestroyed += OnAsteroidDestroyed;
			player.EventDied += OnPlayerDied;
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Resets this instance.
		
		public void Reset() {
			level = 1;
			asteroidSpawner.Reset();
		}

		// Starts the level.
		
		public void StartLevel() {
			asteroidSpawner.Spawn( level );
			if( EventStarted != null ) {
				EventStarted();
			}
		}

		// Spawns the player.
		
		public void SpawnPlayer() {
			player.Spawn();
		}

		// Called when [asteroid destroyed].
		
		private void OnAsteroidDestroyed( int points ) {
			// add to score.
			if( EventPoints != null ) {
				EventPoints( points );
			}

			// check if there are any asteroids remaining
			if( asteroidSpawner.AsteroidsRemaining == 0 ) {
				level += 1;
				Invoke( "StartLevel", startLevelDelay );
			}
		}

		// Called when [player died].
		
		private void OnPlayerDied() {
			if( EventPlayerDied != null ) {
				EventPlayerDied();
			}
		}


	}
}