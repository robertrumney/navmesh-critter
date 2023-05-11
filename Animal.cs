using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour 
{
    public float wanderRadius;
    public float wanderTimer;
    
    public Animator animator;

    public Collider liveCollider;
    public Collider deadCollider;

    public AudioClip sound;
    public GameObject disable;
    public GameObject chest;

    private NavMeshAgent agent;
    private bool scared;
    private float timer;
    private bool dead = false;
    

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigid in rigids)
        {
            rigid.isKinematic = true;
            rigid.tag = "HerdChild";
        }
    }

    private void Update()
    {
        Wander();

        if (scared)
        {
            animator.speed = agent.desiredVelocity.magnitude / 3;
        }
        else
        {
            animator.speed = agent.desiredVelocity.magnitude;
        }
    }
    
    private void AlertCallback()
    {
        Scare();
    }

    private void ApplyDamage()
    {
        if (!dead) 
        {
            Die();
            dead = true;
        }
    }

    private void Scare()
    {
        if (!scared)
        {
            if (!dead)
            {
                animator.SetTrigger("scare");
                AudioSource.PlayClipAtPoint(sound, transform.position, 0.4f);
                agent.speed = 5;
            }
            scared = true;
        }
    }

    private void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    private void Die()
    {
        GameProgress.instance.HuntGoat();

        Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();

        float forceMagnitude = 1;
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 force = cameraForward * forceMagnitude;

        foreach (Rigidbody rigid in rigids)
        {
            rigid.isKinematic = false;
            rigid.mass = 1;
            rigid.AddForce(force, ForceMode.Impulse);
        }

        enabled = false;
        agent.isStopped = true;
        
        if (disable)
            disable.SetActive(false);

        gameObject.AddComponent<ImproveRagdoll>();
    }

    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
