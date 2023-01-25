using Ewone.Domain.DataLayer.User;
using Ewone.Api.Helpers;
using Ewone.Domain.DataLayer.Card;
using Ewone.Domain.DataLayer.Card.Entities;
using Ewone.Domain.DataLayer.UserCard;
using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.RequestHandlers.Login;

public class LoginRequestHandler
{
    private readonly JwtHelper _jwtHelper;
    private readonly UserRepository _userRepository;
    private readonly CardRepository _cardRepository;
    private readonly UserCardRepository _userCardRepository;

    public LoginRequestHandler(
        JwtHelper jwtHelper,
        UserRepository userRepository,
        CardRepository cardRepository,
        UserCardRepository userCardRepository)
    {
        _jwtHelper = jwtHelper;
        _userRepository = userRepository;
        _cardRepository = cardRepository;
        _userCardRepository = userCardRepository;
    }

    public async Task<IActionResult> Handle(LoginRequest request)
    {
        var payload = await _jwtHelper.VerifyGoogleToken(request.IdToken);
        if (payload == null)
            return new BadRequestObjectResult("Invalid External Authentication.");
        ;
        UserEntity? user = await _userRepository.GetByEmail(payload.Email);

        if (user == null)
        {
            user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = payload.Email,
                Name = payload.Name,
                CreateDate = DateTime.UtcNow,
            };

            await _userRepository.Add(user);

            IEnumerable<CardWordView> cards = await _cardRepository.GetDefaultCards();

            foreach (var card in cards)
            {
                await _userCardRepository.Add(new UserCardEntity
                {
                    Id = Guid.NewGuid(),
                    IdUser = user.Id,
                    IdCard = card.CardId,
                });
            }
        }

        var token = _jwtHelper.CreateAccessToken(user);

        return new OkObjectResult(new LoginResponse { Token = token, IsAuthSuccess = true });
    }
}