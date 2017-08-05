using System.Linq;
using AutoMapper;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Pedidos.Commands;

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
                                l.Ingredientes.Select(i => new Ingrediente(i.Id, i.Nome, i.Valor))
                            )
                        )
                    )
                );
        }
    }
}
