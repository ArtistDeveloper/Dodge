using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;

    // Update is called once per frame
    void Update()
    {
        //1초에 60번 update메소드가 실행된다고 가정하면
        //ex) 60도 * 1/60 = 1도 : 매프레임마다 1도씩 움직임 
        // Time.deltaTime은 초당 프레임의 역수를 취한 값이다.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
