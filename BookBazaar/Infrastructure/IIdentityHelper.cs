namespace BookBazaar.Infrastructure
{
    public interface IIdentityHelper
    {
        /// <summary>
        /// this method is used to create roles
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public abstract static Task CreateRoles(IServiceProvider provider, params string[] roles);

        /// <summary>
        /// Create a default user if one does not exist
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public abstract static Task CreateDefaultUser(IServiceProvider provider, string role);
    }
}
