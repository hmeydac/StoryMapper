namespace StoryMapper.UI
{
    using StoryMapper.Core;
    using StoryMapper.Core.Repository;
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.Assembly("StoryMapper.Core");
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IStoryRepository>().Use(Domain.Current.StoryRepository);
                        });

            return ObjectFactory.Container;
        }
    }
}