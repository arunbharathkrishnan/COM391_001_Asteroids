using UnityEngine;
using System.Collections;
using System;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	public class DestroyWeaponOffscreen : TransformOffscreen {

		public event Action EventDestroy;

		// Update.
		
		public override void Update() {
			base.Update();

			// if IsOffscreen, dispatch or manually destroy.
			if( isOffscreen ) {
				if( EventDestroy != null ) {
					EventDestroy();
				} else {
					Destroy( gameObject );
				}
			}
		}

	}
}