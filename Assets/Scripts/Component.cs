using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component:MonoBehaviour
{
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
}
