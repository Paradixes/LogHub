using Domain.Entities.Records;
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
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public void Add(Record record)
    {
        _context.Records.Add(record);
    }
}
