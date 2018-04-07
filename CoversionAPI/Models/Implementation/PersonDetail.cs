
namespace CoversionAPI.Models.Implementation
{
    using Interface;

    /// <summary>
    /// Class To generate Model
    /// </summary>
    public class PersonDetail : IPersonDetail
    {
        /// <summary>
        /// Name of Person
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Amout in String/Alphabets
        /// </summary>
        public string Amount { get; set; }
    }
}