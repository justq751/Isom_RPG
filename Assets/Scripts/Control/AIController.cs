using System.Collections;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (InAttackRange() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private bool InAttackRange()
        {
            if (player == null) return false;

            return Vector3.Distance(player.transform.position, transform.position) < chaseDistance;
        }
    }
}