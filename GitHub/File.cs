namespace GitHub
{
    internal class File
    {
        public File (string name, string text) 
        {
            Name = name;
            Text = text;
        }
        
        public string Name { get; set; }

        public string Text { get; set; }
    }
}
