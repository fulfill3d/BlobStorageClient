using Client.Models;

namespace Client.Interfaces
{
    public interface IBlobStorageClient
    {
        Task<string> Upload(Blob blob);
        Task<Stream> Download(Blob blob);
        Task Delete(Blob blob);
    }
}