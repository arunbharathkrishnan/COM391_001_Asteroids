using UnityEngine;
using System.Collections;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class MoveLinear : MonoBehaviour {

		[SerializeField]
		private float speed = 1.0f;

		// Awake.
		
		void Awake() {
		}

		// Start.
		
		void Start() {

		}

		// Update.
		
		void Update() {
			transform.Translate( transform.up * speed * Time.deltaTime, Space.World );
		}

		
	}
}