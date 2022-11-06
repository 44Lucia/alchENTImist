using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    [Header("DB")]
    private IDbConnection dbConnection;

    private void Start()
    {
        OpenDatabase();

        string testquery = "SELECT * FROM potion_types;";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = testquery;
        
        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read()) {
            string potion_type = dataReader.GetString(1);
            Debug.Log(potion_type);
        }   
    }

    private void OpenDatabase()
    {
        string dbUri = "URI=file:alchENTImist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
    }
}
