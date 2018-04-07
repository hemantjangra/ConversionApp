namespace CoversionAPI.Models.Interface
{
    /// <summary>
    /// Interface Holding Person Details
    /// </summary>
    public interface IPersonDetail
    {
        /// <summary>
        /// Name of Person
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Amount in Aplhabet
        /// </summary>
        string Amount { get; set; }
    }
}
