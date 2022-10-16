using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacDependencyResolversModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieManager>().As<IMovieService>();
            builder.RegisterType<EfMovieDal>().As<IMovieDal>();

            builder.RegisterType<DirectorManager>().As<IDirectorService>();
            builder.RegisterType<EfDirectorDal>().As<IDirectorDal>();

            builder.RegisterType<GenreManager>().As<IGenreService>();
            builder.RegisterType<EfGenreDal>().As<IGenreDal>();

            builder.RegisterType<SaloonManager>().As<ISaloonService>();
            builder.RegisterType<EfSaloonDal>().As<ISaloonDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new InterceptorSelector()
                })
                .SingleInstance();

        }
    }
}
