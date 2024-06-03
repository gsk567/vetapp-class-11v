using System;
using System.Collections.Generic;

namespace Data;

public class DogRepository : IDogRepository
{
    private readonly string id = Guid.NewGuid().ToString();
    
    public IEnumerable<Dog> FetchDogs()
    {
        // db stuff

        return new List<Dog>
        {
            new Dog { Id = 1, Name = $"Harry {this.id}", Breed = DogBreed.GermanShepherd, DateOfBirth = new DateOnly(2015, 1, 1)},
            new Dog { Id = 2, Name = $"Brad {this.id}", Breed = DogBreed.Boxer, DateOfBirth = new DateOnly(2020, 5, 5) }
        };
    }
}