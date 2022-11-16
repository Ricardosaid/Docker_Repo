namespace RepositoryTicketAmazonDocumentDB.UnitTest;

public class Repository
{
    [Fact]
    public void RepositoryTicketsSuccess()
    {
        var client = new RepositoryTickets();
        var result = client.RepositoryFunctions();
    
    }
}