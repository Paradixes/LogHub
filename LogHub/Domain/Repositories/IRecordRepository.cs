using Domain.Entities.Records;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IRecordRepository
{
    Task<Record?> GetByIdAsync(RecordId id);

    void Add(Record record);

    Task RemovePermissionAsync(RecordId recordId, UserId userId);
}
