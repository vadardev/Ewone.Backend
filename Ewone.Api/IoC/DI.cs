using Ewone.Api.Helpers;
using Ewone.Api.RequestHandlers.AddCard;
using Ewone.Api.RequestHandlers.DefaultCard;
using Ewone.Api.RequestHandlers.DefaultCards;
using Ewone.Api.RequestHandlers.DeleteCard;
using Ewone.Api.RequestHandlers.EditCard;
using Ewone.Api.RequestHandlers.Login;
using Ewone.Api.RequestHandlers.UserCard;
using Ewone.Api.RequestHandlers.UserCards;
using Ewone.Domain.DataLayer;
using Ewone.Domain.DataLayer.Card;
using Ewone.Domain.DataLayer.DbMapper;
using Ewone.Domain.DataLayer.User;
using Ewone.Domain.DataLayer.UserCard;
using Ewone.Domain.DataLayer.Word;

namespace Ewone.Api.IoC;

public class DI
{
    public static void Resolve(IServiceCollection services)
    {
        services.AddSingleton<IDbMapper>(x => { return new NpgsqlDapperDbMapper(() => DbConfig.ConnectionString); });
        services.AddTransient<JwtHelper>();

        services.AddSingleton<LoginRequestHandler>();
        services.AddSingleton<DefaultCardsRequestHandler>();
        services.AddSingleton<UserCardsRequestHandler>();
        services.AddSingleton<DefaultCardRequestHandler>();
        services.AddSingleton<UserCardRequestHandler>();
        services.AddSingleton<EditCardRequestHandler>();
        services.AddSingleton<AddCardRequestHandler>();
        services.AddSingleton<DeleteCardRequestHandler>();
        

        services.AddSingleton<CardRepository>();
        services.AddSingleton<UserRepository>();
        services.AddSingleton<WordRepository>();
        services.AddSingleton<UserCardRepository>();
    }
}