using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Crosslog.TestRecrutement.Library.Factory
{
    /// <summary>
    /// Implementing Factory Design Pattern in Unity
    /// </summary>
    public class UnityFactory
    {
        private static readonly IUnityContainer _unityContainer = new UnityContainer();

        private static UnityFactory _factoryInstance;

        public static UnityFactory Instance
        {
            get
            {
                if (_factoryInstance == null)
                    _factoryInstance = new UnityFactory();

                return _factoryInstance;
            }
        }

        public UnityFactory()
        {
            try
            {
                _unityContainer.LoadConfiguration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Get<T>()
        {
            T res = default(T);

            try
            {
                res = _unityContainer.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}