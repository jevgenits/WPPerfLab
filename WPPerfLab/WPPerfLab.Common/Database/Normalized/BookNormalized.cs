using System.Data.Linq.Mapping;

namespace WPPerfLab.Common.Database.Normalized
{
    [Table]
    public class BookNormalized
    {
        private int id;

        [Column(IsPrimaryKey = true,
            IsDbGenerated = true,
            DbType = "INT NOT NULL Identity",
            CanBeNull = false,
            AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                }
            }
        }

        private string name;

        [Column]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }

        private int authorId;

        [Column(CanBeNull = false)]
        public int AuthorId
        {
            get
            {
                return authorId;
            }
            set
            {
                if (authorId != value)
                {
                    authorId = value;
                }
            }
        }
    }
}
