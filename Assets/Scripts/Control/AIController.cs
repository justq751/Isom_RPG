using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspitionTime = 5f;

        Fighter fighter;
        Mover mover;
        GameObject player;
        Health health;

        Vector3 guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();

            guardPosition = transform.position;

            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (health.IsDead()) return;

            if (InAttackRange() && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < suspitionTime)
            {
                SuspitionBehaviour();
            }
            else
            {
                GuardBehaviour();
            }
            timeSinceLastSawPlayer += Time.deltaTime;
        }

        private void AttackBehaviour()
        {
            fighter.Attack(player);
        }

        private void SuspitionBehaviour()
        {
            GetComponent<ActionScheduler>().CanceCurrentAction();
        }

        private void GuardBehaviour()
        {
            mover.StartMoveAction(guardPosition);
        }

        private bool InAttackRange()
        {
            if (player == null) return false;

            return Vector3.Distance(player.transform.position, transform.position) < chaseDistance;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}