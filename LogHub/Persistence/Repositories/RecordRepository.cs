using Domain.Entities.Records;
using Domain.Entities.Users;
using Domain.Exceptions.Records;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class RecordRepository : IRecordRepository
{
    private readonly LogHubDbContext _context;

    public RecordRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public async Task<Record?> GetByIdAsync(RecordId id)
    {
        return await _context.Records
            .Include(r => r.Permissions)
            .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public void Add(Record record)
    {
        _context.Records.Add(record);
    }

    public async Task RemovePermissionAsync(RecordId recordId, UserId userId)
    {
        var record = await _context.Records
            .Include(r => r.Permissions)
            .ThenInclude(p => p.UserId)
            .FirstOrDefaultAsync(r => r.Id == recordId);

        if (record is null)
        {
            throw new RecordNotFoundException(recordId);
        }

        var permission = record.Permissions.FirstOrDefault(p => p.UserId == userId);

        if (permission is null)
        {
            throw new RecordPermissionNotFoundException(recordId, userId);
        }

        _context.RecordPermissions.Remove(permission);
    }
}
