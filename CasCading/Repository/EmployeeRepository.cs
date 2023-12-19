using AutoMapper;
using CasCading.ApplicationDb;
using CasCading.Models;
using CasCading.Service;
using CasCading.ViewModel;

namespace CasCading.Repository;

public class EmployeeRepository(IMapper mapper, ApplicationDbContext dbContext)
    : RepositoryService<Employee, VmEmployee>(mapper, dbContext), IEmployeeRepository;