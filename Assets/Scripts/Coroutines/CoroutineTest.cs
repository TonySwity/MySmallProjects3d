using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField]private Transform[] _path;
    
    private Vector3 _destination;
    private float _speed = 8f;
    private IEnumerator _move;

    private void Start()
    {
        string[] messages = {"Welcome", "to", "this", "amazing", "game"};
        float delay = 1f;
        StartCoroutine(PrintMessages(messages, delay));
        StartCoroutine(FollowPath());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_move != null)
            {
                StopCoroutine(_move);
            }
            
            _speed = Random.Range(2, 15f);
            _destination = Random.onUnitSphere * 5;
            _move = Move(_destination, _speed);
            StartCoroutine(_move);
        }
    }

    private IEnumerator PrintMessages(string[] messages, float delay)
    {
        foreach (var message in messages)
        {
            print(message);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FollowPath()
    {
        foreach (var wayPoint in _path)
        {
            yield return StartCoroutine(Move(wayPoint.position, _speed));
        }
    }
}