using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Records.UpdatePermission;

public class UpdateRecordPermissionCommandHandler : IRequestHandler<UpdateRecordPermissionCommand>
{
    private readonly IRecordRepository _recordRepository;

    public UpdateRecordPermissionCommandHandler(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task Handle(UpdateRecordPermissionCommand request, CancellationToken cancellationToken)
    {
        var record = await _recordRepository.GetByIdAsync(request.RecordId);

        if (record is null)
        {
            throw new RecordNotFoundException(request.RecordId);
        }

        record.UpdatePermission(request.UserId, request.Level);
    }
}