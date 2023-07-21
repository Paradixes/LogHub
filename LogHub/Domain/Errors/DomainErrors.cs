﻿using LogHub.Domain.Shared;

namespace LogHub.Domain.Errors;

public static class DomainErrors
{
    public static class User
    {
        public static class Registration
        {
            public static readonly Error EmailAlreadyInUse = new(
                "Member.EmailAlreadyInUse",
                "The specified email is already in use");

            public static readonly Func<Guid, Error> NotFound = id => new Error(
                "Member.NotFound",
                $"The member with the identifier {id} was not found.");

            public static readonly Error InvalidCredentials = new(
                "Member.InvalidCredentials",
                "The provided credentials are invalid");
        }
    }
}