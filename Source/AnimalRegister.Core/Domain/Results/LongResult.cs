namespace AnimalRegister.Domain.Results
{
    public class LongResult
    {
        /// <summary>
        /// Holds the long result
        /// </summary>
        public long Result { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LongResult(long result)
        {
            Result = result;
        }
    }
}
