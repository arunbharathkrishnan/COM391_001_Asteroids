/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */

using UnityEngine;
using System.Collections;

namespace Asteroids {

	public class FlashColor : MonoBehaviour {

		[SerializeField]
		private Color flashColor = Color.white;

		[SerializeField]
		[Range( 0.0f, 1.0f )]
		private float flashAmount = 1.0f;

		[SerializeField]
		private float duration = 0.5f;

		[SerializeField]
		private SpriteRenderer spriteRenderer;

		private Material material;

	// Awake.
		
		void Awake() {
			if( spriteRenderer == null ) {
				spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			}
			material = spriteRenderer.material;
			material.color = flashColor;
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Flashes the color.
		
		[ContextMenu( "Test Flash" )]
		public void Flash() {
			ChangeColor( flashAmount );
			Invoke( "ResetColor", duration );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

	// Resets the color.
		
		private void ResetColor() {
			ChangeColor( 0.0f );
		}

		// Flashes the color.
		
		private void ChangeColor( float value ) {
			material.SetFloat( "_FlashAmount", value );
		}

	}
}