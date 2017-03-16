using UnityEngine;
using System.Collections;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class WrapScreen : TransformOffscreen {

		// Update. Check if transform is outside the offscreen positions and if so move to the opposite.
		
		public override void Update() {
			base.Update();

			// if IsOffscreen, convert viewport pos back to world pos and apply to transform.
			if( isOffscreen ) {
				transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
			}
		}

	}
}