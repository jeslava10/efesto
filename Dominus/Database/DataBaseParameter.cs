using System;
namespace Dominus.Database
{

    public class DataBaseParameter
    {
        public DataBaseParameter(string name, object value, Direcction direcction =  Database.Direcction.In)
        {
            Name = name;
            Value = value;
            Direcction = direcction;
        }

        public virtual string Name { get; set; }

        public virtual object Value { get; set; }

        public virtual Direcction? Direcction { get; set; }

        public virtual int? Length { get; set; }

    }

    public enum Direcction
    {
        In,
        Out,
        InOut
    }
}