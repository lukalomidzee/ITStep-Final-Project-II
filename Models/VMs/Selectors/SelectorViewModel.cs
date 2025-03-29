namespace CarRentalApplication.Models.VMs.Selectors
{
    public class SelectorViewModel<TValue>
    {
        public int Id { get; set; }
        public TValue Value { get; set; }
        public string DisplayName { get; set; }
    }
}
