



//***********************������!!!************************//
//***********************������!!!************************//
//***********************������!!!************************//


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class LogicGate : Component
//{
    
//    // ��ʼ��ʱ������ÿ��������·��ֵ�ı��¼�
//    public void SubscribeToInputs()
//    {
//        foreach (var inputWire in inputWires)
//        {
//            if(inputWire!=null)
//                inputWire.ValueChanged += HandleInputChanged; // ����������·��ֵ�ı��¼�
//        }
//    }
//    public void CancelSubscribeToInputs()
//    {
//        foreach (var inputWire in inputWires)
//        {
//            if (inputWire != null)
//                inputWire.ValueChanged -= HandleInputChanged;
//        }
//    }
//    // ��������·��ֵ�ı�ʱ�����¼����߼����
//    private void HandleInputChanged()
//    {
//        ExecuteLogic(); // ִ���߼�����
//    }

//    // �������ֵ
//    //protected void SetOutputValue(int value)
//    //{
//    //    outputValue = value;
//    //    if (outputWire != null)
//    //    {
//    //        outputWire.Value=value; // ͨ�������·����ֵ
//    //    }
//    //}
//    public override void SetPosition(Vector2Int pos)
//    {
//        base.SetPosition(pos);
//    }
//    // ִ���߼����㣨����ʵ�־����߼���
//    protected virtual void ExecuteLogic()
//    {
//        // ����ʵ�־����߼�
//    }

//    //������ǰȡ�������Է�ֹ�����쳣
//    private void OnDisable()
//    {
//        CancelSubscribeToInputs();
//    }
//}
