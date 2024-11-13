using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ýű���ӵ�����ComponentԪ��Ԥ�Ƽ��ϼ���ʵ�������ָ�����Ԫ����Χʱ��"R"����תֵ
public class ComponentValueChanger : MonoBehaviour
{
    private Component component;

    private void ChangeValue()
    {
        if (component.OutputValue == 1)
        {
            component.OutputValue = 0;
        }
        else if (component.OutputValue == 0)
        {
            component.OutputValue = 1;
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeValue();
        }
    }
    private void Awake()
    {
        component = GetComponent<Component>();
    }
}
