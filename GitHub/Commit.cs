namespace GitHub
{
    internal class Commit
    {
        public Commit(string name, List<File> files) 
        {
            Name = name;
            Files = files;
        }
        
        public string Name { get; set; }

        public List<File> Files { get; set; } = new List<File>();
    }
}
