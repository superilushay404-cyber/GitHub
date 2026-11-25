namespace GitHub
{
    internal class Commit
    {
        public Commit(string name) 
        {
            Name = name;
        }
        
        public string Name { get; set; }

        public List<File> Files { get; set; } = new List<File>();
    }
}
