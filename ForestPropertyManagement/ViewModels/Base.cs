using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ForestPropertyManagement.ViewModels
{

    internal class Base<T> where T : new()
    {
        protected List<T> all;
        public List<T> filteredItems;

        public virtual List<T> List
        {
            get
            {
                if (all == null)
                {
                    all = new Provider().Select<T>("SELECT * FROM " + typeof(T).Name);
                }
                return all;
            }
        }

        public T Selected { get; set; }
        public int SelectedIndex
        {
            get => all.IndexOf(Selected);
            set => Selected = filteredItems != null ? filteredItems[value] : all [value];
        }

        public event EventHandler OnChanged;
        protected void RaiseOnChanged()
        {
            OnChanged?.Invoke(this, EventArgs.Empty);
        }
        public void Remove()
        {
            List.Remove(Selected);
            RaiseOnChanged();
        }

        public virtual void AddIncrement(T item)
        {
            bool tmp = new Provider().AddIncrement<T>(item);
            if (tmp)
            {
                List.Add(item);
                RaiseOnChanged();
            }
        }

        public virtual void Add(T item)
        {
            bool tmp = new Provider().Add<T>(item);
            if (tmp)
            {
                List.Add(item);
                RaiseOnChanged();
            }
        }
    }
}
