namespace Helpers.Requests;

public class RequestModel
{
    public Guid? RequestId { get; set; }
    public string? RequestType { get; set; }
    public string? Requester { get; set; }
    public string? RequestDate { get; set; }
    public string? RequestStatus { get; set; }
    public string? RequestDescription { get; set; }
    public string? RequestPriority { get; set; }
    public string? RequestAssignedTo { get; set; }
    public string? RequestDueDate { get; set; }
}
