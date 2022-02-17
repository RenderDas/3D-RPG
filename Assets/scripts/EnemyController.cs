using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { GUARD,PATROL,CHASE,DEAD}

[RequireComponent(typeof(NavMeshAgent))]//�Զ�������component
//����Ӧ���ںܶ���������ϵ�ʱ��ȷ��ÿһ��������Ӧ�����
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public EnemyStates enemystates;//����������Inspector������ѡ������״̬
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
