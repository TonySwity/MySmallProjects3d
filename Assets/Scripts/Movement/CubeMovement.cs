using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private float _speed = 10f;
    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * _speed;
        Vector3 moveAmount = velocity * Time.deltaTime;

        //transform.position += moveAmount;
        transform.Translate(moveAmount);
        
    }
}
