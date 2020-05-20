using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //[SerializeField] private int speed;
    [System.Serializable] public class TargetDestroyed : UnityEvent<int> { }
    public TargetDestroyed targetDestroyed;

    public UnityEvent gameOverEvent;

    [System.Serializable] public class StartGameEvent : UnityEvent<int> { }
    public StartGameEvent startGameEvent;
}
