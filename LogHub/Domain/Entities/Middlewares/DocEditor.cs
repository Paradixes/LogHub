﻿using Domain.Entities.Records;
using Domain.Entities.Records.Docs;
using Domain.Entities.Users;

namespace Domain.Entities.Middlewares;

public class DocEditor
{
    internal DocEditor(RecordId docId, UserId userId)
    {
        DocId = docId;
        UserId = userId;
    }

    public RecordId DocId { get; private set; }

    public Document? Doc { get; private set; }

    public UserId UserId { get; private set; }

    public User? User { get; private set; }
}
