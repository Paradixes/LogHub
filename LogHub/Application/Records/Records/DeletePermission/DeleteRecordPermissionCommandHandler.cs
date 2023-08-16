using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Records.DeletePermission;

public class DeleteRecordPermissionCommandHandler : IRequestHandler<DeleteRecordPermissionCommand>
{
    private readonly IRecordRepository _recordRepository;

    public DeleteRecordPermissionCommandHandler(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task Handle(DeleteRecordPermissionCommand request, CancellationToken cancellationToken)
    {
        var record = await _recordRepository.GetByIdAsync(request.RecordId);

        if (record is null)
        {
            throw new RecordNotFoundException(request.RecordId);
        }

        record.RemovePermission(request.UserId);
    }
}
