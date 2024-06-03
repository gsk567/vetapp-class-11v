using System.Collections.Generic;

namespace Data;

public interface IDogRepository
{
    IEnumerable<Dog> FetchDogs();
}