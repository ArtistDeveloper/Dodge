using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start()
    {
        //public T GetComponent<T>(); 모양으로 되어 있음. 즉 GetComponet<Rigidbody)의 return type은 Rigidbody 
        //"서브클래스 = 슈퍼클래스"의 형태인줄알고 제일 처음에는 의아했는데, 제네릭 때문에 가능한거구나.
        playerRigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal"); // Return : (수평) 오른쪽 +1, 왼쪽 -1 
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        
        // ex) 우측입력 예시 xInput(+1.0) * speed(8f);
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed); 
        playerRigidbody.velocity = newVelocity;
    }

    public void Die() 
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
