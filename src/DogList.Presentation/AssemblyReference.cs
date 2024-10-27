using System.Reflection;

namespace DogList.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}