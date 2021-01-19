using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed; //forward는 앞쪽(z축방향)을 나타내는 Vector3 타입 변수이다..

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null) 
            {
                playerController.Die();
            }
        }
    }
}
