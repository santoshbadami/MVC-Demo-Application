// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcDemoApplication.web.DependencyResolution {
    using MvcDemoApplication.Data.Infrastructure;
    using MvcDemoApplication.Data.Repository.Categories;
    using MvcDemoApplication.Data.Repository.Products;
    using MvcDemoApplication.Service.Categories;
    using MvcDemoApplication.Service.Products;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            ConfigureService();
            ConfigureRepository();
        }


        public void ConfigureService()
        {
            For<ICategoryService>().Use<CategoryService>();
            For<IProductService>().Use<ProductService>();
        }

        public void ConfigureRepository()
        {
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<IProductRepository>().Use<ProductRepository>();

            For<IDatabaseFactory>().Use<DatabaseFactory>();
            For<IUnitOfWork>().Use<UnitOfWork>();
        }

        #endregion
    }
}