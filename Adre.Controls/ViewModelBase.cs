using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Adre.Controls
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

        protected void NotifyPropertyChanged([CallerMemberName()]
            string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            }
            catch
            {
                // ignored
            }
        }

        public void NotifyAllPropertyChanged<T>(T targetObject) where T : ViewModelBase
        {
            Type type = targetObject.GetType();

            foreach (System.Reflection.PropertyInfo propertyInfo in type.GetProperties())
            {
                PropertyChanged?.Invoke(targetObject, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }

        public void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            dynamic memberExpression = (MemberExpression)projection.Body;
            NotifyPropertyChangedExplicit(memberExpression.Member.Name);
        }

        private void NotifyPropertyChangedExplicit(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
