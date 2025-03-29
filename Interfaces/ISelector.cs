namespace CarRentalApplication.Interfaces
{
    public interface ISelector<Tvalue>
    {
        int Id { get; set; }

        Tvalue Value { get; set; }
    }
}
