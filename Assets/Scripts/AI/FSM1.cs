    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parameter1 : Parameter
{
    
}
public class FSM1 : FSM
{
    //private IState currentState;//��ǰ״̬��Onenter, OnUpdate, OnExit

    //new public Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

   // public Parameter1 parameter;//�ڱ���෽���ȡai��ȫ������
    void  Start()
    {
        states.Clear();
        states.Add(StateType.Idle, new Idle1State(this));//���캯������ΪFMS��ʵ��
        states.Add(StateType.Patrol, new Patrol1State(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new Attack1State(this));
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
    public void castGasBottol()
    {
        GameObject go =  Instantiate(parameter.GasBottlePrefab, transform.position, Quaternion.identity);
        Parabola p = go.GetComponent<Parabola>();
        p.pointA = parameter.attackPoint.transform;
        if (parameter.target)
            p.pointB = parameter.target.transform;
        else p.pointB = p.pointA;
    }
    public void delay()
    {
        Invoke("castGasBottol", 1);
    }

}

