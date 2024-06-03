using System.Collections.Generic;

namespace Service;

public interface IDogService
{
    IEnumerable<DogModel> FetchDogs();
}