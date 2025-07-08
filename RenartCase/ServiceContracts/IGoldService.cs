namespace RenartCase.ServiceContracts
{
    public interface IGoldService
    {
        /// <summary>
        /// 1 gram altının anlık USD fiyatını döndürür.
        /// </summary>
        Task<double> GetPricePerGramAsync();
    }
}

