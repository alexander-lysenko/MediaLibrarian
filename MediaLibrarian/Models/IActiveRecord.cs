namespace MediaLibrarian.Models
{
    internal interface IActiveRecord
    {
        int Id { get; set; }
        bool Save();
        bool Delete();
    }
}