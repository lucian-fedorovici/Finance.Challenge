namespace Finance.Shared.Common
{
    public class OperationRequest<InputValueType>
    {
        public RequestContext Context { get; set; }

        public InputValueType InputValue { get; set; }
    }
}
