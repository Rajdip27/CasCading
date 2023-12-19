using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;

namespace CasCading.Repository;

public class CityRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<City, VmCity>(mapper, dbContext), ICityRepository;