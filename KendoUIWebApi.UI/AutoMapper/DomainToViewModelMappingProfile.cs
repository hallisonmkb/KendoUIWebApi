using AutoMapper;
using KendoUIWebApi.Domain.Entities;
using KendoUIWebApi.UI.ViewModels;

namespace KendoUIWebApi.UI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel> ();
            Mapper.CreateMap<Produto, ProdutoViewModel> ();
        }
    }
}