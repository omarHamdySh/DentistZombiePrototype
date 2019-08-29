using UnityEngine;
using System.Collections;
//Deprecated
namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        //perepare for multi distination
        GameObject[] player;               // Reference to the player's position.

        //Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
        int idAttack;

        void Awake()
        {

            // Set up the references.
            player = GameObject.FindGameObjectsWithTag("Teeth");
            idAttack = Random.Range(0, player.Length);
            playerHealth = player[idAttack].GetComponent<PlayerHealth>();
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
                nav.SetDestination(player[idAttack].transform.position);
               // nav.SetDestination(player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}