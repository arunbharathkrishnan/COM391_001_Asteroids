using UnityEngine;
using System.Collections;
using System;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class Health : MonoBehaviour {

		public event Action<int> EventHeathChange;

		[SerializeField]
		private int health = 1;
		public int Value {
			get { return health; }
			private set { health = value; }
		}

    // Awake.
		
		void Awake() {

		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Increases the health.
		
		public void IncreaseHealth( int value ) {
			Value += value;
			DispatchChangedEvent();
		}

		// Reduces the health.
		
		public void ReduceHealth( int value ) {
			Value -= value;
			DispatchChangedEvent();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================
        // Dispatches the changed event.
		
		private void DispatchChangedEvent() {
			if( EventHeathChange != null ) {
				EventHeathChange( Value );
			}
		}

	
	}
}