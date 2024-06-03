using Data;

namespace Service;

public class DogModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public DogBreed Breed { get; set; }

    public int Age { get; set; }
}