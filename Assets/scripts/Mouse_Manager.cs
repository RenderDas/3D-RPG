using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events; �Դ��¼�
using System;//����ϵͳ�¼�

//[System.Serializable]
//public class EventVector3:UnityEvent<Vector3> { }
public class Mouse_Manager : MonoBehaviour
{
    public static Mouse_Manager Instance;
    RaycastHit hitInfo;
    // public EventVector3 OnMouseClicked;
    public event Action<Vector3> OnMouseClicked;//�ɹ�������һ��event event�¼���Ҫ����ע����
    public Texture2D point, doorway, attack, target, arrow;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;    
    }
    void Update()
    {
        SetCursorTexture();
        MouseCtrol();
    }

    void SetCursorTexture()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo))
        {
            //�л������ͼ
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    //ϵͳ�Ļ�����ͼ��� ϵͳ���õķ��� λ�� ƫ���� ���ģʽ
                    break;
                case "Enemy":
                    Cursor.SetCursor(attack, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case "Portal":
                    Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case "Item":
                    Cursor.SetCursor(point, new Vector2(16, 16), CursorMode.Auto);
                    break;
                
                default:
                    Cursor.SetCursor(arrow, new Vector2(16, 16), CursorMode.Auto);
                    break;
            }

        }
    }

    void MouseCtrol()
    {
        if(Input.GetMouseButtonDown(0)&&hitInfo.collider!=null)
        {
            if(hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);//�ں����е��ú��� ����ע��������¼��Ķ������
                //��ִ�����мӵ�OnMouseClicked����ķ���
            }
        }

    }

}
