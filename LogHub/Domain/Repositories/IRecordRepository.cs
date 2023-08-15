using Domain.Entities.Records;

namespace Domain.Repositories;

public interface IRecordRepository
{
    Task<Record?> GetByIdAsync(RecordId id);

    void Add(Record record);
}
