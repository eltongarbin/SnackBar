using AutoMapper;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Pedidos.Commands;
using System.Linq;

namespace SnackBar.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DetalhePedidoViewModel, RealizarPedidoCommand>()
                .ConstructUsing(c => new RealizarPedidoCommand(
                        c.Cliente,
                        c.Lanches.Select(l => new IncluirPedidoLancheCommand(
                                c.Id,
                                l.Id,
                                l.Ingredientes.Select(i => i.Id)
                            )
                        )
                    )
                );
        }
    }
}
