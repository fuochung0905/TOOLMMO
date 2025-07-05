namespace MODELS.BASE
{
    public class DeleteListRequest : BaseRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
