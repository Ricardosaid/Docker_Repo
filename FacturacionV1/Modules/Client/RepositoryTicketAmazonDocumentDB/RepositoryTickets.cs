using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;
using MongoDB.Driver;
using RepositoryTicketAmazonDocumentDB.Interfaces;


namespace RepositoryTicketAmazonDocumentDB;
public class RepositoryTickets : IRepositoryTickets
{
    private readonly string template = "";
    private readonly string username = "";
    private readonly string password = "";
    private readonly string readPreference = "";
    private readonly string clusterEndpoint = "";
    private readonly string connectionString = "";
    private readonly string pathToCAFile = "";


    /*
    public RepositoryTickets()
    {
        X509Store localTrustStore = new X509Store(StoreName.Root);
        X509Certificate2Collection certificateCollection = new X509Certificate2Collection();
        certificateCollection.Import("");
    }
    */


    public async Task<bool> RepositoryFunctions()
    {
        X509Store localTrustStore = new X509Store(StoreName.Root);
        X509Certificate2Collection certificateCollection = new X509Certificate2Collection();
        certificateCollection.Import("");

        try
        {
            localTrustStore.Open(OpenFlags.ReadWrite);
            localTrustStore.AddRange(certificateCollection);

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Root certificate import failed : " + ex.Message);
        }
        finally
        {
            localTrustStore.Close();
        }

        var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
        var client = new MongoClient(settings);
        var database = client.GetDatabase("");
        var collection = database.GetCollection<BsonDocument>("samplecollection");
        var docToInsert = new BsonDocument { { "pi", 3.14159 } };
        collection.InsertOne(docToInsert);


        return true;
    }

}

