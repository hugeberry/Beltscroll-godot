using UnityEngine;

public class BreathAttak : MonoBehaviour
{
    private float coolTime = 1;

    private void Update()
    {
        coolTime += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if(coolTime > 0.5f)
            if (other.tag == "Player" || other.tag == "Enemy")
                Attack();
    }

    private void Attack()
    {
        Collider[] coll = Physics.OverlapBox(transform.position,GetComponent<BoxCollider>().size);
        foreach(Collider c in coll)
        {
            if (c.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if (c.GetComponent<IsSafe>().isSafe == false)
                    c.GetComponent<PlayerMovement>().TakeDamage(20, "");
            }
            else if (c.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (c.GetComponent<IsSafe>().isSafe == false)
                    c.GetComponent<MonsterFSM>().TakeDamage(20, false);
            }
        }
        coolTime = 0;
    }
}
