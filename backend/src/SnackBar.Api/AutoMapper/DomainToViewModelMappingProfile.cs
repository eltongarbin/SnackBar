using AutoMapper;
using SnackBar.Api.ViewModels;
using SnackBar.Domain.Ingredientes;

namespace SnackBar.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Ingrediente, IngredienteViewModel>();
        }
    }
}