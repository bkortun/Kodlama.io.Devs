using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology:Entity
    {
        public Technology()
        {

        }
        public Technology(int id, string name, int programmingLanguageId):this()
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
        }

        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
    }
}
