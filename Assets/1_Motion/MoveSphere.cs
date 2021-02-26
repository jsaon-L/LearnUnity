using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 控制移动
/// </summary>
public class MoveSphere : MonoBehaviour
{

    [SerializeField]
    [Range(0, 100)]
    float speed = 10;

    [SerializeField]
    [Range(0, 100)]
    float maxAcceleration = 10;

    //移动速度
    Vector3 velocity;
    void Update()
    {
        //原始输入
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        //保持 向量大小不会超过1 (根据勾股定理如果上面两个按键同时按下 向量大小为根号2)
        playerInput = Vector2.ClampMagnitude(playerInput, 1);

        //目标速度
        Vector3 desiredVelocity = new Vector3(playerInput.x, 0, playerInput.y) * speed;
        //加速度
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        //使 velocity这个当前速度 以maxSpeedChange的速度趋近于 desiredVelocity
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        Vector3 displacement = velocity * Time.deltaTime;

        transform.localPosition += displacement;

    }
}
