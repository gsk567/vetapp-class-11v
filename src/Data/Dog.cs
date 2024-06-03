using System;

namespace Data;

public class Dog
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DogBreed Breed { get; set; }
}