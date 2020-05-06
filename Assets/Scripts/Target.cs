using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
