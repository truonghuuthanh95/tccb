using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB.Repositories.Implements;
using TCCB.Repositories.Interfaces;
using Unity;
using Unity.Lifetime;

namespace TCCB.App_Start
{
    public static class IocConfigration
    {
        public static void ConfigrationIocContainer()
        {
            IUnityContainer container = new UnityContainer();
            registerService(container);
            DependencyResolver.SetResolver(new UnityResolver(container));

        }

        private static void registerService(IUnityContainer container)
        {
            container.RegisterType<IRegistrationPriceRepository, RegistrationPriceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRegistrationInterviewRepository, RegistrationInterviewRepository>();
            container.RegisterType<IManagementUnitRepository, ManagementUnitRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDistrictRepository, DistrictRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProvinceRepository, ProvinceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IWardRepository, WardRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubjectRepository, SubjectRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDegreeClassificationRepository, DegreeClassificationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISpecializedTrainingRepository, SpecializedTrainingRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITrainningCategoryRepository, TrainningCategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IForeignLanguageRepository, ForeignLanguageRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IInformationTechnologyDegree, InformationTechnologyDegreeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHighestLevelEducationRepository, HighestLevelEducationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGraduationClassficationRepository, GraduationClassficationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStatusWorikingInEducationRepository, StatusWorikingInEducationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISchoolDegreeRepository, SchoolDegreeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactInfomationRepository, ContactInformationRepository>(new HierarchicalLifetimeManager());
        }
    }
}