using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;

namespace CasCading.Repository;

public interface ICountryRepository:IRepositoryService<Country,VmCountry>
{
}