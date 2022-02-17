using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//ʹ��NavMeshAgent

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
        //��Ӷ��� ��֤������ʽ��������ʽ�Ͷ��巽ʽҪ�� �¼� public event Action<Vector3> OnMouseClicked ����һ�� 
        //�¼������ע����߽���Ӷ��ĵķ��� ʹ�ùؼ��ֵķ���"+="
        Mouse_Manager.Instance.OnMouseClicked += MoveToTarget;
    }
    //����һ�����Ժ���Ҫ��֤��Vector3

    void Update()
    {
        SwitchAnimator();
    }

    private void SwitchAnimator()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);//����תfloat��
    }
    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }
}
