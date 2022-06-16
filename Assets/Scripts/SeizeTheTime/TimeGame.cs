using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TimeGame : MonoBehaviour
{
    private float _roundStartTime;
    private int _waitTime;
    private float _roundStartDelay = 2f;
    private bool _roundStarted;
    private void Start()
    {
        print("Нажмите на <<пробел>> если вы считаете, что отведенное время вышло!!!");
        Invoke(nameof(SetNewRandomTime), _roundStartDelay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _roundStarted)
        {
            InputReceived();
        }
    }

    private void InputReceived()
    {
        _roundStarted = false;
        float playerWaitTime = Time.time - _roundStartTime;
        float error = Mathf.Abs(_waitTime - playerWaitTime);

        string message = "";

        if (error < 1f)
        {
            message = "Вау, да ты везунчик!!!";
        }
        else
        {
            message = "Повезет в следующий раз!!";
        }

        print(message);
        print($"Ваше время ожидания {playerWaitTime} секунд. Время ошибки  {error} секунд!!!");
        Invoke(nameof(SetNewRandomTime), _roundStartDelay); 
    }
    private void SetNewRandomTime()
    {
        _waitTime = Random.Range(5, 21);
        _roundStartTime = Time.time;
        _roundStarted = true;
        print($"{_waitTime} время ожидания!");
    }
}