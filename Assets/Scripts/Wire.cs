using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire:MonoBehaviour
{
    public List<Vector2Int> Position { get; set; }
    public Vector2Int StartPos { get; set; }
    public Vector2Int EndPos { get; set; }
    public List<Wire> connectedWires;
    public List<Component> inputComponent;
    private int  value; // �洢��·�ĵ�ǰֵ
    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            OnValueChanged();
        }
    }
    private void HandleInputChanged()
    {
        int outVal = 0;
        foreach(var input in inputComponent)
        {
            if (input != null)
            {
                outVal = input.OutputValue;
                break;
            }
        }
        //���ѭ�������жϲ������·
        foreach (var input in inputComponent)
        {
            if (input != null)
            {
                if (outVal != input.OutputValue)//������·
                {
                    //��·����
                    outVal = -1;
                }
            }
        }
        Value = outVal;
    }
    public void SubscribeToInputs()
    {
        foreach(var input in inputComponent)
        {
            if (input != null)
            {
                input.ValueChanged += HandleInputChanged;
            }
        }
    }
    public void CancelSubscribeToInputs()
    {
        foreach (var input in inputComponent)
        {
            if (input != null)
            {
                input.ValueChanged -= HandleInputChanged;
            }
        }
    }
    // ����ֵ�ı��¼�
    public event Action ValueChanged;
    public void OnValueChanged()
    {
        ValueChanged?.Invoke();
    }
    private void Awake()
    {
        Position = new();
        StartPos = new();
        EndPos = new();
        value = 0;
        connectedWires = new();
    }
    
    //������ǰȡ������
    private void OnDisable()
    {
        CancelSubscribeToInputs();
    }
}
