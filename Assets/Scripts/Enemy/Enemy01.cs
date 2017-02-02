using UnityEngine;
using System.Collections;

public class Enemy01 : MonoBehaviour {

	[Header("Components")]
	[SerializeField] NavMeshAgent navMeshAgent;
	[SerializeField] Animator animator;

	float originalSpeed;

	static WaitForSeconds updateDelay = new WaitForSeconds(.5f);

	public Transform target;
	bool playerInRange;	

	RaycastHit hit;

	void Reset ()
	{
		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void OnEnable()
	{
		Reset();
		navMeshAgent.enabled = true;
		StartCoroutine("ChasePlayer");
	}

	IEnumerator ChasePlayer ()
	{
		yield return null;

		while (navMeshAgent.enabled)
		{
			if (playerInRange)
			if (target != null) {
				navMeshAgent.SetDestination (target.position);
				if(Physics.Raycast(transform.position, target.position-transform.position, out hit ) ){
					if (hit.distance < 2.1f &&(hit.collider != null) ) {
						if( hit.collider.transform == target ){
							Vector3 force = hit.normal;
							force.y = -0.4f;
                            
							target.gameObject.GetComponent<CharacterMoveController>().ReceiveForce(force*(-2.6f));
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
