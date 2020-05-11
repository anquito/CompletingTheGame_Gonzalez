using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    //private GameManager gameManager;
    private EventManager eventManager;
    [SerializeField] private ParticleSystem expParticle;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        targetRb = GetComponent<Rigidbody>();

        //randomly select launch location
        transform.position = new Vector3(Random.Range(-5, 5), -5);

        //randomly select upward force
        targetRb.AddForce(Vector3.up * Random.Range(14, 19), ForceMode.Impulse);

        //randomly select spin force
        targetRb.AddTorque(Random.Range(-5, 5), Random.Range(-5, 5),
            Random.Range(-5, 5), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(expParticle, transform.position, expParticle.transform.rotation);
        Destroy(gameObject);
        if(CompareTag("Bad Target"))
        {
            //gameManager.UpdateScore(-10);
            //if(eventManager.TargetDestroyed != null)
            //{
            //    eventManager.TargetDestroyed.Invoke();
            //}
            eventManager.targetDestroyed?.Invoke(-10);
        }
        else if(CompareTag("Good Target"))
        {
            //gameManager.UpdateScore(10);
            eventManager.targetDestroyed?.Invoke(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
