namespace LoanAPI.Context.IEntity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreationTime { get; set; }
    }
}
