namespace Ways.Classes
{
    internal class SqlCommand
    {
        private string request;
        private object connection;

        public SqlCommand(string request, object connection)
        {
            this.request = request;
            this.connection = connection;
        }
    }
}