namespace AbsenceManagement.Domain.Requests
{
    public enum Status
    {
        InRequest,
        Approved,
        InProcessing_Approved,
        Rejected,
        InProcessing_Rejected,
        Cancelled,
        InProcessing_Cancelled
    }
}
