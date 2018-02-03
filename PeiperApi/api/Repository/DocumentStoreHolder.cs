using Raven.Client.Documents;

namespace api.Repository
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
        IDocumentStore StoreDeploy { get; }
    }
    public class DocumentStoreHolder : IDocumentStoreHolder
    {

        public IDocumentStore Store { get; private set; }
        public IDocumentStore StoreDeploy { get; private set; }

        public DocumentStoreHolder()
        {
            CreateStore();
            CreateStoreDeploy();
        }
        private void CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://192.168.0.15:8080/" },
                Database = "peiper"

            }.Initialize();

            Store = store;
        }

        private void CreateStoreDeploy()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://192.168.0.15:8080/" },
                Database = "build-release"

            }.Initialize();

            StoreDeploy = store;
        }
    }
}
