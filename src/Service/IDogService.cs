using System.Collections.Generic;

namespace Service;

public interface IDogService
{
    long CreateRandomDog();
    
    IEnumerable<DogModel> FetchDogs();
}