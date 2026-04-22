namespace MyStore.Application.DTOs;
public record ProductRequest(string Name, string Description, decimal Price, int Stock);
public record ProductResponse(Guid Id, string Name, string Description, decimal Price, int Stock);