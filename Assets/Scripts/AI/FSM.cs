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
    public GameObject GasBottlePrefab;
    public int health;
    public float moveSpeed;//巡逻速度
    public float chaseSpeed;//追踪速度
    public float idleTime;//巡逻到某点后观察时间
    public Transform[] patrolPoints;//巡逻点
    public Transform[] chasePoints;//追击限制点
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;//攻击检测圆点
    public float attackArea;//攻击范围
    public Animator animator;
    public bool getHit;//判断是否受击
    public bool Lock = false;
}
public class FSM : MonoBehaviour
{

    protected IState currentState;//当前状态：Onenter, OnUpdate, OnExit

    protected Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    public Parameter parameter;//在别的类方便获取ai的全部参数
    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));//构造函数参数为FMS类实例
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
        currentState.OnUpdate();//必须在Update内执行

        if (Input.GetKeyDown(KeyCode.Return))//受击，应重写
        {                                    //
            parameter.getHit = true;
        }
    }

    public void TransitionState(StateType type)//状态转移目标为type
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)//更改ai朝向
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

    protected void OnTriggerStay2D(Collider2D other)//检查发现敌人范围
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
        parameter.Lock = true;
    }
    

    protected void OnTriggerExit2D(Collider2D other)//目标消失在范围内
    {
        parameter.Lock = false;
        if (other.CompareTag("Player"))
        {
            Invoke("delaylose", 1.5f);
        }
        
    }
    void delaylose()
    {
        if(!parameter.Lock)
        parameter.target = null;
    }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
}
