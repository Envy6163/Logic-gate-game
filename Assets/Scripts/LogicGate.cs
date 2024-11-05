using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGate : Component
{
    public List<Wire> inputWires = new List<Wire>(); // ������·
    public Wire outputWire; // �����·
    protected bool outputValue;
    public bool OutputValue { get { return outputValue; } }
    
    // ��ʼ��ʱ������ÿ��������·��ֵ�ı��¼�
    public void SubscribeToInputs()
    {
        foreach (var inputWire in inputWires)
        {
            inputWire.OnValueChanged += HandleInputChanged; // ����������·��ֵ�ı��¼�
        }
    }

    // ��������·��ֵ�ı�ʱ�����¼����߼����
    private void HandleInputChanged()
    {
        ExecuteLogic(); // ִ���߼�����
    }

    // �������ֵ
    protected void SetOutputValue(bool value)
    {
        outputValue = value;
        if (outputWire != null)
        {
            outputWire.Value=value; // ͨ�������·����ֵ
        }
    }
    public override void SetPosition(Vector2Int pos)
    {
        base.SetPosition(pos);
    }
    // ִ���߼����㣨����ʵ�־����߼���
    protected virtual void ExecuteLogic()
    {
        // ����ʵ�־����߼�
    }
}
