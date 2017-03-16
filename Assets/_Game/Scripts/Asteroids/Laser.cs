using UnityEngine;
using System.Collections;
/*
 * Author : Arun Bharath Krishnan
 * Student ID : 300902831
 * */
namespace Asteroids {

	[RequireComponent( typeof( CollisionWithAsteroid ) )]
	[RequireComponent( typeof( DestroyWeaponOffscreen ) )]
	public class Laser : MonoBehaviour {

		private CollisionWithAsteroid collision;

		private DestroyWeaponOffscreen destroyOffscreen;
		private ObjectPool weaponPool;
		private int damage;

		// Awake.
		
		void Awake() {
			destroyOffscreen = GetComponent<DestroyWeaponOffscreen>();
			destroyOffscreen.EventDestroy += OnEventDestroy;

			collision = GetComponent<CollisionWithAsteroid>();
			collision.EventCollision += OnCollisionWithAsteroid;
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		// Passes in the weaponPool
		
		public void Init( ObjectPool pool, int damageValue ) {
			weaponPool = pool;
			damage = damageValue;
		}

		// Called when [event destroy] fired. If weaponpool, return it, else destroys it manually.
		
		private void OnEventDestroy() {
			if( weaponPool ) {
				weaponPool.ReleaseObject( gameObject );
			} else {
				Destroy( gameObject );
			}
		}

		// Called when [collision with asteroid].
		
		private void OnCollisionWithAsteroid( Asteroid asteroid ) {
			asteroid.Collision( damage );
			OnEventDestroy();
		}
	}

}