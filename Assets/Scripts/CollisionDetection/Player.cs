using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    private Rigidbody _myRigidbody;
    private Vector3 _velocity;
    private int _coinCount;

    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        _velocity = direction * _speed;
    }

    private void FixedUpdate()
    {
        _myRigidbody.position += _velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
            
            _coinCount++;
        }
    }
}