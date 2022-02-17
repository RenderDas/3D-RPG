using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { GUARD,PATROL,CHASE,DEAD}

[RequireComponent(typeof(NavMeshAgent))]//自动添加组件component
//代码应用在很多物体的身上的时候确保每一个都有相应的组件
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public EnemyStates enemystates;//这样可以在Inspector窗口中选择怪物的状态
     void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
    }
     void Update()
    {
        SwitchStates();
    }
    void SwitchStates()
    {
        switch(enemystates)
        {
            case EnemyStates.GUARD:
                break;
            case EnemyStates.PATROL:
                break;
            case EnemyStates.CHASE:
                break;
            case EnemyStates.DEAD:
                break; 
        }    
    }
}
