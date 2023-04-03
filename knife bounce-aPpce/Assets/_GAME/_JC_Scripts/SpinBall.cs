using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBall : MonoBehaviour
{
    public BallSpinScript ball;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Knife"))
        {
            Destroy(other.gameObject);
            ball.isOver = true;
        }
    }
}
