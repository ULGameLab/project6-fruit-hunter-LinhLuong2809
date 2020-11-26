using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState{CHASE, MOVING, DEFAULT};

[RequireComponent(typeof(NavMeshAgent))]
public class ChasePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 10.0f;

    protected EnemyState state = EnemyState.DEFAULT;
    protected Vector3 destination = new Vector3(0,0,0);

    AudioSource myaudio;

    public GameObject effectObject;
    ParticleSystem explode;

    bool start = false;
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        myaudio = GetComponent<AudioSource>();
        explode = effectObject.transform.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f));
    }
    void Update()
    {

    // if(Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
    // {
    //     agent.SetDestination(player.transform.position);
    // }

        switch(state)
        {
            case EnemyState.DEFAULT:
                destination = transform.position + RandomPosition();
                if(Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
                {
                    state = EnemyState.CHASE;
                }
                else
                {
                    state = EnemyState.MOVING;
                    agent.SetDestination(destination);
                }
                break;
            case EnemyState.MOVING:
                Debug.Log("Dest = " + destination);
                if (Vector3.Distance(transform.position, destination)< 5)
                {
                    state = EnemyState.DEFAULT;
                }
                if(Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
                {
                    state = EnemyState.CHASE;
                }
                break;
            case EnemyState.CHASE:
                if(Vector3.Distance(transform.position, player.transform.position) > chaseDistance)
                {
                    state = EnemyState.DEFAULT;
                }
                agent.SetDestination(player.transform.position);
                break;
            default:
                break;
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("bullet"))
        {
            
            Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer c in allRenderers) c.enabled = false;
            Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in allColliders) c.enabled = false;
            effectObject.GetComponent<ParticleSystemRenderer>().enabled = true;

            StartExplosion();
            StartCoroutine(PlayAndDestroy(myaudio.clip.length));
            
        }
    }

    private IEnumerator PlayAndDestroy(float waitTime)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    private void StartExplosion()
    {
        if(start == false)
        {
            explode.Play();
            start = true;
        }
    }

    private void StopExplosion()
    {
        start = false;
        explode.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
