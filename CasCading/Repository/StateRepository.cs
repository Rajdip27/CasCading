using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;

namespace CasCading.Repository;

public class StateRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<State, VmState>(mapper, dbContext), IStateRepository;