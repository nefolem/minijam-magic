using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints = new();
    [SerializeField] private float _searchRadius = 10f;
    private Vector2 destination;
    private NavMeshAgent _enemyAgent;
    private bool _isPatroling = true;
    private int _currentPatrolIndex;
    private Transform _target;
    
    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _enemyAgent.updateRotation = false;
        _enemyAgent.updateUpAxis = false;
        destination = new Vector2(_patrolPoints[Random.Range(0, _patrolPoints.Count)].position.x, _patrolPoints[Random.Range(0, _patrolPoints.Count)].position.y);
        SetDestination(destination);
    }

    
    void Update()
    {
        if (_isPatroling)
        {
            int randomIndex = Random.Range(0, _patrolPoints.Count);

            if (_enemyAgent.remainingDistance < 0.5f && randomIndex != _currentPatrolIndex)
            {
                destination = new Vector2(_patrolPoints[randomIndex].position.x, _patrolPoints[randomIndex].position.y);
                _currentPatrolIndex = randomIndex;

                SetDestination(destination);
            }
            TryFindPlayer();
        }
        else
        {
            if (_target != null && _enemyAgent.remainingDistance < _searchRadius)
            {
                SetDestination(_target.position);                
            }
            else
            {
                _target = null;
                _isPatroling = true;
            }
        }
    }

    public void SetDestination(Vector2 target)
    {

        _enemyAgent.SetDestination(target);
    }

    private void TryFindPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _searchRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<PlayerMovement>())
            {               
                _target = collider.transform;
                //print(_target);
                _isPatroling = false;
                break;
            }
            else _isPatroling = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {
            HealthController.Instance.GetDamaged();
            Debug.Log("stay");
        }
    }

   
}
