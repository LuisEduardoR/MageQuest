using UnityEngine;
using System.Collections;

using MageQuest.Player;

namespace MageQuest.Enemies
{

	public enum EnemyType { Normal, Fire, Ice, Lightning, Arcane, Darkness }

	[RequireComponent(typeof(Rigidbody))]
	public class BaseEnemy : MonoBehaviour {
		
		public EnemyType enemyType = EnemyType.Normal;

		protected Transform player;

		[SerializeField] protected float velocity = 7;
		
		[SerializeField] protected int playerDamage = 10;

		[SerializeField] protected float minDistanceToFollow = 1.0f;
		[SerializeField] protected float maxDistanceToFollow = 65.0f;

		[SerializeField] protected GameObject deathObject = null;

		void Start() 
		{
			
			player = GameObject.FindGameObjectWithTag("Player").transform;
			
		}

		void Update () 
		{
			
			float distanceToPlayer = Vector3.Distance(transform.position, player.position);
			if(distanceToPlayer > minDistanceToFollow && distanceToPlayer < maxDistanceToFollow)
			{
				FollowPlayer();
			}

		}

		void FollowPlayer () 
		{

			Vector3 dir = (player.position - transform.position).normalized;
			transform.position = transform.position + dir * Time.deltaTime * velocity;

			Quaternion lookTo = Quaternion.LookRotation(dir);
			transform.rotation = lookTo;

		}

		void OnCollisionEnter(Collision collision)
		{
			
			if(collision.collider.tag == "Player")
			{
				PlayerScript player = collision.collider.GetComponent<PlayerScript>();
				if(player != null)
				{
					player.Damage(playerDamage);
				}
				return;
			}

			if(collision.collider.tag == "Fire" || collision.collider.tag == "Ice" || collision.collider.tag == "Lightning" || collision.collider.tag == "Arcan")

			switch(enemyType)
			{
				case EnemyType.Fire:

					if(collision.collider.tag == "Fire")
					{
						return;
					}

					Die();

					break;
				case EnemyType.Ice:

					if(collision.collider.tag == "Ice")
					{
						return;
					}

					Die();

					break;
				case EnemyType.Lightning:

					if(collision.collider.tag == "Lightning")
					{
						return;
					}

					Die();

					break;
				case EnemyType.Arcane:

					if(collision.collider.tag == "Arcan")
					{
						return;
					}

					Die();

					break;
				case EnemyType.Darkness:

					if(collision.collider.tag != "Arcan")
					{
						return;
					}

					Die();

					break;

				default:

					Die();

					break;

			}

		}

		protected void Die() 
		{
			if(deathObject != null)
			{
				Instantiate(deathObject, transform.position, transform.rotation);
			}
			Destroy(gameObject);

		}

	}

}