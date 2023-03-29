using AutoMapper;
using Entities.Entities;
using Model.Permissions;

namespace Model.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Role
            CreateMap<RoleModel, ApplicationRole>().ReverseMap();
            CreateMap<RoleMenuPermissionModel, RoleMenuPermission>().ReverseMap();
            CreateMap<UserRoleViewModel, ApplicationUserRole>().ReverseMap();
            #endregion

            #region Danh muc
            CreateMap<BannerModel, Banner>().ReverseMap();
            CreateMap<MenuModel, NavigationMenu>().ReverseMap();
            CreateMap<Partner, PartnerModel>().ForMember(x=>x.FileImage, opt => opt.Ignore()).ReverseMap();
            CreateMap<Service, ServiceModel>().ForMember(x => x.FileImage, opt => opt.Ignore()).ReverseMap();
            CreateMap<Settings, SettingModel>().ForMember(x => x.FileLogo, opt => opt.Ignore()).ReverseMap();
            CreateMap<Post, PostModel>().ForMember(x => x.FileImage, opt => opt.Ignore()).ReverseMap();
            CreateMap<Scholarship, ScholarshipModel>().ForMember(x => x.FileImage, opt => opt.Ignore()).ReverseMap();
            CreateMap<Contact, ContactModel>().ReverseMap();
            #endregion

            #region Category
            CreateMap<CategoryModel, Category>().ReverseMap();
            #endregion
            #region Product
            CreateMap<Product, ProductModel>().ForMember(x => x.FileImage, opt => opt.Ignore()).ReverseMap();
            CreateMap<CategoryProduct, CategoryProductModel>().ReverseMap();
            #endregion


        }
    }
}
