```mermaid
classDiagram
    direction LR

    class LogicValue{
        Value: bool
    }

    class TrueValue{
        Value: bool
    }

    class FalseValue{
        Value: bool
    }

    class GateOutput{
        Value: bool
    }
    
    class Gate{
        <<interface>>
        output() bool
    }

    class AndGate{
        input1 : LogicValue
        input2 : LogicValue
        output() : LogicValue
    }