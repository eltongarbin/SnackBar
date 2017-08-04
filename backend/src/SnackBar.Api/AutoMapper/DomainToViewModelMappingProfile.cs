using AutoMapper;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Ingredientes;
using SnackBar.Domain.Lanches;
using SnackBar.Domain.Pedidos;
using System.Collections.Generic;
using System.Linq;

namespace SnackBar.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Ingrediente, IngredienteViewModel>();
            CreateMap<Lanche, LancheViewModel>()
                .ForMember(d => d.Ingredientes, o => o.MapFrom(s => s.LanchesPredefinidos.Select(m => m.Ingrediente)));
            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(d => d.ValorTotal, o => o.MapFrom(s => s.Valor))
                .ForMember(d => d.Lanches, o => o.MapFrom(s => s.PedidosLanches.Select(m => m.Lanche)));
            CreateMap<Pedido, DetalhePedidoViewModel>()
                .ForMember(d => d.ValorTotal, o => o.MapFrom(s => s.Valor))
                .ForMember(d => d.Lanches, o => o.MapFrom(s =>
                                                            s.PedidosLanches.Select(m => new LancheViewModel
                                                            {
                                                                Id = m.Lanche.Id,
                                                                Nome = m.Lanche.Nome,
                                                                Valor = m.Valor,
                                                                Ingredientes = Mapper.Map<IEnumerable<Ingrediente>, IEnumerable<IngredienteViewModel>>(m.LanchesCustomizados.Select(lc => lc.Ingrediente).AsEnumerable())
                                                            })
                                                         ));
        }
    }
}