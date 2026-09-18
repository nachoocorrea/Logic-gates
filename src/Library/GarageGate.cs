using System.Runtime.Serialization;
using System.Xml;

namespace Library
{
    public class GarageGate : IGate
    {
        private readonly ILogicValue inputA;
        private readonly ILogicValue inputB;
        private readonly ILogicValue inputC;
        public GarageGate(ILogicValue inputA, ILogicValue inputB, ILogicValue inputC)
        {
            this.inputA = inputA;
            this.inputB = inputB;
            this.inputC = inputC;
        }

        public ILogicValue Output()
        {
            IGate notA = new NotGate(this.inputA);
            IGate notB = new NotGate(this.inputB);

            IGate andAB = new AndGate(this.inputA, this.inputB);
            IGate notAANDNotB = new AndGate(new GateOutput(notA), new GateOutput(notB));

            IGate orResult = new OrGate(new GateOutput(andAB), new GateOutput(notAANDNotB));
            IGate resultado = new AndGate(this.inputC, new GateOutput(orResult));

            return resultado.Output();
        }
    }
}