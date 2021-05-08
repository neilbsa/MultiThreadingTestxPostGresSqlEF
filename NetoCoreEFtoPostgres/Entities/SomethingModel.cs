

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetoCoreEFtoPostgres.Entities
{
    public class SomethingModel
    {

        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime? SampleDate { get; set; }
        public string Description { get; set; }
        public string Subsidiary { get; set; }
        public virtual IEnumerable<ChildSomethingModel> childs { get; set; }


    }




    public class ChildSomethingModel
    {

        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime? SampleDate { get; set; }
        public string Description { get; set; }
        public string Subsidiary { get; set; }

        public virtual SomethingModel HeadModel { get; set; }

    }
}
