using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Dominus.Database
{
    public class BaseEntityCustom : IDisposable
    {

        public BaseEntityCustom()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntityCustom);
        }

        public virtual bool Equals(BaseEntityCustom other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual Expression<Func<T, bool>> PrimaryKeyExpression<T>()
        {
            //Expression<Func<T, bool>> expression = entity => 1 != 1;
            //return expression;
            return null;
        }

        [NotMapped]
        public bool IsNew { get; set; }

    }
}

