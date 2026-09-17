namespace Library
{
    public class NotGate : IGate
    {
        private readonly ILogicValue input;
        public NotGate(ILogicValue input)
        {
            this.input = input;
        }
        public ILogicValue Output()
        {
            bool result = !this.input.Value;

            if (result)
            {
                return new TrueValue();
            }
            
            return new FalseValue();
        }
    }
}