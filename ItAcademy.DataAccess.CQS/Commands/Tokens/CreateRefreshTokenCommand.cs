﻿using MediatR;

namespace ItAcademy.DataAccess.CQS.Commands.Tokens;

public class CreateRefreshTokenCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string DeviceInfo { get; set; }
}