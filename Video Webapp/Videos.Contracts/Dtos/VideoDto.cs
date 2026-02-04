namespace Videos.Contracts.Dtos;

public record VideoDto(int Id, string Title, string Description, DateTime CreateDate, string Category);