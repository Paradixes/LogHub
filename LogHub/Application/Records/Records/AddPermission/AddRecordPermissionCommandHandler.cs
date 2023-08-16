using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Records.AddPermission;

public class AddRecordPermissionCommandHandler :
    IRequestHandler<AddRecordPermissionCommand>
{
    private readonly IRecordRepository _recordRepository;

    public AddRecordPermissionCommandHandler(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task Handle(AddRecordPermissionCommand request, CancellationToken cancellationToken)
    {
        var record = await _recordRepository.GetByIdAsync(request.RecordId);

        if (record is null)
        {
            throw new RecordNotFoundException(request.RecordId);
        }

        record.AddPermission(request.UserId, request.Level);
    }
}
