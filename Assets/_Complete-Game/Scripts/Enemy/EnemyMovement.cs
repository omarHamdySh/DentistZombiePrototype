using UnityEngine;
using System.Collections;
//Deprecated
namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        //perepare for multi distination
        GameObject[] players;               // Reference to the player's position.

        //Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
        int targetIndex;
        public LayerMask layerMask;
        void Awake()
        {

            // Set up the references.
            players = GameObject.FindGameObjectsWithTag("Player");
            print(players.Length);
            targetIndex = Random.Range(0, players.Length);
            playerHealth = players[targetIndex].GetComponentInChildren<PlayerHealth>();

            //player = GameObject.FindGameObjectWithTag("Player").transform;
            //playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }


        void Update()
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                //seting this for multi distination

                nav.SetDestination(players[targetIndex].transform.position);
               // nav.SetDestination(player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
        //private void OnCollisionStay(Collision collision)
        //{
        //    if (collision.gameObject.tag=="Floor") {


        //    }
        //}
        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Floor")
        //    {


        //    }
        //}

    }

   
}