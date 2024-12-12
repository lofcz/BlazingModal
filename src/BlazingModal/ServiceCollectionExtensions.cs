using BlazingModal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingModal;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazingModal(this IServiceCollection services) => services.AddScoped<IModalService, ModalService>();
}