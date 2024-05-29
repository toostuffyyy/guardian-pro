using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Document = GuardianProAPI.Entities.Document;

namespace GuardianProAPI.ModelDTO
{
    public partial class DocumentDTO
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;

        public static DocumentDTO CreateByDocument(Document document)
        {
            return new DocumentDTO()
            {
                Id = document.Id,
                Path = document.Path
            };
        }
    }
}
