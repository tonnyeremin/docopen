namespace DocOpen.Data
{
    public class ProjectItem
    {
        public int Id{get; set;}
        public int ProjectId{get; set;}
        public string Name{get; set;}
        public string Description {get; set;}
        public string BlobPath{get; set;}
    }
}