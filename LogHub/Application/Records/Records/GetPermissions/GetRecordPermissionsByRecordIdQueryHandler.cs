using Application.Users.Users.GetById;
using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Records.GetPermissions;

public class GetRecordPermissionsByRecordIdQueryHandler :
    IRequestHandler<GetRecordPermissionsByRecordIdQuery, List<RecordPermissionResponse>>
{
    private readonly IRecordRepository _recordRepository;

    public GetRecordPermissionsByRecordIdQueryHandler(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task<List<RecordPermissionResponse>> Handle(GetRecordPermissionsByRecordIdQuery request,
        CancellationToken cancellationToken)
    {
        var record = await _recordRepository.GetByIdAsync(request.RecordId);

        if (record is null)
        {
            throw new RecordNotFoundException(request.RecordId);
        }


        var response = record.Permissions.Select(
            p => new RecordPermissionResponse(
                p.RecordId.Value,
                p.UserId.Value,
                new UserResponse(
                    p.User!.Id.Value,
                    p.User.Email,
                    p.User.Name,
                    p.User.AvatarUri,
                    p.User.Profession,
                    p.User.Orcid,
                    p.User.Role
                ),
                p.Level)
        ).ToList();

        return response;
    }
}
