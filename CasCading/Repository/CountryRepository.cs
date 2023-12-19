using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;

namespace CasCading.Repository;

public class CountryRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<Country, VmCountry>(mapper, dbContext), ICountryRepository;