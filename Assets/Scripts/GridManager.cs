using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Vector3 WorldPositionOfGridOrigin; // ����ԭ��λ��
    [SerializeField] private int gridWidth = 100; // ������
    [SerializeField] private int gridHeight = 100; // ����߶�
    [SerializeField] private float cellSize = 1.0f; // ��Ԫ���С
    [SerializeField] private Camera mainCamera;
    private List<LogicGate> logicGates;
    private List<Wire> wires;
    public float CellSize { get { return cellSize; } }
    public bool isDragging=false;
    public static GridManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("���ֶ�� GridManager ʵ������ɾ�������ʵ����");
            Destroy(gameObject);
            return;
        }
        transform.position = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        WorldPositionOfGridOrigin = transform.position;
        logicGates = new List<LogicGate>();
        wires = new List<Wire>();
    }

    private void Start()
    {
        // ����ѡ���Ե�����Ϸ��ʼʱ����������
        DrawLine();
    }

    private void Update()
    {
        // ��ѡ��������Ҫ���»����»���������
        DrawLine();
    }
    public void RemoveLogicGate(LogicGate logicGate)
    {
        logicGates.Remove(logicGate);
    }
    public void PlaceLogicGate(LogicGate logicGate)
    {
        logicGates.Add(logicGate);
    }

    public bool CanBePlaced(Component component)
    {
        foreach (var logicGate in logicGates)
        {
            List<Vector2Int> positionOfAll = logicGate.PositionOfInputPin.Concat(logicGate.PositionOfBody)
                .Concat(logicGate.PositionOfOutputPin).ToList();
            if (positionOfAll.Intersect(component.PositionOfBody).Any() ||
                positionOfAll.Intersect(component.PositionOfInputPin).Any() ||
                positionOfAll.Intersect(component.PositionOfOutputPin).Any())
            {
                Debug.Log("conflict");
                return false;
            }
        }

        foreach (var wire in wires)
        {
            if (wire.Position.Intersect(component.PositionOfBody).Any())
                return false;
        }
        return true;
    }
    public bool CanBePlaced(Component component,Vector2Int gridPosition)
    {
        List<Vector2Int> truePositionOfBody=new();
        List<Vector2Int> truePositionOfPin = new();
        foreach(var pos in component.RelativePositionOfBody)
        {
            truePositionOfBody.Add(pos + gridPosition);
        }
        foreach (var pos in component.RelativePositionOfInputPin)
        {
            truePositionOfPin.Add(pos + gridPosition);
        }
        foreach(var pos in component.RelativePositionOfOutputPin)
        {
            truePositionOfPin.Add(pos + gridPosition);
        }
        foreach (var logicGate in logicGates)
        {
            List<Vector2Int> positionOfAll = logicGate.PositionOfInputPin.Concat(logicGate.PositionOfBody)
                .Concat(logicGate.PositionOfOutputPin).ToList();
            if(positionOfAll.Intersect(truePositionOfBody).Any() || positionOfAll.Intersect(truePositionOfPin).Any())
            {
                return false;
            }
        }
        foreach(var wire in wires)
        {
            if (wire.Position.Intersect(truePositionOfBody).Any())
            {
                return false;
            }
        }
        return true;
    }

    public Vector3 GetWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(gridPosition.x * cellSize + WorldPositionOfGridOrigin.x,
                           gridPosition.y * cellSize + WorldPositionOfGridOrigin.y, 0);
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - WorldPositionOfGridOrigin.x) / cellSize);
        int y = Mathf.FloorToInt((worldPosition.y - WorldPositionOfGridOrigin.y) / cellSize);
        return new Vector2Int(x, y);
    }

    public bool IsWithinGrid(Vector2Int gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.y >= 0 && gridPosition.x < gridWidth && gridPosition.y < gridHeight;
    }

    public bool IsWithinGrid(Vector3 worldPosition)
    {
        Vector2Int gridPosition = GetGridPosition(worldPosition);
        return IsWithinGrid(gridPosition);
    }

    public Vector3 SnapToGrid(Vector3 worldPosition)
    {
        return GetWorldPosition(GetGridPosition(worldPosition));
    }

    public void DrawLine()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                Vector3 worldPosition = GetWorldPosition(new Vector2Int(i, j));
                Debug.DrawLine(worldPosition, new Vector3(worldPosition.x + cellSize, worldPosition.y, 0), Color.green);
                Debug.DrawLine(worldPosition, new Vector3(worldPosition.x, worldPosition.y + cellSize, 0), Color.green);
            }
        }
    }
}
