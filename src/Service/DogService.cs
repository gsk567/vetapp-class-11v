using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Service;

public class DogService : IDogService
{
    private readonly IDogRepository dogRepository;

    public DogService(IDogRepository dogRepository)
    {
        this.dogRepository = dogRepository;
    }
    
    public IEnumerable<DogModel> FetchDogs()
    {
        var nowYear = DateTime.Now.Year;
        var dogs = this.dogRepository.FetchDogs();
        return dogs.Select(x => new DogModel
        {
            Id = x.Id,
            Name = x.Name,
            Breed = x.Breed,
            Age = nowYear - x.DateOfBirth.Year
        });
    }
}