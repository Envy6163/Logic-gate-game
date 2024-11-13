using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Component:MonoBehaviour
{
    public List<Wire> inputWires;
    protected int outputValue;
    public int OutputValue
    {
        get
        {
            return outputValue;
        }
        set
        {
            outputValue = value;
            OnValueChanged();
        }
    }
    public event Action ValueChanged;
    public void OnValueChanged()
    {
        ValueChanged?.Invoke();
    }
    // ��ʼ��ʱ������ÿ��������·��ֵ�ı��¼�
    public void SubscribeToInputs()
    {
        foreach (var inputWire in inputWires)
        {
            if (inputWire != null)
                inputWire.ValueChanged += HandleInputChanged; // ����������·��ֵ�ı��¼�
        }
    }
    public void CancelSubscribeToInputs()
    {
        foreach (var inputWire in inputWires)
        {
            if (inputWire != null)
                inputWire.ValueChanged -= HandleInputChanged;
        }
    }
    // ��������·��ֵ�ı�ʱ�����¼����߼����
    private void HandleInputChanged()
    {
        ExecuteLogic(); // ִ���߼�����
    }
    protected virtual void ExecuteLogic()
    {
        // ����ʵ�־����߼�
    }

    //������ǰȡ�������Է�ֹ�����쳣
    private void OnDisable()
    {
        CancelSubscribeToInputs();
    }
    //Ԫ����������֮�ⲿ��ռ�õ�����
    public List<Vector2Int> PositionOfBody{ get; set; }
    //Ԫ�����Ų���ռ�õ�����
    public List<Vector2Int> PositionOfInputPin { get; set; }
    public List<Vector2Int> PositionOfOutputPin { get; set; }

    //�����Ԫ�����ĵ�����
    public List<Vector2Int> RelativePositionOfBody { get; set; }
    public List<Vector2Int> RelativePositionOfInputPin { get; set; }
    public List<Vector2Int> RelativePositionOfOutputPin { get; set; }
    public virtual void SetPosition(Vector2Int pos)
    {

    }
    protected void InitComponent()
    {
        inputWires = new();
        RelativePositionOfInputPin = new();
        RelativePositionOfBody = new();
        RelativePositionOfOutputPin = new();
        PositionOfBody = new();
        PositionOfInputPin = new();
        PositionOfOutputPin = new();
    }
}
