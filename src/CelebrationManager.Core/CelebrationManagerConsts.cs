using CelebrationManager.Debugging;

namespace CelebrationManager
{
    public class CelebrationManagerConsts
    {
        public const string LocalizationSourceName = "CelebrationManager";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "0830bbd58baa4ff9bf09e298f0b6137a";
    }
}
