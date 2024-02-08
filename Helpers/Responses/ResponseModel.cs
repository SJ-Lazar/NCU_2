namespace Helpers.Responses;

public class ResponseModel
{
    public Guid? ResponseId { get; set; }
    public string? ResponseType { get; set; }
    public string? Responder { get; set; }
    public string? ResponseDate { get; set; }
    public string? ResponseStatus { get; set; }
    public string? ResponseDescription { get; set; }
    public string? ResponsePriority { get; set; }
    public string? ResponseAssignedTo { get; set; }
    public string? ResponseDueDate { get; set; }
}
