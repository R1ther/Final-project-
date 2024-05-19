using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_AI : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int _moveeSpeed;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        
    }
}
