using System.Collections.Generic;
using XtramilesTest.WebAPI.Models;

namespace XtramilesTest.WebAPI.Infrastucture
{
    public interface ICountryRepository
    {
        IEnumerable<Countries> Countrieses { get; }
        //Countries this[string id] { get; }
        Countries AddCountries(Countries Countries);
    }
}
