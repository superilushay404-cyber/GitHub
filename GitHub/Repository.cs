namespace GitHub
{
    internal class Repository
    {
        public Repository(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<Commit> Log { get; set; }
    }
}
