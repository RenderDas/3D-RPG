using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events; 自创事件
using System;//创建系统事件

//[System.Serializable]
//public class EventVector3:UnityEvent<Vector3> { }
public class Mouse_Manager : MonoBehaviour
{
    public static Mouse_Manager Instance;
    RaycastHit hitInfo;
    // public EventVector3 OnMouseClicked;
    public event Action<Vector3> OnMouseClicked;//成功创建了一个event event事件需要用人注册它
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
            //切换鼠标贴图
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    //系统的换鼠标的图标的 系统内置的方法 位置 偏移量 鼠标模式
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
                OnMouseClicked?.Invoke(hitInfo.point);//在函数中调用函数 所有注册了这个事件的都会调用
                //会执行所有加到OnMouseClicked里面的方法
            }
        }

    }

}
