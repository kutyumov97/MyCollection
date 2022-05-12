//using MyCollection.Models;
//using Nest;

//namespace MyCollection.Extensions
//{
//    public static class ElasticsearchExtensions
//    {
//        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
//        {
//            var url = configuration["elasticsearch:url"];
//            var defaultIndex = configuration["elasticsearch:index"];

//            var settings = new ConnectionSettings(new Uri(url))
//                .PrettyJson()
//                .DefaultIndex(defaultIndex);

//            AddDefaultMappings(settings);

//            var client = new ElasticClient(settings);

//            services.AddSingleton<IElasticClient>(client);

//            CreateIndex(client, defaultIndex);
//        }

//        private static void AddDefaultMappings(ConnectionSettings settings)
//        {
//            settings.DefaultMappingFor<Collection>(m => m
//                        .Ignore(c => c.AppUserId)
//                    )
//                    .DefaultMappingFor<Item>(m => m
//                        .Ignore(c => c.CollectionId)
//                        .Ignore(c => c.AppUserId)
//                    );
//        }

//        private static void CreateIndex(IElasticClient client, string indexName)
//        {
//            client.Indices.Create(indexName, i => i.Map<Item>(x => x.AutoMap()));
//        }
//    }
//}
