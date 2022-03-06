using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Контроллер врага
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeReference]
    private int damage = 10;
    [SerializeField]
    private int attacksCount = 4;

    private Animator anim;
    private EnemyHealth health;
    private NavMeshAgent agent;
    private WallsController walls;

    private const string MOVE_KEY = "IsMove";
    private const string ATTACK_KEY = "IsAttack";
    private const string DEAD_KEY = "IsDead";
    private const string ATTACK_TREE_KEY = "AttackNumber";

    private float[] attackValues;

    private Transform targetPosition;

    private bool isFinalState = false;

    private const float MIN_SPEED = 0.8f;
    private const float MAX_SPEED = 1.3f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
        walls = FindObjectOfType<WallsController>();

        CreateAttackArray();
    }

    private void OnEnable()
    {
        SetRandomSpeed();

        health.onHealthIsOver += Die;
    }

    private void OnDisable()
    {
        health.onHealthIsOver -= Die;
    }

    private void Update()
    {
        if (health.IsDead)
            return;

        if (!isFinalState && walls.IsDead)
        {
            isFinalState = true;
            targetPosition = walls.FinalPoint;
            agent.stoppingDistance = 0;
            agent.SetDestination(targetPosition.position);
            Move();
        }

        float distance = Vector3.Distance(transform.position, targetPosition.position);

        if (distance <= agent.stoppingDistance && !isFinalState)
        {
            Attack();
            return;
        }
        
        if (distance > agent.stoppingDistance)
        {
            Move();
        }
        else
        {
            Idle();
        }
    }

    private void Idle()
    {
        anim.SetBool(MOVE_KEY, false);
    }

    private void Move()
    {
        anim.SetBool(MOVE_KEY, true);
    }

    private void Attack()
    {
        transform.LookAt(targetPosition);
        anim.SetTrigger(ATTACK_KEY);
        anim.SetBool(MOVE_KEY, false);
    }

    private void Die()
    {
        agent.enabled = false;
        anim.SetBool(MOVE_KEY, false);
        anim.SetTrigger(DEAD_KEY);
    }

    /// <summary>
    /// Установить рандомную анимацию атаки
    /// </summary>
    public void SetRandomAttackAnim()
    {
        walls.Health -= damage;

        int rand = Random.Range(0, attacksCount - 1);
        anim.SetFloat(ATTACK_TREE_KEY, rand);
    }

    private void CreateAttackArray()
    {
        attackValues = new float[attacksCount];

        float step = 1 / (attacksCount - 1);
        float value = 0;

        for (int i = 0; i < attacksCount; i++)
        {
            attackValues[i] = value;
            value += step;
        }
    }

    /// <summary>
    /// Установка пути
    /// </summary>
    public void SetPath()
    {
        agent.enabled = true;
        int rand = Random.Range(0, walls.Points.Count - 1);
        targetPosition = walls.Points[rand];
        agent.SetDestination(targetPosition.position);
    }

    private void SetRandomSpeed()
    {
        anim.speed = Random.Range(MIN_SPEED, MAX_SPEED);
    }
}