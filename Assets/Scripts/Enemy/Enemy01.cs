using UnityEngine;
using System.Collections;

public class Enemy01 : MonoBehaviour {

	[Header("Components")]
	[SerializeField] NavMeshAgent navMeshAgent; 					//Reference to the navmesh agent component
	[SerializeField] Animator animator;

	float originalSpeed;											//Original movement speed of the enemy (in case they get frozen)

	static WaitForSeconds updateDelay = new WaitForSeconds(.5f);

	public Transform target;
	bool playerInRange;	

	RaycastHit hit;

	void Reset ()
	{
		//Grab references to the needed components
		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	//When this game object is enabled...
	void OnEnable()
	{
		//Enabled the nav mesh agent
		Reset();
		navMeshAgent.enabled = true;
		//Start the ChasePlayer coroutine
		StartCoroutine("ChasePlayer");
	}

	//This coroutine updates the navmesh agent to chase the player
	IEnumerator ChasePlayer ()
	{
		yield return null;

		while (navMeshAgent.enabled)
		{
			if (playerInRange)
			if (target != null) {
				navMeshAgent.SetDestination (target.position);
				if(Physics.Raycast(transform.position, target.position-transform.position, out hit ) ){
					//Debug.Log (hit.collider.name);
					if (hit.distance < 2.0f &&(hit.collider != null) ) {
						if( hit.collider.transform == target ){
							CharacterMoveController cmc = target.gameObject.GetComponent<CharacterMoveController> ();
							cmc.ReceiveForce(hit.normal*(-2.8f));
						}
					}

				}
			}
			//...finally, wait a time interval before looping
			yield return updateDelay;
		}
	}

	//Called when the enemy is defeated and can no longer move
	public void Defeated()
	{
		navMeshAgent.enabled = false;
	}




	void OnTriggerEnter (Collider other)
	{
		if(other.transform == target)
		{
			//Record that the player is in range
			playerInRange = true;
		}
	}

	//When the player leaves the trigger collider this is called
	void OnTriggerExit (Collider other)
	{
		//If the game object leaving this collider
		//is the Player value of the GameManager (it's the player)...
		if(other.transform == true)
		{
			//Record that the player is not in range
			playerInRange = false;
		}
	}




}
	