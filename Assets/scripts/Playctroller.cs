using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//使用NavMeshAgent

public class Playctroller : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

     void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //添加订阅 保证函数方式的命名方式和定义方式要跟 事件 public event Action<Vector3> OnMouseClicked 保持一致 
        //事件的添加注册或者叫添加订阅的方法 使用关键字的符号"+="
        Mouse_Manager.Instance.OnMouseClicked += MoveToTarget;
    }
    //保持一致所以函数要保证有Vector3

    void Update()
    {
        SwitchAnimator();
    }

    private void SwitchAnimator()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);//向量转float型
    }
    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
