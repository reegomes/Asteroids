using UnityEngine;
public static class DBManager
{
    public static string Username;
    public static int ScoreDB;
    public static bool LoggedIn { get { return Username != null; } }
    public static void LogOut()
    {
        Username = null;
    }
}