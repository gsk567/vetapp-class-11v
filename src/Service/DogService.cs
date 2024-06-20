using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Service;

internal class DogService : IDogService
{
    private readonly EntityContext context;

    public DogService(EntityContext context)
    {
        this.context = context;
    }

    public long CreateRandomDog()
    {
        var dog = new Dog
        {
            Name = Guid.NewGuid().ToString(),
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
            Breed = DogBreed.Akita,

        };
        
        this.context.Dogs.Add(dog);
        this.context.SaveChanges();
        return dog.Id;
    }

    public IEnumerable<DogModel> FetchDogs()
    {
        var nowYear = DateTime.Now.Year;
        return this.context.Dogs.Select(x => new DogModel
        {
            Id = x.Id,
            Name = x.Name,
            Breed = x.Breed,
            Age = nowYear - x.DateOfBirth.Year
        });
    }
}