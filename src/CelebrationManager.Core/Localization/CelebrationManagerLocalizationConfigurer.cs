using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CelebrationManager.Localization
{
    public static class CelebrationManagerLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CelebrationManagerConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CelebrationManagerLocalizationConfigurer).GetAssembly(),
                        "CelebrationManager.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
