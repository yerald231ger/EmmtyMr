namespace EMMTY_GO_WEB.Object
{
    public static class DbNotifierExtencions
    {
        public static bool IsInitializing(this DbNotifier dbNotifier)
        {
            return dbNotifier != null;
        }
    }
}