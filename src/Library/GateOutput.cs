namespace Library
{
    public class GateOutput : ILogicValue
    {
        private readonly IGate gate;
        public GateOutput(IGate gate)
        {
            this.gate = gate;
        }
        public bool Value => this.gate.Output().Value;
    }
}