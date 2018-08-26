using System;
using TestApp.Repository;
using TestApp.Repository.Contracts;
using Unity;
using Unity.Extension;

namespace TestApp.Services.UnityConfiguration
{
    public class UnityConfig : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}