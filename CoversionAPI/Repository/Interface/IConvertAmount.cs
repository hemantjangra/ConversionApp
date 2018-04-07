namespace CoversionAPI.Repository.Interface
{
    using Models.Implementation;

    /// <summary>
    /// Interface to Handle Conversion
    /// </summary>
    public interface IConvertAmount
    {
        /// <summary>
        /// Convert Numeric Input To Alphabets
        /// </summary>
        /// <param name="input">PersonInputDetail model</param>
        /// <returns>PersonDetail Model</returns>
        PersonDetail ConvertAmountToAplha(PersonDetail input);
    }
}
