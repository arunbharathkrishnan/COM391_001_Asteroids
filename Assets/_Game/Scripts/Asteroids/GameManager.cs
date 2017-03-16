using UnityEngine;
using System.Collections;
using Asteroids.UI;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class GameManager : MonoBehaviour {
		private static GameManager instance;
		public static GameManager Instance {
			get { return instance; }
		}

		[SerializeField]
		private UIManager uiManager;

		[SerializeField]
		private LevelManager levelManager;

		[SerializeField]
		private GameObject gameHolder;

		[SerializeField]
		private int startingLives = 3;

		public int Lives {
			get;
			private set;
		}

		public int Points {
			get;
			private set;
		}

		public int Level {
			get { return levelManager.Level; }
		}

        // Awake.
		
		void Awake() {
			# region - Singleton
			if( instance == null ) {
				instance = this;
			} else if( instance != this ) {
				Destroy( gameObject );
			}
			DontDestroyOnLoad( gameObject );
			# endregion

			gameHolder.SetActive( false );

			levelManager.EventPoints += OnLevelPoints;
			levelManager.EventPlayerDied += OnLevelLives;
			levelManager.EventStarted += OnLevelStarted;
		}

        // Start.
		
		void Start() {
			uiManager.ShowTitleScreen( true );
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Starts the game.
		
		public void StartGame() {
			gameHolder.SetActive( true );

			ResetGame();
			levelManager.StartLevel();
			levelManager.SpawnPlayer();
		}

		// Resets the game.
		
		public void ResetGame() {
			Points = 0;
			Lives = startingLives;
			levelManager.Reset();

			uiManager.UpdateLives( Lives );
			uiManager.UpdatePoints( Points );
		}

		// Called when [level points].
		
		private void OnLevelPoints( int points ) {
			Points += points;
			uiManager.UpdatePoints( Points );
		}

		// Called when [level lives].
		
		private void OnLevelLives() {
			Lives -= 1;
			if( Lives >= 0 ) {
				uiManager.UpdateLives( Lives );
				levelManager.SpawnPlayer();
			} else {
				uiManager.ShowScoreScreen();
			}
		}

		// Called when [level started].
		
		private void OnLevelStarted() {
			uiManager.ShowLevelStart();
		}
	}
}