using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Lifetime;
using Unity;

namespace CalculatorFinal.Container.Unity
{
    public static class DependencyInjector
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();

        /// <summary>
        /// Đăng ký một đối tượng (object) dựa trên một giao diện (interface) và một lớp cụ thể (class) tương ứng
        /// Chỉ một instance duy nhất của object sẽ được tạo ra và sử dụng trong suốt vòng đời của container
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TClass"></typeparam>
        public static void RegisterSingleton<TInterface, TClass>() where TClass : TInterface
        {
            UnityContainer.RegisterType<TInterface, TClass>(new ContainerControlledLifetimeManager());
        }
        /// <summary>
        /// Mỗi lần object được yêu cầu, một instance mới của object sẽ được tạo ra.
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TClass"></typeparam>
        public static void RegisterTransient<TInterface, TClass>() where TClass : TInterface
        {
            UnityContainer.RegisterType<TInterface, TClass>(new ContainerControlledTransientManager());
        }
        /// <summary>
        /// Truy xuất một đối tượng đã được đăng ký trong container
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <returns></returns>
        public static TClass Retrieve<TClass>()
        {
            return UnityContainer.Resolve<TClass>();
        }
    }
}
