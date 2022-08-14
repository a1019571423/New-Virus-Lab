using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Patrol, Chase, React, Attack, Hit, Death
}

[Serializable]
public class Parameter
{
    public int health;
    public float moveSpeed;//Ѳ���ٶ�
    public float chaseSpeed;//׷���ٶ�
    public float idleTime;//Ѳ�ߵ�ĳ���۲�ʱ��
    public Transform[] patrolPoints;//Ѳ�ߵ�
    public Transform[] chasePoints;//׷�����Ƶ�
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;//�������Բ��
    public float attackArea;//������Χ
    public Animator animator;
    public bool getHit;//�ж��Ƿ��ܻ�
}
public class FSM : MonoBehaviour
{

    private IState currentState;//��ǰ״̬��Onenter, OnUpdate, OnExit

    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    public Parameter parameter;//�ڱ���෽���ȡai��ȫ������
    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));//���캯������ΪFMS��ʵ��
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Death, new DeathState(this));

        TransitionState(StateType.Idle);

        parameter.animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        currentState.OnUpdate();//������Update��ִ��

        if (Input.GetKeyDown(KeyCode.Return))//�ܻ���Ӧ��д
        {                                    //
            parameter.getHit = true;
        }
    }

    public void TransitionState(StateType type)//״̬ת��Ŀ��Ϊtype
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)//����ai����
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-0.2f, 0.2f, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(0.2f, 0.2f, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//��鷢�ֵ��˷�Χ
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)//Ŀ����ʧ�ڷ�Χ��
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
}
