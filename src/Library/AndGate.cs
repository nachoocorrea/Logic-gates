namespace Library
{
    public class AndGate : IGate
    {
        private readonly ILogicValue input1;
        private readonly ILogicValue input2;
        public AndGate(ILogicValue input1, ILogicValue input2)
        {
            this.input1 = input1;
            this.input2 = input2;
        }
        public ILogicValue Output()
        {
            bool result = this.input1.Value && this.input2.Value;
            if (result)
            {
                return new TrueValue();
            }
            
            return new FalseValue();
        }
    }
}