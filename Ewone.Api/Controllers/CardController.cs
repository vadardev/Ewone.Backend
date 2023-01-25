using System.Security.Claims;
using Ewone.Api.RequestHandlers.AddCard;
using Ewone.Api.RequestHandlers.DefaultCard;
using Ewone.Api.RequestHandlers.DefaultCards;
using Ewone.Api.RequestHandlers.DeleteCard;
using Ewone.Api.RequestHandlers.EditCard;
using Ewone.Api.RequestHandlers.UserCard;
using Ewone.Api.RequestHandlers.UserCards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ewone.Api.Controllers;

[ApiController]
[Route("api/card")]
public class CardController : BaseController
{
    private readonly DefaultCardsRequestHandler _defaultCardsRequestHandler;
    private readonly DefaultCardRequestHandler _defaultCardRequestHandler;
    private readonly UserCardsRequestHandler _userCardsRequestHandler;
    private readonly UserCardRequestHandler _userCardRequestHandler;
    private readonly EditCardRequestHandler _editCardRequestHandler;
    private readonly AddCardRequestHandler _addCardRequestHandler;
    private readonly DeleteCardRequestHandler _deleteCardRequestHandler;
    
    public CardController(
        DefaultCardsRequestHandler defaultCardsRequestHandler,
        DefaultCardRequestHandler defaultCardRequestHandler,
        UserCardsRequestHandler userCardsRequestHandler,
        UserCardRequestHandler userCardRequestHandler,
        EditCardRequestHandler editCardRequestHandler,
        AddCardRequestHandler addCardRequestHandler,
        DeleteCardRequestHandler deleteCardRequestHandler)
    {
        _defaultCardsRequestHandler = defaultCardsRequestHandler;
        _defaultCardRequestHandler = defaultCardRequestHandler;
        _userCardsRequestHandler = userCardsRequestHandler;
        _userCardRequestHandler = userCardRequestHandler;
        _editCardRequestHandler = editCardRequestHandler;
        _addCardRequestHandler = addCardRequestHandler;
        _deleteCardRequestHandler = deleteCardRequestHandler;
    }

    [HttpGet("default")]
    public Task<DefaultCardsResponse> GetDefaultCards()
    {
        return _defaultCardsRequestHandler.Handle();
    }

    [HttpGet("default/{cardId}")]
    public Task<DefaultCardResponse> GetDefaultCard([FromRoute] DefaultCardRequest request)
    {
        return _defaultCardRequestHandler.Handle(request);
    }

    [HttpGet("all")]
    [Authorize]
    public Task<UserCardsResponse> GetUserCards()
    {
        return _userCardsRequestHandler.Handle(GetUserId());
    }

    [HttpGet("user/{userCardId}")]
    [Authorize]
    public Task<UserCardResponse> GetUserCard([FromRoute] UserCardRequest request)
    {
        return _userCardRequestHandler.Handle(request, GetUserId());
    }
    
    [HttpPost("user/{userCardId}/edit")]
    [Authorize]
    public Task EditUserCard([FromRoute] EditCardRequest request)
    {
        return _editCardRequestHandler.Handle(request, GetUserId());
    }
    
    [HttpPost("add")]
    [Authorize]
    public Task AddUserCard([FromBody] AddCardRequest request)
    {
        return _addCardRequestHandler.Handle(request, GetUserId());
    }
    
    [HttpDelete("{userCardId}/delete")]
    [Authorize]
    public Task DeleteUserCard([FromRoute] DeleteCardRequest request)
    {
        return _deleteCardRequestHandler.Handle(request);
    }
}