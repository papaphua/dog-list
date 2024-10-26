using Microsoft.EntityFrameworkCore;

namespace DogList.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options);