namespace CompaniesInfo.Server.Common.Contracts
{
    using System;

    public interface IObjectFactory : IService
    {
        T GetInstance<T>();

        object GetInstance(Type type);

        T TryGetInstance<T>();

        object TryGetInstance(Type type);
    }
}