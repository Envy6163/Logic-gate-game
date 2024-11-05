//public class CircuitCompiler
//{
//    private GridManager circuitManager;

//    public CircuitCompiler(GridManager manager)
//    {
//        circuitManager = manager;
//    }

//    public void Compile()
//    {
//        foreach (var component in circuitManager.GetAllComponents())
//        {
//            if (component is LogicGate logicGate)
//            {
//                // ����������·���ҵ��������߼������������ϵ���·
//                foreach (var wire in circuitManager.GetAllWires())
//                {
//                    // �����·���յ��Ƿ�Ϊ���߼��ŵ���������
//                    if (IsConnected(wire.endComponent, logicGate))
//                    {
//                        logicGate.inputWires.Add(wire);
//                    }

//                    // �����·������Ƿ�Ϊ���߼��ŵ��������
//                    if (IsConnected(wire.startComponent, logicGate))
//                    {
//                        logicGate.outputWire = wire;
//                    }
//                }

//                // ���߼��Ŷ�����������·
//                logicGate.SubscribeToInputs();
//            }
//        }
//    }

//    private bool IsConnected(CircuitComponent pinComponent, LogicGate logicGate)
//    {
//        // ������Ը��ݾ���������߼��ж��Ƿ�����
//        return pinComponent == logicGate;
//    }
//}
